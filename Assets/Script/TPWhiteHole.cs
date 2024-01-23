using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPWhiteHole : MonoBehaviour
{
    public Transform WhiteHole;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        Transform otherTransform = other.transform;
        otherTransform.position = WhiteHole.position;
    }
    //réduire la hitbox effective du trou noir
    //oncollide tp sur la position du trou blanc, direction aléatoire, annulation de la vitesse, 

}
