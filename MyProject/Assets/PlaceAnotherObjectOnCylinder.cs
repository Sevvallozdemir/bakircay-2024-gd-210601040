using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlacer : MonoBehaviour
{
    private float lastPlacedHeight = 0f; // Son yerle�tirilen cismin Y pozisyonu

    // Nesneyi silindirin �st�ne yerle�tiren metod
    public void PlaceObjectOnCylinder(GameObject objectToPlace, GameObject cylinder)
    {
        // Silindirin y�ksekli�ini al (silindirin Y eksenindeki boyutu)
        float cylinderHeight = cylinder.transform.localScale.y;

        // Y pozisyonunu ayarla
        Vector3 objectPosition = objectToPlace.transform.position;
        objectPosition.y = cylinder.transform.position.y + (cylinderHeight / 2) + lastPlacedHeight;

        // Yeni yerle�tirilen cismin y�ksekli�ini g�ncelle
        lastPlacedHeight += objectToPlace.transform.localScale.y;

        // Nesneyi yerle�tir
        objectToPlace.transform.position = objectPosition;
    }
}
