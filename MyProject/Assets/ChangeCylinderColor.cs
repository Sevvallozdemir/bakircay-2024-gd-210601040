using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCylinderColor : MonoBehaviour
{
    // Silindirin rengini deðiþtirecek bir fonksiyon
    public void ChangeColor(Color newColor)
    {
        // Renderer bileþenini al
        Renderer cylinderRenderer = GetComponent<Renderer>();

        // Malzeme (Material) al ve rengini deðiþtir
        if (cylinderRenderer != null)
        {
            cylinderRenderer.material.color = newColor;
        }
    }

    void Start()
    {
        // Baþlangýçta silindirin rengini kýrmýzý yap
        ChangeColor(Color.grey);
    }
}
