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
        
    }
   
}
