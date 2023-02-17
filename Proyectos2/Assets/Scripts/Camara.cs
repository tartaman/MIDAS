using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Camara : MonoBehaviour
{
    // Start is called before the first frame update
    public float velocidadCamara;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        MovCamara(x, y);
        RotateCamera();
    }

    private void MovCamara(float x, float y)
    {
        if (x != 0)
        {
            transform.Translate(Vector3.right * x * velocidadCamara * Time.deltaTime);
        }
        if (y != 0)
        {
            transform.Translate(Vector3.forward * y * velocidadCamara * Time.deltaTime);
        }
    }

    private void RotateCamera()
    {/*
        Vector3 mouse = Input.mousePosition;
        Vector3 mousePan = Camera.main.ScreenToViewportPoint(mouse);
        Debug.Log(mousePan);
        */

        if (Input.GetMouseButton(1))
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");
            transform.eulerAngles += (velocidadCamara/2) * new Vector3(-mouseY, mouseX, 0);
        }
    }
}
