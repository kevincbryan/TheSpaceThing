using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HalfAirlockToHalfAirlock : MonoBehaviour
{
    private HalfAirlock airlock;

    // Start is called before the first frame update
    void Start()
    {
        airlock = GetComponentInParent<HalfAirlock>();
        if (airlock == null) {
            Debug.LogError("HalfAirlock Behavior Not In HalfAirlock");
        }

        Debug.Log($"Looking for Airlock Pairs {transform.position} {GetComponent<SphereCollider>().radius}");
        var colliders = Physics.OverlapSphere(transform.position, GetComponent<SphereCollider>().radius);
        var foundHalfAirlocks = colliders.Select(c => c.GetComponentInParent<HalfAirlock>()).Where(al => al != null && al != this.airlock).ToList();
        if (foundHalfAirlocks.Count > 1) {
            Debug.LogError($"Too many half airlocks near each other. {foundHalfAirlocks.Count}");
        } else if (foundHalfAirlocks.Count != 1) {
            Debug.LogError("Half airlocks not paired.");
        } else {
            Debug.Log("Found Airlock Pair");
        }

        this.airlock.pairedAirlock = foundHalfAirlocks.FirstOrDefault();
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(this.gameObject);
    }
}
