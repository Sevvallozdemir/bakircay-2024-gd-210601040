using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Universalİnteraction : MonoBehaviour
{
    private Vector3 offset;
    private bool isDragging = false;

    void Update()
    {
        // Fare girişi
        if (Input.GetMouseButtonDown(0))
        {
            OnInputStart(Input.mousePosition);
        }
        else if (Input.GetMouseButton(0))
        {
            OnInputMove(Input.mousePosition);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            OnInputEnd();
        }

        // Dokunmatik ekran girişi
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    OnInputStart(touch.position);
                    break;
                case TouchPhase.Moved:
                    OnInputMove(touch.position);
                    break;
                case TouchPhase.Ended:
                    OnInputEnd();
                    break;
            }
        }
    }

    private void OnInputStart(Vector3 inputPosition)
    {
        Ray ray = Camera.main.ScreenPointToRay(inputPosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit) && hit.collider == GetComponent<Collider>())
        {
            offset = transform.position - GetWorldPosition(inputPosition);
            isDragging = true;
        }
    }

    private void OnInputMove(Vector3 inputPosition)
    {
        if (isDragging)
        {
            transform.position = GetWorldPosition(inputPosition) + offset;
        }
    }

    private void OnInputEnd()
    {
        isDragging = false;
    }

    private Vector3 GetWorldPosition(Vector3 inputPosition)
    {
        inputPosition.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(inputPosition);
    }
}