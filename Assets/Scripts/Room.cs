using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public float oxygen = 100f;
    float maxOxygen = 100f;
    [SerializeField] float oxygenRegen = 5f;
    [SerializeField] float oxygenLossPerHole = 1f;
    [SerializeField] float oxygenHandleRate = 1f;

    HashSet<LeakingAir> holes = new HashSet<LeakingAir>();

    public bool isOnFire = false;

    public HashSet<HalfAirlock> halfAirlocks = new HashSet<HalfAirlock>();

    private void Start()
    {
        maxOxygen = oxygen;
        InvokeRepeating("HandleOxygenLevels", 0f, oxygenHandleRate);
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

    void OnDrawGizmos()
    {
        var above = new Vector3(0, 20, 0);
        Gizmos.DrawSphere(transform.position + above, 5);

        foreach (var halfAirlock in halfAirlocks) {
            Gizmos.DrawLine(transform.position + above, halfAirlock.gameObject.transform.position + above);
        }
        Gizmos.color = Color.white;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        var above = new Vector3(0, 20, 0);
        Gizmos.DrawSphere(transform.position + above, 6f);

        foreach (var halfAirlock in halfAirlocks) {
            Gizmos.DrawSphere(halfAirlock.gameObject.transform.position + above, 3f);
        }

        foreach (var halfAirlock in halfAirlocks) {
            Gizmos.DrawLine(transform.position + above, halfAirlock.gameObject.transform.position + above);
        }
    }
}
