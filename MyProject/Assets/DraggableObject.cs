using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggableObject : MonoBehaviour
{
    private Vector3 offset; // Objeyi ta��rken fare veya dokunma pozisyonu ile obje aras�ndaki mesafe
    private Camera mainCamera; // Oyun alan�ndaki ana kamera
    private Rigidbody rb; // Objeye ait Rigidbody
    private float initialY; // Nesnenin ba�lang��taki Y pozisyonu

    void Start()
    {
        mainCamera = Camera.main; // Ana kameray� al
        rb = GetComponent<Rigidbody>(); // Rigidbody'yi al
        initialY = transform.position.y; // Ba�lang�� Y pozisyonunu kaydet
    }

    void OnMouseDown()
    {
        // Fare t�kland���nda veya dokunuldu�unda objeyle fare aras�ndaki fark� hesapla
        Vector3 mouseWorldPosition = GetMouseWorldPosition();
        offset = transform.position - mouseWorldPosition;
        DisableGravity(); // Yer�ekimini devre d��� b�rak
    }

    void OnMouseDrag()
    {
        // Fare s�r�klendi�inde veya dokunma pozisyonu de�i�ti�inde objeyi hareket ettir
        Vector3 mouseWorldPosition = GetMouseWorldPosition();
        transform.position = mouseWorldPosition + offset;

        // Y pozisyonunu sabit tut
        Vector3 currentPosition = transform.position;
        currentPosition.y = initialY;
        transform.position = currentPosition;
    }

    void OnMouseUp()
    {
        // Nesne b�rak�ld���nda yer�ekimini etkinle�tir
        EnableGravity();
    }

    private Vector3 GetMouseWorldPosition()
    {
        // Fare veya dokunmatik pozisyonunu d�nya koordinatlar�na �evir
        Vector3 screenMousePosition = Input.mousePosition;
        screenMousePosition.z = mainCamera.WorldToScreenPoint(transform.position).z;
        return mainCamera.ScreenToWorldPoint(screenMousePosition);
    }

    // Yer�ekimini devre d��� b�rak
    private void DisableGravity()
    {
        if (rb != null)
        {
            rb.useGravity = false;
        }
    }

    // Yer�ekimini etkinle�tir
    private void EnableGravity()
    {
        if (rb != null)
        {
            rb.useGravity = true;
        }
    }

}
