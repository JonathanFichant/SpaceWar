using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody rb;
    public float speedBullet = 5f;
    public float timerDestruction;

    void Start()
    {
        timerDestruction = 6f;
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.up * speedBullet;
        Destroy(gameObject, timerDestruction);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
