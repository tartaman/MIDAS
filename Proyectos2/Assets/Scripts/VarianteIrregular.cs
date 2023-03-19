using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class VarianteIrregular : MonoBehaviour
{
    Gizmo gizmoController;
    void Start()
    {
        gizmoController = GameObject.FindGameObjectWithTag("helper").GetComponent<Gizmo>();
        
    }
    public void MouseIrregular()
    {
        gizmoController.SetActivo(gameObject.transform.parent.gameObject);
        if (gizmoController.getState() == 't')
        {
            GameObject.FindGameObjectWithTag("gizmo").transform.position = gameObject.transform.parent.gameObject.transform.position;
        }
        else
        {
            GameObject.FindGameObjectWithTag("gizmoRotation").transform.position = new Vector3(transform.position.x + 1.1f, transform.position.y, transform.position.z);

        }
    }
   
}
