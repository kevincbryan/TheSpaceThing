using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Rigidbody))]
public class AsteroidController : MonoBehaviour
{
    Rigidbody rigidbody;
    [SerializeField] float minFlySpeed = 10f;
    [SerializeField] float maxFlySpeed = 50f;

    float speedMultiplier = 1000f;

    // Start is called before the first frame update
    void Start()
    {
        transform.LookAt(new Vector3(0f, 1f, 0f));
        rigidbody = GetComponent<Rigidbody>();

        rigidbody.AddForce(transform.forward * Random.Range(minFlySpeed, maxFlySpeed) * speedMultiplier);
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
