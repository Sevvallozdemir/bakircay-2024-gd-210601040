using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggableObject : MonoBehaviour
{
    private Vector3 offset; // Objeyi taþýrken fare veya dokunma pozisyonu ile obje arasýndaki mesafe
    private Camera mainCamera; // Oyun alanýndaki ana kamera
    private Rigidbody rb; // Objeye ait Rigidbody
    private float initialY; // Nesnenin baþlangýçtaki Y pozisyonu

    void Start()
    {
        mainCamera = Camera.main; // Ana kamerayý al
        rb = GetComponent<Rigidbody>(); // Rigidbody'yi al
        initialY = transform.position.y; // Baþlangýç Y pozisyonunu kaydet
    }

    void OnMouseDown()
    {
        // Fare týklandýðýnda veya dokunulduðunda objeyle fare arasýndaki farký hesapla
        Vector3 mouseWorldPosition = GetMouseWorldPosition();
        offset = transform.position - mouseWorldPosition;
        DisableGravity(); // Yerçekimini devre dýþý býrak
    }

    void OnMouseDrag()
    {
        // Fare sürüklendiðinde veya dokunma pozisyonu deðiþtiðinde objeyi hareket ettir
        Vector3 mouseWorldPosition = GetMouseWorldPosition();
        transform.position = mouseWorldPosition + offset;

        // Y pozisyonunu sabit tut
        Vector3 currentPosition = transform.position;
        currentPosition.y = initialY;
        transform.position = currentPosition;
    }

    void OnMouseUp()
    {
        // Nesne býrakýldýðýnda yerçekimini etkinleþtir
        EnableGravity();
    }

    private Vector3 GetMouseWorldPosition()
    {
        // Fare veya dokunmatik pozisyonunu dünya koordinatlarýna çevir
        Vector3 screenMousePosition = Input.mousePosition;
        screenMousePosition.z = mainCamera.WorldToScreenPoint(transform.position).z;
        return mainCamera.ScreenToWorldPoint(screenMousePosition);
    }

    // Yerçekimini devre dýþý býrak
    private void DisableGravity()
    {
        if (rb != null)
        {
            rb.useGravity = false;
        }
    }

    // Yerçekimini etkinleþtir
    private void EnableGravity()
    {
        if (rb != null)
        {
            rb.useGravity = true;
        }
    }

}
