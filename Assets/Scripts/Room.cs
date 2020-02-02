using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class Room : MonoBehaviour
{
    public float oxygen = 100f;
    float maxOxygen = 100f;
    public ShaderManip m_Shader;
    [SerializeField] float oxygenRegen = 5f;
    [SerializeField] float oxygenLossPerHole = 1f;
    [SerializeField] float oxygenLossForFire = 5f;
    [SerializeField] float oxygenHandleRate = 1f;
    [SerializeField] float fireSpreadRate = 2f;
    [SerializeField] float maxOxygenThiefRate = 20f;

    [SerializeField] float fireSpawnRadius = 5f;
    [SerializeField] GameObject firePrefab;

    HashSet<LeakingAir> holes = new HashSet<LeakingAir>();
    HashSet<Fire> fires = new HashSet<Fire>();

    public bool isOnFire = false;
    public bool wasThiefed = false;

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

    public void AddFire(Fire fire)
    {
        fires.Add(fire);
    }

    public void FixLeak(LeakingAir leakingAir)
    {
        if (holes.Contains(leakingAir))
        {
            holes.Remove(leakingAir);
        }
    }

    public void FixFire(Fire fire)
    {
        if (fires.Contains(fire))
        {
            fires.Remove(fire);
        }

        if (fires.Count <= 0)
        {
            isOnFire = false;
        }
    }

    void SpreadFire() {
        return;
        if (!this.isOnFire) {
            m_Shader.Fire(0f);
            return;
        }

        if (this.fireTimer?.ElapsedMilliseconds < 1000) {
            return;
        }

        if (oxygen <= 0)
        {
            foreach (Fire fire in fires)
            {
                FixFire(fire);
            }
        }

        SpawnFire();
        
        var target = this.halfAirlocks
            .Where(al => al.isOpen && al.pairedAirlock.isOpen)
            .Select(al => al.pairedAirlock.room)
            .Where(room => !room.isOnFire).FirstOrDefault();

        if (target != null) {
            target.isOnFire = true;
            target.fireTimer = Stopwatch.StartNew();
            m_Shader.Fire(1f);
        }
    }

    void HandleOxygenLevels()
    {
        // regenerate oxygen
        var shouldRegen =
                holes.Count <= 0
                && !this.isOnFire;

        if (shouldRegen)
        {
            if (!this.wasThiefed)
            {
                oxygen = Mathf.Clamp(oxygen + oxygenRegen, 0, maxOxygen);
                m_Shader.Air(1f - (oxygen / 100f));
                return;
            } else {
                this.wasThiefed = false;
            }
        }

        // steal from nearby rooms
        var nearbyOpenRooms = this.halfAirlocks.Where(ha => ha.isOpen && ha.pairedAirlock.isOpen);
        var nearbyRoomsWithAir = nearbyOpenRooms.Select(ha => ha.pairedAirlock.room).Where(r => r.oxygen > 0);
        var nearbyRoomsWithMoreAir = nearbyRoomsWithAir.Where(r => r.oxygen > this.oxygen).OrderByDescending(r => r.oxygen);
        foreach (var otherRoom in nearbyRoomsWithMoreAir) {
            var oxygenDifference = otherRoom.oxygen - this.oxygen;
            var oxygenEqualizationDifference = oxygenDifference / 2;
            var targetThiefRate = Mathf.Clamp(maxOxygenThiefRate, 0, oxygenEqualizationDifference);
            if (targetThiefRate > 0) {
                oxygen = Mathf.Clamp(oxygen + targetThiefRate, 0, maxOxygen);
                otherRoom.oxygen = Mathf.Clamp(otherRoom.oxygen - targetThiefRate, 0, otherRoom.maxOxygen);
                otherRoom.wasThiefed = true;
            } else {
                break;
            }
        }

        // lose oxygen
        var oxygenLossDueToHoles = oxygenLossPerHole * holes.Count;
        var oxygenLossDueToFire = this.isOnFire ? oxygenLossForFire : 0;
        var oxygenLoss = oxygenLossDueToHoles + oxygenLossDueToFire;
        oxygen = Mathf.Clamp(oxygen -  oxygenLoss, 0, maxOxygen);
        m_Shader.Air(1f - (oxygen / 100f));
    }

    public void SpawnFire()
    {
        if (firePrefab == null)
        {
            Debug.LogError("No fire prefab located on " + gameObject.name);
            return;
        }
        Vector3 spawnLocation = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)) * fireSpawnRadius;
        spawnLocation += transform.position;

        GameObject newFire = Instantiate(firePrefab, spawnLocation, Quaternion.identity, transform);
        AddFire(newFire.GetComponent<Fire>());
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
