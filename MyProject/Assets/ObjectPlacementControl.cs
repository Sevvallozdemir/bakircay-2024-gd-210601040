using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlacementControl : MonoBehaviour
{
    public Transform placementArea; // Yerle�tirme alan�n�n referans�
    public float placementRadius = 5f; // Yerle�tirme alan�n�n yar��ap�
    private bool isPlaced = false;

    void OnMouseUp()
    {
        if (!isPlaced)
        {
            // Obje yerle�tirme alan�nda m�?
            if (Vector3.Distance(transform.position, placementArea.position) <= placementRadius)
            {
                // Objeyi yerle�tirme alan�na hizala
                transform.position = placementArea.position;
                isPlaced = true;
                Debug.Log("Obje ba�ar�yla yerle�tirildi!");
            }
            else
            {
                Debug.Log("Obje yerle�tirme alan�n�n d���nda!");
            }
        }
    }
}
