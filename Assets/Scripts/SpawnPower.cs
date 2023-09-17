using UnityEngine;

public class SpawnPower : MonoBehaviour
{
    void Start()
    {
        // Invoca el método DesactivarGameObject después de 2 segundos.
        Invoke("DeactiveGameObject", 1f);
    }

    void DeactiveGameObject()
    {
        // Desactiva el objeto después de 2 segundos.
//        Debug.Log("Desactivar efecto");
        gameObject.SetActive(false);
    }
}