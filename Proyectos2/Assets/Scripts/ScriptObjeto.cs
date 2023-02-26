using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptObjeto : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    private void OnMouseDown()
    {
        GameObject.FindGameObjectWithTag("gizmo").GetComponent<Gizmo>().transform.position = gameObject.transform.position;
        GameObject.FindGameObjectWithTag("gizmo").GetComponent<Gizmo>().SetActivo(gameObject);
    }
}
