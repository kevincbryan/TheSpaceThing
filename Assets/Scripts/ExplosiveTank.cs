using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveTank : MonoBehaviour
{
    [SerializeField] GameObject explosionPrefab;
    [SerializeField] GameObject firePrefab;

    public void Explode(Room room)
    {
        room.isOnFire = true;

        //Instantiate(explosionPrefab, transform.position, Quaternion.identity, room.gameObject.transform);
        GameObject fire = Instantiate(firePrefab, transform.position, Quaternion.identity, room.gameObject.transform);

        room.AddFire(fire.GetComponent<Fire>());
        Destroy(gameObject);
    }
}
