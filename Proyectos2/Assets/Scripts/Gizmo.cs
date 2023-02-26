using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gizmo : MonoBehaviour
{
    public GameObject seleccionado;
    private bool enMano;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enMano)
        {
            seleccionado.transform.position = transform.position;
        }
    }
    public void SetActivo(GameObject objeto)
    {
        seleccionado = objeto;
        enMano = true;
    }
}
