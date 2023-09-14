using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarMotion : MonoBehaviour
{
    [Header("Velocity of rotation")]
    [SerializeField] private float rotSpeed = 300f;

    private void Update()
    {
        Vector3 rotTransform = new Vector3(-rotSpeed/2, rotSpeed, rotSpeed/2);
        transform.Rotate(rotTransform * Time.deltaTime);
    }
}
