using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    //d�clarer prefab missile
    public GameObject missile;
  

    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Transform canonTransform = transform.Find("Canon");
            Instantiate(missile, canonTransform.position, transform.rotation);
        }
    }
}
