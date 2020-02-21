using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfAirlock : MonoBehaviour
{
    public bool isOpen = true;

    public HalfAirlock pairedAirlock;

    public Room room;

    public Door door;

    public void Start() {
        this.SetOpen(this.isOpen);
    }
    
    public void Toggle() {
        //Debug.Log("am door");
        this.isOpen = !this.isOpen;
        this.door.SetOpen(this.isOpen);
        this.pairedAirlock.SetOpen(this.isOpen);
    }

    public void SetOpen(bool isOpen) {
        this.isOpen = isOpen;
        this.door.SetOpen(isOpen);

        if (this.pairedAirlock.isOpen != this.isOpen) {
            this.pairedAirlock.SetOpen(this.isOpen);
        }
    }

    /*void OnDrawGizmos()
    {
        Gizmos.color = this.isOpen ? Color.white : Color.black;

        var above = new Vector3(0, 5, 0);
        Gizmos.DrawSphere(transform.position + above, 2);
    }*/
}
