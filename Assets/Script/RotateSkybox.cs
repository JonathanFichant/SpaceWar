using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSkybox : MonoBehaviour
{
    public float rotationSpeedX = 1.0f;
    public float rotationSpeedY = 2.0f;
    public float rotationSpeedZ = 3.0f;

    void Update()
    {

        // régler soucis pour que ça tourne sur les 3 axes
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * rotationSpeedX);
        RenderSettings.skybox.SetFloat("_RotationY", Time.time * rotationSpeedY);
        RenderSettings.skybox.SetFloat("_RotationZ", Time.time * rotationSpeedZ);
    }
}
