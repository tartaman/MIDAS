using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptObjeto : MonoBehaviour
{
    Gizmo gizmoController;
    void Start()
    {
        gizmoController = GameObject.FindGameObjectWithTag("helper").GetComponent<Gizmo>();
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    private void OnMouseDown()
    {
        gizmoController.SetActivo(gameObject);
        if(gizmoController.getState() == 't')
        {
            GameObject.FindGameObjectWithTag("gizmo").transform.position = gameObject.transform.position;
        }
        else
        {
            GameObject.FindGameObjectWithTag("gizmoRotation").transform.position = new Vector3(transform.position.x + 1.1f, transform.position.y, transform.position.z);
            
        }


    }
}
