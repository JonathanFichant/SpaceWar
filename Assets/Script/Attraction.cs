using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attraction : MonoBehaviour
{
    public float attractionForce;
    public float attractionRadius;
    public float maxVelocity = 15f;

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
            Rigidbody rb = collider.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 forceDirection = transform.position - collider.transform.position;
                float distanceSquared = forceDirection.sqrMagnitude;

                // Vérifiez si la distance n'est pas nulle avant de calculer l'attraction
                if (distanceSquared > 0.0001f)  // Utilisez une petite valeur seuil pour éviter la division par zéro
                {
                    // Ajustez l'attraction en fonction de la distance
                    float adjustedAttractionForce = attractionForce / distanceSquared;

                    // Calculez la vélocité en fonction de l'attraction
                    Vector3 velocity = adjustedAttractionForce * forceDirection.normalized;

                    // Ajustez la vélocité pour s'assurer qu'elle ne dépasse pas une certaine limite (facultatif)
                    velocity = Vector3.ClampMagnitude(velocity, maxVelocity);

                    // Ajoutez la vélocité à l'objet attracté
                    rb.velocity += velocity * Time.deltaTime;
                }
            }
        }
    }
}

