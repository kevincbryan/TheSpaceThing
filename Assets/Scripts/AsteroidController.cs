using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof (Rigidbody))]
public class AsteroidController : MonoBehaviour
{
    Rigidbody rigidbody;
    [SerializeField] float minFlySpeed = 10f;
    [SerializeField] float maxFlySpeed = 50f;
    [SerializeField] AudioClip[] audioClips;

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
            CollideWithRoom();
        }
    }

    private void CollideWithRoom()
    {
        ImpactParticle();
        ImpactSound();
        Destroy(this.gameObject);
    }

    private void ImpactSound()
    {
        if (audioClips.Length > 0)
        {
            int audioClipToPlay = Random.Range(0, audioClips.Length);
            AudioSource.PlayClipAtPoint(audioClips[audioClipToPlay], transform.position);
        }
        
    }

    private void ImpactParticle()
    {
        //TODO particle for impact with wall
    }
}
