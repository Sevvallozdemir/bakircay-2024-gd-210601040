using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlacer : MonoBehaviour
{
    private float lastPlacedHeight = 0f; // Son yerleþtirilen cismin Y pozisyonu

    // Nesneyi silindirin üstüne yerleþtiren metod
    public void PlaceObjectOnCylinder(GameObject objectToPlace, GameObject cylinder)
    {
        // Silindirin yüksekliðini al (silindirin Y eksenindeki boyutu)
        float cylinderHeight = cylinder.transform.localScale.y;

        // Y pozisyonunu ayarla
        Vector3 objectPosition = objectToPlace.transform.position;
        objectPosition.y = cylinder.transform.position.y + (cylinderHeight / 2) + lastPlacedHeight;

        // Yeni yerleþtirilen cismin yüksekliðini güncelle
        lastPlacedHeight += objectToPlace.transform.localScale.y;

        // Nesneyi yerleþtir
        objectToPlace.transform.position = objectPosition;
    }
}
