using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlacement : MonoBehaviour
{
    public Transform placementArea; // Yerle�tirme alan�
    private bool isPlaced = false;

    void Update()
    {
        if (isPlaced) return; // E�er obje zaten yerle�tirilmi�se, ba�ka bir �ey yapma

        // Objeyi s�r�kleyerek yerle�tir
        if (Input.GetMouseButtonDown(0)) // Sa� t�k ile objeyi al
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Vector3 position = hit.point;
                if (Vector3.Distance(position, placementArea.position) <= 5f)
                {
                    transform.position = position; // Objeyi yerle�tirme alan�na koy
                    isPlaced = true;
                }
            }
        }
    }
}
