using UnityEngine;

public class SpawnPower : MonoBehaviour
{
    void Start()
    {
        // Invoca el método DesactivarGameObject después de 2 segundos.
        Invoke("DeactiveGameObject", 2f);
    }

    void DeactiveGameObject()
    {
        // Desactiva el objeto después de 2 segundos.
        gameObject.SetActive(false);
    }
}