using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMotion : MonoBehaviour
{
    [Header("Velocity of rotation")]
    [SerializeField] private float rotSpeed = -10f;

    private void Update()
    {
        Vector3 rotTransform = new Vector3(rotSpeed, 0, 0);
        transform.Rotate(rotTransform * Time.deltaTime);
    }

    
}
