using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objectİnteraction : MonoBehaviour
{
    private Vector3 offset; // Objenin fare ile tutulduğu nokta
    private bool isDragging = false;

    void OnMouseDown()
    {
        // Objenin tutulan noktasını hesapla
        Vector3 mousePosition = GetMouseWorldPosition();
        offset = transform.position - mousePosition;
        isDragging = true;
    }

    void OnMouseDrag()
    {
        if (isDragging)
        {
            // Fare pozisyonunu al ve objeyi taşı
            Vector3 mousePosition = GetMouseWorldPosition();
            transform.position = mousePosition + offset;
        }
    }

    void OnMouseUp()
    {
        isDragging = false; // Objeyi bırak
    }

    // Fare pozisyonunu dünya koordinatlarına çevir
    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mouseScreenPosition = Input.mousePosition;
        mouseScreenPosition.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mouseScreenPosition);
    }
}
