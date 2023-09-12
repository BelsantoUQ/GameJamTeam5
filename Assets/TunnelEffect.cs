using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelEffect : MonoBehaviour
{
    private PlayerController playerController;

    // Este método se llama cuando un objeto entra en el colisionador
    void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player"))
        {
            playerController = FindObjectOfType<PlayerController>();
            playerController.SetTunnelEffect(true);
        }
    }

    // Este método se llama cuando un objeto sale del colisionador
    void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.CompareTag("Player"))
        {
            playerController.SetTunnelEffect(false);
        }
    }
}