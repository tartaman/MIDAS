using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Collider))]
public class DragAndResize : MonoBehaviour
{
    public Transform WorldAnchor;
    private Camera mainCamera;
    private float CameraZdistance;
    private Vector3 InitialScale;

    private void Start()
    {
        InitialScale = transform.localScale;
        mainCamera = Camera.main;
        CameraZdistance = mainCamera.WorldToScreenPoint(transform.position).z;
    }
    private void OnMouseDrag()
    {
       
        Vector3 MouseScreenPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, CameraZdistance); 
        Vector3 MouseWorldPosition = mainCamera.ScreenToWorldPoint(MouseScreenPosition); 

       
        float distance = Vector2.Distance(WorldAnchor.position, MouseWorldPosition) ; 
        transform.localScale = new Vector3(InitialScale.x, distance / 2f, InitialScale.z);
        Vector2 middlePoint = (WorldAnchor.position + MouseWorldPosition) / 2; 
        transform.position = middlePoint;

        Vector3 rotationDirection = (MouseWorldPosition - WorldAnchor.position); //Change Rotation
        transform.up = rotationDirection;

    }
}
