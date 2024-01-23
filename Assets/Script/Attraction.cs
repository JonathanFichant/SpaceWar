using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attraction : MonoBehaviour
{
    public float attractionForce;
    public float attractionRadius;

    void Start()
    {

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
            //if (collider.CompareTag("MagneticObject"))
            {
                Rigidbody rb = collider.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    Vector3 forceDirection = transform.position - collider.transform.position;
                    float distanceSquared = forceDirection.sqrMagnitude;

                    // Ajustez l'attraction en fonction de la distance
                    float adjustedAttractionForce = attractionForce / distanceSquared;

                    // Ajoutez la force avec l'ajustement
                    rb.AddForce(adjustedAttractionForce * forceDirection.normalized);
                }
            }
        }
    }
}

