using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlacement : MonoBehaviour
{
    public Transform placementArea; // Yerleþtirme alaný
    private bool isPlaced = false;

    void Update()
    {
        if (isPlaced) return; // Eðer obje zaten yerleþtirilmiþse, baþka bir þey yapma

        // Objeyi sürükleyerek yerleþtir
        if (Input.GetMouseButtonDown(0)) // Sað týk ile objeyi al
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Vector3 position = hit.point;
                if (Vector3.Distance(position, placementArea.position) <= 5f)
                {
                    transform.position = position; // Objeyi yerleþtirme alanýna koy
                    isPlaced = true;
                }
            }
        }
    }
}
