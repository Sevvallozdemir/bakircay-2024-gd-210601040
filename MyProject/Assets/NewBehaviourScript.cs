using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject objectPrefab;  // Yerlestirilecek obje prefab'�
    public int numberOfObjects = 10; // Oyun alan�na yerle�tirilecek obje say�s�
    public float spawnRange = 10f;   // Objelerin rastgele da��laca�� mesafe (x ve z eksenlerinde)

    void Start()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            // Rastgele pozisyon
            Vector3 randomPosition = new Vector3(
                Random.Range(-spawnRange, spawnRange), // x ekseni
                0.5f, // Y ekseni (objenin yerle�tirilece�i y�kseklik)
                Random.Range(-spawnRange, spawnRange)  // z ekseni
            );

            // Obje olu�turma
            Instantiate(objectPrefab, randomPosition, Quaternion.identity);
        }
    }
}
