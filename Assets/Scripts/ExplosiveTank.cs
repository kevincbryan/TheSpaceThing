using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveTank : MonoBehaviour
{
    [SerializeField] GameObject explosionPrefab;

    public void Explode(Room room)
    {
        room.isOnFire = true;

        Instantiate(explosionPrefab, transform.position, Quaternion.identity, room.gameObject.transform);
        Destroy(gameObject);
    }
}
