using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    public enum ColorOptions { White, Blue, Dark, Gold, Translucent }

    [SerializeField]
    private ColorOptions selectedColor = ColorOptions.White; // Valor azul predeterminado

    [SerializeField]
    private GameObject[] playerPrefabs;
    
    // Usar 'selectedColor' aquí para saber qué opción se seleccionó e insertar el carro seleccionado.
    GameObject selectedCarPrefab = null;
    void Start()
    {
        // Llamamos a la función SelectPlayer() para seleccionar un jugador al azar.
        SelectPlayer(Random.Range(0, 5)); // Genera un número aleatorio entre 0 y 4 (incluyendo 0 pero excluyendo 5).

        if (selectedCarPrefab == null)
            selectedCarPrefab = playerPrefabs[0];
        
        switch (selectedColor)
        {
            case ColorOptions.White:
                selectedCarPrefab = playerPrefabs[0]; // Asigna el prefab del carro blanco
                break;
            case ColorOptions.Blue:
                selectedCarPrefab = playerPrefabs[1]; // Asigna el prefab del carro azul
                break;
            case ColorOptions.Dark:
                selectedCarPrefab = playerPrefabs[2]; // Asigna el prefab del carro negro
                break;
            case ColorOptions.Gold:
                selectedCarPrefab = playerPrefabs[3]; // Asigna el prefab del carro dorado
                break;
            case ColorOptions.Translucent:
                selectedCarPrefab = playerPrefabs[4]; // Asigna el prefab del carro translúcido
                break;
        }

        
        if (selectedCarPrefab != null)
        {
            Instantiate(
                selectedCarPrefab,
                selectedCarPrefab.transform.position,
                selectedCarPrefab.transform.rotation
            );
        }
    }

    public void SelectPlayer(int colorIndex)
    {
        switch (colorIndex)
        {
            case 0:
                selectedColor = ColorOptions.White;
                break;
            case 1:
                selectedColor = ColorOptions.Blue;
                break;
            case 2:
                selectedColor = ColorOptions.Dark;
                break;
            case 3:
                selectedColor = ColorOptions.Gold;
                break;
            case 4:
                selectedColor = ColorOptions.Translucent;
                break;
            
        }

    }
}