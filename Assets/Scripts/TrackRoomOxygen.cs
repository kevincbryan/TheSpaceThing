using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackRoomOxygen : MonoBehaviour
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
    public void Update()
    {
        var oxygenLevel = room.oxygen / 100f;
        transform.localScale = new Vector3(transform.localScale.x, oxygenLevel, transform.localScale.z);
        transform.localPosition = new Vector3(transform.localPosition.x, -1f + oxygenLevel, transform.localPosition.z);
    }
}
