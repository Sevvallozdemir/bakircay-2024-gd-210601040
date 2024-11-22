using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCylinderColor : MonoBehaviour
{
    // Silindirin rengini de�i�tirecek bir fonksiyon
    public void ChangeColor(Color newColor)
    {
        // Renderer bile�enini al
        Renderer cylinderRenderer = GetComponent<Renderer>();

        // Malzeme (Material) al ve rengini de�i�tir
        if (cylinderRenderer != null)
        {
            cylinderRenderer.material.color = newColor;
        }
    }

    void Start()
    {
        // Ba�lang��ta silindirin rengini k�rm�z� yap
        ChangeColor(Color.grey);
    }
}
