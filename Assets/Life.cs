using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    public int life = 9;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (life <= 0) {
            Destroy(gameObject);

        }

    }

    public void LoseLife()
        {
        life--;
        }
}
