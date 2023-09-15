using UnityEngine;

public class DestroyObstacle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Destruye este objeto después de 7 segundos
        Destroy(gameObject, 7f);
    }

}