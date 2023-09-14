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
    float rotationSpeed; // Define la velocidad de cambio de rotación
    
    float minX = -5.0f; // Define límite del rango minimo de movimiento permitido
    float maxX = 5.0f; // Define límite del rango maximo de movimiento permitido
    private Rigidbody rb;
    private float rotation;
    private bool isGrounded; // Variable para verificar si el jugador está en el suelo
    private RotatePlanet planetController;
    private GalaxyRotation galaxyController;
    private GameManager gameManager;
    private bool activateTunnelEffect;
    private bool lateTunnelEffect;
    private int hitsRemaining;
    private CarComponents carComponents;
    private bool noHit;
    Color chasisColor;
    private Material chasisMaterial;
    private bool isDestroyed;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        planetController = FindObjectOfType<RotatePlanet>();
        galaxyController = FindObjectOfType<GalaxyRotation>();
        gameManager = FindObjectOfType<GameManager>();
        GameObject chasis = GameObject.FindGameObjectWithTag("Chasis");
        Renderer chasisRenderer = chasis.GetComponent<Renderer>();
        chasisMaterial = chasisRenderer.material;
        chasisColor = chasisMaterial.color;
        jumpForce = 10f;
        moveSpeed = 5f;
        hitsRemaining = 2;
        rotationSpeed = 2.0f;
        lateTunnelEffect = false;
        noHit = false;
        isDestroyed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDestroyed)
        {
            planetController.SetSpeed(0f);
            galaxyController.SetSpeed(0f);
        }
        else
        {
            Move();
            Jump();
        }
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

        

        // Calcula la nueva posición después de aplicar la entrada horizontal
        float newPosition = currentPosition + (horizontalInput * moveSpeed * Time.deltaTime);

        // Limita la nueva posición dentro del rango
        newPosition = Mathf.Clamp(newPosition, minX, maxX);

        // Aplica la nueva posición
        transform.position = new Vector3(newPosition, transform.position.y, -12f);

        // Limita la rotación vertical del carro dentro de los límites
        float newRotationX = transform.rotation.eulerAngles.x;
        newRotationX = Mathf.Clamp(newRotationX, -102.457f, -101f);

        
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
                galaxyController.SetSpeed(10);
                noHit = true;
            }
        }
        else
        {
            // Ajustar la velocidad a 15
            planetController.SetSpeed(-15f);
            galaxyController.SetSpeed(5);
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
        this.noHit = activate;
        
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
        if (hitsRemaining < 2 && !noHit)
        {
            // Baja y sube sutilmente la opacidad
            StartCoroutine(ChangeOpacity(chasisMaterial, 0.5f, 3));

            // Cambia el tono del albedo material del objeto a rojo y vuelve al color original
            StartCoroutine(ChangeAlbedoColor(chasisMaterial, Color.red, 3));
        }

        if (hitsRemaining >= 1) return;
        // Si hitsRemaining es 0, desarma el carro
        CarComponents[] carComponentsArray = FindObjectsOfType<CarComponents>();

        foreach (CarComponents carComponent in carComponentsArray)
        {
            carComponent.SetRigidbody();
        }

        isDestroyed = true;

        if (isDestroyed) StartCoroutine(GameOver());
    }

    private IEnumerator GameOver()
    {
        yield return new WaitForSeconds(1.5f);
        gameManager.gameHasEnded = false;
    }
    private IEnumerator ChangeOpacity(Material material, float targetOpacity, int numTimes)
    {
        for (int i = 0; i < numTimes; i++)
        {
            float currentOpacity = material.color.a;
            float t = 0;
            while (t < .5f)
            {
                t += Time.deltaTime;
                Color newColor = material.color;
                newColor.a = Mathf.Lerp(currentOpacity, targetOpacity, t);
                material.color = newColor;
                yield return null;
            }
            yield return new WaitForSeconds(0.1f); // Espera un momento antes de revertir el cambio de opacidad
            // Invierte el objetivo de opacidad para crear un efecto de subida
            targetOpacity = 1 - targetOpacity;
        }
    }

    private IEnumerator ChangeAlbedoColor(Material material, Color targetColor, int numTimes)
    {
        Debug.Log("Color: :"+ material.color);
        Color originalColor = material.color;
        for (int i = 0; i < numTimes; i++)
        {
            float t = 0;
            while (t < .2f)
            {
                t += Time.deltaTime;
                Color newColor = Color.Lerp(originalColor, targetColor, t);
                material.color = newColor;
                yield return null;
            }
            yield return new WaitForSeconds(0.1f); // Espera un momento antes de volver al color original
            // Intercambia el color objetivo para volver al original
            Color temp = originalColor;
            originalColor = targetColor;
            targetColor = temp;
        }
    }
}