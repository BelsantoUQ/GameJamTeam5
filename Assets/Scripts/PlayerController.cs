using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed; // Velocidad de movimiento lateral
    [SerializeField]
    private float jumpForce; // Fuerza de salto
    private Rigidbody rb;

    private bool isGrounded; // Variable para verificar si el jugador está en el suelo

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jumpForce = 10f;
        moveSpeed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    private void Jump()
    {
        // Saltar cuando se presiona la tecla de espacio y el jugador está en el suelo
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false; // Marcamos que el jugador ya no está en el suelo
        }
    }

    private void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float currentPosition = transform.position.x;

        // Define los límites del rango permitido
        float minX = -5.0f;
        float maxX = 5.0f;

        // Calcula la nueva posición después de aplicar la entrada horizontal
        float newPosition = currentPosition + (horizontalInput * moveSpeed * Time.deltaTime);

        // Limita la nueva posición dentro del rango
        newPosition = Mathf.Clamp(newPosition, minX, maxX);

        // Aplica la nueva posición
        transform.position = new Vector3(newPosition, transform.position.y, transform.position.z);
        
    }


    // Detectar si el jugador está en el suelo
    private void OnCollisionEnter(Collision collision)
    {
        ValidateGroundCollision(collision);
    }

    private void ValidateGroundCollision(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; // El jugador está en el suelo
        }
    }
}