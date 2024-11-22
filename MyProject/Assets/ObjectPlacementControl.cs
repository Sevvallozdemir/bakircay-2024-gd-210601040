using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlacementControl : MonoBehaviour
{
    public Transform placementArea; // Yerleþtirme alanýnýn referansý
    public float placementRadius = 5f; // Yerleþtirme alanýnýn yarýçapý
    private bool isPlaced = false;

    void OnMouseUp()
    {
        if (!isPlaced)
        {
            // Obje yerleþtirme alanýnda mý?
            if (Vector3.Distance(transform.position, placementArea.position) <= placementRadius)
            {
                // Objeyi yerleþtirme alanýna hizala
                transform.position = placementArea.position;
                isPlaced = true;
                Debug.Log("Obje baþarýyla yerleþtirildi!");
            }
            else
            {
                Debug.Log("Obje yerleþtirme alanýnýn dýþýnda!");
            }
        }
    }
}
