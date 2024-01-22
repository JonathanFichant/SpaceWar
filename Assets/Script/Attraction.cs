using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attraction : MonoBehaviour
{
    public float attractionForce;
    public float attractionRadius;

    void Start()
    {
        // Black hole 2/20
        // White hole -1/20
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, attractionRadius);

        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("MagneticObject"))
            {
                Rigidbody rb = collider.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    Vector3 forceDirection = transform.position - collider.transform.position;
                    rb.AddForce(attractionForce * forceDirection.normalized);
                }
            }
        }
    }
}

