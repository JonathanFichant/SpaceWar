using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    //déclarer prefab missile

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            //instantiate prefab objet tir avec direction et vitesse du ship qui appelle la fonction
        }
    }
}
