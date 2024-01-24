using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private float minSpeed;
    private float maxSpeed;

    void Start()
    {
        minSpeed = 15f;
        maxSpeed = 30f;

        transform.rotation = Quaternion.Euler(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f));

        float speed = Random.Range(minSpeed, maxSpeed);
        Vector3 randomDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f).normalized;
        Vector3 randomVelocity = randomDirection * speed * Time.deltaTime;

        GetComponent<Rigidbody>().velocity = randomVelocity;
    }

    void Update()
    {
        transform.Rotate(Vector3.up * Random.Range(10f, 50) * Time.deltaTime); // Rotation autour de l'axe Y
        transform.Rotate(Vector3.right * Random.Range(10f, 50f) * Time.deltaTime); // Rotation autour de l'axe X
        transform.Rotate(Vector3.forward * Random.Range(10f, 50f) * Time.deltaTime); // Rotation autour de l'axe Z
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Missile"))
        {
            Destroy(collision.gameObject);

            float scale1 = Random.Range(0.3f, 0.8f);
            float scale2 = 1 - scale1;

            if (transform.localScale.x > 30)
            {
                GameObject childAsteroid1 = Instantiate(gameObject, transform.position + new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f), transform.rotation);
                childAsteroid1.transform.localScale = transform.localScale * scale1;

                GameObject childAsteroid2 = Instantiate(gameObject, transform.position + new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f), transform.rotation);
                childAsteroid2.transform.localScale = transform.localScale * scale2;
            
            }
           


            Destroy(gameObject);
            
            // rajouter du fx de destruction d'astéroides ici, différencier petits et gros
            
        }
        if (collision.gameObject.CompareTag("Ship"))
        {
            Life lifeScript = collision.gameObject.GetComponent<Life>();
            lifeScript.LoseLife();
        }
    }

}
