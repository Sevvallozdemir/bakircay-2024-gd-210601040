using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject objectPrefab;  // Yerlestirilecek obje prefab'ý
    public int numberOfObjects = 10; // Oyun alanýna yerleþtirilecek obje sayýsý
    public float spawnRange = 10f;   // Objelerin rastgele daðýlacaðý mesafe (x ve z eksenlerinde)

    void Start()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            // Rastgele pozisyon
            Vector3 randomPosition = new Vector3(
                Random.Range(-spawnRange, spawnRange), // x ekseni
                0.5f, // Y ekseni (objenin yerleþtirileceði yükseklik)
                Random.Range(-spawnRange, spawnRange)  // z ekseni
            );

            // Obje oluþturma
            Instantiate(objectPrefab, randomPosition, Quaternion.identity);
        }
    }
}
