using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSkybox : MonoBehaviour
{
    public float rotationSpeed = 1.0f;


    void Update()
    {
        //skybox 6 sided ne permet pas une rotation sur les 3 axes apparemment
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * rotationSpeed);
    }
}
