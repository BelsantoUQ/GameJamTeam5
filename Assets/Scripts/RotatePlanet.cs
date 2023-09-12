using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlanet : MonoBehaviour
{
    public float rotationSpeed = 20.0f; // Velocidad de rotación en grados por segundo

    // Update is called once per frame
    void Update()
    {
        // Rotar la esfera hacia adelante en el eje Y
        transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);
    }
}