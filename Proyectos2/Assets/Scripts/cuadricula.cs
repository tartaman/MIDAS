using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cuadricula : MonoBehaviour
{
    public int gridSize = 10; // tamaño de la cuadrícula
    public GameObject planePrefab; // objeto de plano

    private Vector3 startPos; // posición inicial del mouse
    private Vector3 endPos; // posición final del mouse
    private GameObject currentPlane; // objeto de plano actual

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // si se hace clic con el botón izquierdo del mouse
        {
            // obtener la posición del mouse en el mundo y redondear a la cuadrícula más cercana
            startPos = GetGridPosition();

            // instanciar el objeto de plano
            currentPlane = Instantiate(planePrefab, startPos, Quaternion.identity);
        }
        else if (Input.GetMouseButton(0)) // si se mantiene presionado el botón izquierdo del mouse
        {
            // obtener la posición del mouse en el mundo y redondear a la cuadrícula más cercana
            endPos = GetGridPosition();

            // ajustar el tamaño del objeto de plano según la posición del mouse
            float width = Mathf.Abs(endPos.x - startPos.x) + gridSize;
            float height = Mathf.Abs(endPos.z - startPos.z) + gridSize;

            currentPlane.transform.localScale = new Vector3(width, 0.01f, height);
        }
        else if (Input.GetMouseButtonUp(0)) // si se suelta el botón izquierdo del mouse
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
