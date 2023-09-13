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
    private float rotation;
    private bool isGrounded; // Variable para verificar si el jugador está en el suelo
    private RotatePlanet planetController;
    private bool activateTunnelEffect;
    private bool lateTunnelEffect;
    private int hitsRemaining;
    private CarComponents carComponents;
    private bool noHit;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        planetController = FindObjectOfType<RotatePlanet>();
        jumpForce = 10f;
        moveSpeed = 5f;
        hitsRemaining = 2;
        lateTunnelEffect = false;
        noHit = false;
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
        TunnelEffectPower();
        
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
        transform.position = new Vector3(newPosition, transform.position.y, -12f);

        // Limita la rotación vertical de la cámara dentro de los límites
        float newRotationX = transform.rotation.eulerAngles.x;
        newRotationX = Mathf.Clamp(newRotationX, -102.457f, -101f);

        // Define la velocidad de cambio de rotación
        float rotationSpeed = 2.0f;

        // Calcula la nueva rotación
        float targetRotation = 0.0f;

        if (horizontalInput > 0)
        {
            targetRotation = 25.0f;
        }
        else if (horizontalInput < 0)
        {
            targetRotation = -25.0f;
        }

        // Aplica una interpolación lineal para suavizar la rotación
        rotation = Mathf.Lerp(rotation, targetRotation, Time.deltaTime * rotationSpeed);

        if (rotation > -25 && rotation < 25)
        {
            // Aplica la rotación horizontal restringida
            transform.rotation = Quaternion.Euler(newRotationX, 0, rotation);
        }
    }

    private void TunnelEffectPower()
    {
        
        if (this.activateTunnelEffect)
        {
            if (Input.GetKeyDown(KeyCode.R) && !lateTunnelEffect)
            {
                planetController.SetSpeed(-50f);
                noHit = true;
            }
        }
        else
        {
            // Ajustar la velocidad a 15
            planetController.SetSpeed(-15f);
        }
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

    public void SetTunnelEffect(bool activate)
    {
        this.activateTunnelEffect = activate;
        
    }
    
    public void SetNoHit(bool activate)
    {
        this.activateTunnelEffect = activate;
        
    }
    
    public void SetLateTunnelEffect(bool activate)
    {
        this.lateTunnelEffect = activate;
    }

    public void SetHit()
    {
        if (!noHit)
        {
            this.hitsRemaining -= 1;
        }

        // Verifica si hitsRemaining es mayor o igual a 1
        if (hitsRemaining > 0)
        {
            // Aplica el efecto de golpe en el objeto
            // baja y sube sutilmente la opacidad del material del objeto para dar efecto de golpe
            // Cambia el tono del albedo material del objeto a rojo de la misma manera que la opacidad

            // Sacude un poquito la cámara principal de la escena que está fuera de este gameObject
            
        }
        else
        {
            // Si hitsRemaining es 0, desarma el carro
            CarComponents[] carComponentsArray = FindObjectsOfType<CarComponents>();

            foreach (CarComponents carComponent in carComponentsArray)
            {
                carComponent.SetRigidbody();
            }
        }
    }
}