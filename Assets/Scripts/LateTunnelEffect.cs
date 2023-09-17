using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LateTunnelEffect : MonoBehaviour
{
    private PlayerController playerController;
    [SerializeField]private AudioClip coinClip;
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }
    // Este método se llama cuando un objeto entra en el colisionador
    void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player") && !other.gameObject.CompareTag("Shield") && !other.gameObject.CompareTag("Coin"))
        {
            playerController.SetLateTunnelEffect(true);
            playerController.SetHit();

        }else // Verifica si el objeto que colision� 
        if (other.gameObject.CompareTag("Shield"))
        {
            playerController.PickUpPowerUpShield();
            // Reduzca gradualmente el tama�o del objeto de comida
            StartCoroutine(ShrinkAndDestroy(other.gameObject));
        }else // Verifica si el objeto que colision� es 
        if (other.gameObject.CompareTag("Coin"))
        {
            playerController.PickUpCoin();
            // Reduzca gradualmente el tama�o del objeto de comida
            StartCoroutine(ShrinkAndDestroy(other.gameObject));
            StartCoroutine(GetCoin());
            
        }
    }

    private IEnumerator GetCoin()
    {
        AudioSource carAudio = playerController.GetcarAudio();
        carAudio.PlayOneShot(coinClip);
        yield return new WaitForSeconds(.5f);
        
    }
    
    private IEnumerator ShrinkAndDestroy(GameObject other)
    {
        float shrinkDuration = 1.0f; // Duraci�n en segundos para reducir el tama�o
        float elapsedTime = 0f;
        Vector3 initialScale = other.transform.localScale;

        while (elapsedTime < shrinkDuration)
        {
            if (!other.gameObject.IsUnityNull())
            {
                // Reduce gradualmente el tama�o del objeto de comida
                other.transform.localScale = Vector3.Lerp(initialScale, Vector3.zero, elapsedTime / shrinkDuration);

                // Incrementa el tiempo transcurrido
                elapsedTime += Time.deltaTime;
            }

            yield return null;
        }

        if (other.gameObject.IsUnityNull()) yield break;
        // Aseg�rate de que el objeto de comida est� completamente invisible
        other.transform.localScale = Vector3.zero;

        // Finalmente, elimina el objeto de comida de la escena
        Destroy(other);
    }

    // Este método se llama cuando un objeto sale del colisionador
    void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.CompareTag("Player") && !other.gameObject.CompareTag("Shield") && !other.gameObject.CompareTag("Coin"))
        {
            playerController.SetLateTunnelEffect(false);
        }
    }
}