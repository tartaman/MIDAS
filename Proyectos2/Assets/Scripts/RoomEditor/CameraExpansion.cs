using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraExpansion : MonoBehaviour
{
    /*
    public GameObject objetoObjetivo; // Objeto al que se desea hacer zoom
    public float distanciaObjetivo = 5.0f; // Distancia objetivo de la c�mara al objeto

    void Update()
    {
        // Medir la distancia actual entre la c�mara y el objeto objetivo
        float distanciaActual = Vector3.Distance(transform.position, objetoObjetivo.transform.position);

        // Calcular la fracci�n de la distancia actual hacia el objetivo
        float fraccionDistancia = distanciaActual / distanciaObjetivo;

        // Interpolar gradualmente la distancia actual hacia el objetivo
        transform.position = Vector3.Lerp(transform.position, objetoObjetivo.transform.position  - Vector3.forward *10, fraccionDistancia);
    }
    */

    public float factorZoom;
    float scroll;
    private void Update()
    {
        scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 posicion = transform.position;
        posicion += transform.forward * scroll * factorZoom * Time.deltaTime;
        
        transform.position = posicion;
    }
}
