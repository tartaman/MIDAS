using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cuadricula : MonoBehaviour
{
    public int gridSize = 10; // tama�o de la cuadr�cula
    public GameObject planePrefab; // objeto de plano

    private Vector3 startPos; // posici�n inicial del mouse
    private Vector3 endPos; // posici�n final del mouse
    private GameObject currentPlane; // objeto de plano actual

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // si se hace clic con el bot�n izquierdo del mouse
        {
            // obtener la posici�n del mouse en el mundo y redondear a la cuadr�cula m�s cercana
            startPos = GetGridPosition();

            // instanciar el objeto de plano
            currentPlane = Instantiate(planePrefab, startPos, Quaternion.identity);
        }
        else if (Input.GetMouseButton(0)) // si se mantiene presionado el bot�n izquierdo del mouse
        {
            // obtener la posici�n del mouse en el mundo y redondear a la cuadr�cula m�s cercana
            endPos = GetGridPosition();

            // ajustar el tama�o del objeto de plano seg�n la posici�n del mouse
            float width = Mathf.Abs(endPos.x - startPos.x) + gridSize;
            float height = Mathf.Abs(endPos.z - startPos.z) + gridSize;

            currentPlane.transform.localScale = new Vector3(width, 0.01f, height);
        }
        else if (Input.GetMouseButtonUp(0)) // si se suelta el bot�n izquierdo del mouse
        {
            currentPlane = null; // eliminar el objeto de plano actual
        }
    }

    Vector3 GetGridPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            int x = Mathf.RoundToInt(hit.point.x / gridSize) * gridSize;
            int z = Mathf.RoundToInt(hit.point.z / gridSize) * gridSize;

            return new Vector3(x, 0, z);
        }

        return Vector3.zero;
    }

}
