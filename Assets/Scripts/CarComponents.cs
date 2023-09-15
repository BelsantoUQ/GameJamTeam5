using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarComponents : MonoBehaviour
{
    private Rigidbody rb; // Creamos una variable privada para el Rigidbody.

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Método público para obtener el Rigidbody.
    public Rigidbody SetRigidbody()
    {
        // Intentamos obtener el Rigidbody del objeto.
        rb = GetComponent<Rigidbody>();

        // Si no existe un Rigidbody, lo agregamos.
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
        }
        return rb;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}