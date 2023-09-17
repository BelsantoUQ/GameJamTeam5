using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelEffect : MonoBehaviour
{
    private PlayerController playerController;

    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    // Este método se llama cuando un objeto entra en el colisionador
    void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player") 
            && !other.gameObject.CompareTag("Shield") 
            && !other.gameObject.CompareTag("Coin"))
        {
            if (!other.gameObject.CompareTag("Parry")) return;
            playerController.SetTunnelEffect(true);
        }
    }

    
    // Este método se llama cuando un objeto sale del colisionador
    void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.CompareTag("Player") && !other.gameObject.CompareTag("Shield") && !other.gameObject.CompareTag("Coin"))
        {
            playerController.SetTunnelEffect(false);
            playerController.SetNoHit(false);
        }
    }
}