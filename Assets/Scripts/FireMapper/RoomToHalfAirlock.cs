using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoomToHalfAirlock : MonoBehaviour
{
    private Room room;

    void Start()
    {
        room = GetComponentInParent<Room>();
        if (room == null) {
            Debug.LogError("Room Behavior Not In Room");
        }

        Debug.Log($"Looking for Room-Airlocks {transform.position} {GetComponent<SphereCollider>().radius}");
        var fieryDoomLayer = LayerMask.NameToLayer("FieryDoom");
        var colliders = Physics.OverlapSphere(transform.position, GetComponent<SphereCollider>().radius, fieryDoomLayer);
        var foundHalfAirlocks = colliders.Select(c => c.GetComponentInParent<HalfAirlock>()).Where(airlock => airlock != null);
        foreach (var halfAirlock in foundHalfAirlocks) {
            this.room.halfAirlocks.Add(halfAirlock);
            halfAirlock.room = this.room;
        }

        Debug.Log($"Found Room-Airlocks: {this.room.halfAirlocks.Count}");
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(this.gameObject);
    }
}
