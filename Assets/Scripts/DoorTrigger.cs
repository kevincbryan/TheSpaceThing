using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    private HalfAirlock airlock;

    // Start is called before the first frame update
    void Start()
    {
        airlock = GetComponentInParent<HalfAirlock>();
        if (airlock == null) {
            Debug.LogError("HalfAirlock Behavior Not In HalfAirlock");
        }
    }

    public void Toggle() {
        airlock.Toggle();
    }

    public void OnTriggerEnter(Collider collider) {
        if (collider.tag == "Player") {
            collider.gameObject.GetComponent<PlayerInteraction>().OnDoorEnter(this);
        }
    }

    public void OnTriggerExit(Collider collider) {
        if (collider.tag == "Player") {
            collider.gameObject.GetComponent<PlayerInteraction>().OnDoorExit(this);
        }
    }
}
