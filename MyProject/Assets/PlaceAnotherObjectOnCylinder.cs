using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlacer : MonoBehaviour
{
    private float lastPlacedHeight = 0f; // Son yerleştirilen cismin Y pozisyonu

    // Nesneyi silindirin üstüne yerleştiren metod
    public void PlaceObjectOnCylinder(GameObject objectToPlace, GameObject cylinder)
    {
        // Silindirin yüksekliğini al (silindirin Y eksenindeki boyutu)
        float cylinderHeight = cylinder.transform.localScale.y;

        // Y pozisyonunu ayarla
        Vector3 objectPosition = objectToPlace.transform.position;
        objectPosition.y = cylinder.transform.position.y + (cylinderHeight / 2) + lastPlacedHeight;

        // Yeni yerleştirilen cismin yüksekliğini güncelle
        lastPlacedHeight += objectToPlace.transform.localScale.y;

        // Nesneyi yerleştir
        objectToPlace.transform.position = objectPosition;
    }
}
