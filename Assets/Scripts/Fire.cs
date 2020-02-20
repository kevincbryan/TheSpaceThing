﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    Room room;

    private void Start()
    {
        room = GetComponentInParent<Room>();
        if (room == null)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (other.gameObject.GetComponent<PlayerInputManager>().InteractPressed())
            {
                Repair();
            }
        }
    }

    public void Repair()
    {
        room.FixFire(this);
    }
}
