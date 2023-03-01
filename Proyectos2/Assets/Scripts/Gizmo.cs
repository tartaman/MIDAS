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
            gizmoTrans.SetActive(true);
            gizmoRotation.SetActive(false);
            if(seleccionado != null)
            {
                gizmoTrans.transform.position = seleccionado.transform.position;
            }

        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            rotation = true;
            transformation = false;
            gizmoTrans.SetActive(false);
            gizmoRotation.SetActive(true);
            if(seleccionado != null)
            {
                gizmoRotation.transform.position = new Vector3(seleccionado.transform.position.x + 1.1f, seleccionado.transform.position.y, seleccionado.transform.position.z);
                gizmoRotation.transform.rotation = seleccionado.transform.rotation;
               
            }
        }
        if (enMano && transformation)
        {
            seleccionado.transform.position = gizmoTrans.transform.position;
        }
        else if(enMano && rotation)
        {
            seleccionado.transform.rotation = gizmoRotation.transform.rotation;
        }

    }
      public void SetActivo(GameObject objeto)
    {
        seleccionado = objeto;
        enMano = true;
    }
    public char getState()
    {
        if (transformation)
            return 't';
        else
        {
            return 'r';
        }
    }
}
