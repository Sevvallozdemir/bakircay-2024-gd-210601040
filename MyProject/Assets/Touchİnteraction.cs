using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touchİnteraction : MonoBehaviour
{
    private Vector3 offset;
    private bool isDragging = false;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit hit;

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    // Dokunma başladığında objeyi seç
                    if (Physics.Raycast(ray, out hit) && hit.collider == GetComponent<Collider>())
                    {
                        Vector3 touchPosition = GetTouchWorldPosition(touch.position);
                        offset = transform.position - touchPosition;
                        isDragging = true;
                    }
                    break;

                case TouchPhase.Moved:
                    // Dokunma hareketi sırasında objeyi taşı
                    if (isDragging)
                    {
                        Vector3 touchPosition = GetTouchWorldPosition(touch.position);
                        transform.position = touchPosition + offset;
                    }
                    break;

                case TouchPhase.Ended:
                    isDragging = false; // Dokunma sona erdiğinde objeyi bırak
                    break;
            }
        }
    }

    private Vector3 GetTouchWorldPosition(Vector2 touchPosition)
    {
        Vector3 touchScreenPosition = new Vector3(touchPosition.x, touchPosition.y, Camera.main.WorldToScreenPoint(transform.position).z);
        return Camera.main.ScreenToWorldPoint(touchScreenPosition);
    }
}