using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine;

public class Room : MonoBehaviour
{
    public float oxygen = 100f;
    float maxOxygen = 100f;
    [SerializeField] float oxygenRegen = 5f;
    [SerializeField] float oxygenLossPerHole = 1f;
    [SerializeField] float oxygenHandleRate = 1f;
    [SerializeField] float fireSpreadRate = 2f;

    HashSet<LeakingAir> holes = new HashSet<LeakingAir>();

    public bool isOnFire = false;

    public Stopwatch fireTimer;

    public List<HalfAirlock> halfAirlocks = new List<HalfAirlock>();

    private void Start()
    {
        maxOxygen = oxygen;
        InvokeRepeating(nameof(HandleOxygenLevels), 0f, oxygenHandleRate);
        InvokeRepeating(nameof(SpreadFire), 0f, fireSpreadRate);
    }

    public void AddLeak(LeakingAir leakingAir)
    {
        holes.Add(leakingAir);
    }

    public void FixLeak(LeakingAir leakingAir)
    {
        if (holes.Contains(leakingAir))
        {
            holes.Remove(leakingAir);
        }
    }

    void SpreadFire() {
        if (!this.isOnFire) {
            return;
        }

        if (this.fireTimer?.ElapsedMilliseconds < 1000) {
            return;
        }
        
        var target = this.halfAirlocks
            .Where(al => al.isOpen && al.pairedAirlock.isOpen)
            .Select(al => al.pairedAirlock.room)
            .Where(room => !room.isOnFire).FirstOrDefault();

        if (target != null) {
            target.isOnFire = true;
            target.fireTimer = Stopwatch.StartNew();
        }
    }

    void HandleOxygenLevels()
    {
        if (holes.Count <= 0)
        {
            
            oxygen = Mathf.Clamp(oxygen + oxygenRegen, 0, maxOxygen);
        }
        else
        {
            oxygen = Mathf.Clamp(oxygen - (oxygenLossPerHole * holes.Count) , 0, maxOxygen);
        }
    }

    // void OnDrawGizmos()
    // {
    //     if (this.isOnFire) {
    //         Gizmos.color = Color.red;
    //     }

    //     var above = new Vector3(0, 20, 0);
    //     Gizmos.DrawSphere(transform.position + above, 5);

    //     foreach (var halfAirlock in halfAirlocks) {
    //         Gizmos.DrawLine(transform.position + above, halfAirlock.gameObject.transform.position + above);
    //     }

    //     Gizmos.color = Color.white;
    // }

    // void OnDrawGizmosSelected()
    // {
    //     Gizmos.color = Color.blue;
    //     var above = new Vector3(0, 20, 0);
    //     Gizmos.DrawSphere(transform.position + above, 6f);

    //     foreach (var halfAirlock in halfAirlocks) {
    //         Gizmos.DrawSphere(halfAirlock.gameObject.transform.position + above, 3f);
    //     }

    //     foreach (var halfAirlock in halfAirlocks) {
    //         Gizmos.DrawLine(transform.position + above, halfAirlock.gameObject.transform.position + above);
    //     }
    // }
}
