using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody rb;
    private float speedBullet;
    public float timerDestruction;

    void Start()
    {
        speedBullet = 400;
        timerDestruction = 3f;
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.up * speedBullet * Time.deltaTime;
        Destroy(gameObject, timerDestruction);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Ship"))
        {
            Life lifeScript = collision.gameObject.GetComponent<Life>();
            lifeScript.LoseLife();
            Destroy(gameObject);
        }
    }
}
