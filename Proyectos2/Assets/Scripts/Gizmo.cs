using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gizmo : MonoBehaviour
{
    public GameObject seleccionado;
    public GameObject gizmoTrans;
    public GameObject gizmoRotation;
    private bool enMano;
    private bool transformation = true;
    private bool rotation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            transformation = true;
            rotation = false;
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            rotation = true;
            transformation = false;
        }
        if (enMano && transformation)
        {
            seleccionado.transform.position = gizmoTrans.transform.position;
        }

    }
    public void SetActivo(GameObject objeto)
    {
        seleccionado = objeto;
        enMano = true;
    }
}
