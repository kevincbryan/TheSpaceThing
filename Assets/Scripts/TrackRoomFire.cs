using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackRoomFire : MonoBehaviour
{
    private Room room;

    void Start()
    {
        room = GetComponentInParent<Room>();
        if (room == null) {
            Debug.LogError("Room Status Not In Room");
        }
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = room.isOnFire;
    }
}
