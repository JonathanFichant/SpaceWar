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

                // V�rifiez si la distance n'est pas nulle avant de calculer l'attraction
                if (distanceSquared > 0.0001f)  // Utilisez une petite valeur seuil pour �viter la division par z�ro
                {
                    // Ajustez l'attraction en fonction de la distance
                    float adjustedAttractionForce = attractionForce / distanceSquared;

                    // Calculez la v�locit� en fonction de l'attraction
                    Vector3 velocity = adjustedAttractionForce * forceDirection.normalized;

                    // Ajustez la v�locit� pour s'assurer qu'elle ne d�passe pas une certaine limite (facultatif)
                    velocity = Vector3.ClampMagnitude(velocity, maxVelocity);

                    // Ajoutez la v�locit� � l'objet attract�
                    rb.velocity += velocity * Time.deltaTime;
                }
            }
        }
    }
}

