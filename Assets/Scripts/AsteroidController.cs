using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof (Rigidbody))]
public class AsteroidController : MonoBehaviour
{
    new Rigidbody rigidbody;
    [SerializeField] float minFlySpeed = 10f;
    [SerializeField] float maxFlySpeed = 50f;
    [SerializeField] AudioClip[] audioClips;

    [SerializeField] GameObject airLeakPrefab;

    [SerializeField] float explosionRadius = 5f;

    float speedMultiplier = 10000f;

    // Start is called before the first frame update
    void Start()
    {
        transform.LookAt(new Vector3(0f, 1f, 0f));
        rigidbody = GetComponent<Rigidbody>();

        rigidbody.AddForce(transform.forward * Random.Range(minFlySpeed, maxFlySpeed) * speedMultiplier);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Room"))
        {
            CollideWithRoom(other.gameObject.GetComponentInParent<Room>());
        }
    }

    private void CollideWithRoom(Room room)
    {
        CreateAirLeak(room);
        CreateExplosion(room);
        ImpactParticle();
        ImpactSound();
        Destroy(this.gameObject);
    }

    private void CreateExplosion(Room room)
    {
        int layerMask = 1 << LayerMask.NameToLayer("Environment");
        Collider[] explosives = Physics.OverlapSphere(transform.position, explosionRadius, layerMask);

        foreach (Collider explosive in explosives)
        {
            if (explosive.CompareTag("Explosive"))
            {
                explosive.gameObject.GetComponent<ExplosiveTank>().Explode(room);
            }
            
        }
    }

    private void ImpactSound()
    {
        if (audioClips.Length > 0)
        {
            int audioClipToPlay = Random.Range(0, audioClips.Length);
            AudioSource.PlayClipAtPoint(audioClips[audioClipToPlay], transform.position);
        }
        
    }

    private void CreateAirLeak(Room room)
    {
        GameObject newLeak = Instantiate(airLeakPrefab, transform.position, Quaternion.identity, room.transform);
        room.AddLeak(newLeak.GetComponent<LeakingAir>());
    }

    private void ImpactParticle()
    {
        //TODO particle for impact with wall
    }
}
