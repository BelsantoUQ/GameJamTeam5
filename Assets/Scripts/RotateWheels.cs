using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWheels : MonoBehaviour
{
    [SerializeField] private float rotationSpeed; // Velocidad de rotación en grados por segundo

    void Start()
    {
        rotationSpeed = 80.0f;
    }

    // Update is called once per frame
    void Update()
    {
        // Rotar la esfera hacia adelante en el eje Y
        transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);
        
    }

    public void SetSpeed(float newSpeed)
    {
        this.rotationSpeed = newSpeed;
    }
    
    public float GetSpeed(float newSpeed)
    {
        return this.rotationSpeed;
    }

}