using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover1 : MonoBehaviour
{
    Vector3 punto = Vector3.zero;
    Vector3 distancia;
    [SerializeField] GameObject gizmo;
    [SerializeField] GameObject objeto;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Vector3 mouseEntry = Input.mousePosition;
        Vector3 mousePos =Camera.main.ScreenToWorldPoint(mouseEntry);
        distancia = punto ;
    }
    private void OnMouseDrag()
    {
        Vector3 mouseEntry = Input.mousePosition;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(mouseEntry);
        transform.position = distancia;
    }
}
