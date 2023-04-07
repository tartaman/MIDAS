using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ScriptObjeto : MonoBehaviour
{
    Gizmo gizmoController;
    public Sprite preview;
    public int grupo;
    private Vector3 rotacion;
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
        
        GameObject.FindGameObjectWithTag("gizmo").transform.position = gameObject.transform.position;
        GameObject.FindGameObjectWithTag("gizmoRotation").transform.position = new Vector3(transform.position.x + 1.1f, transform.position.y, transform.position.z);
    }

    public void setRotation(Vector3 rotacion)
    {

    }

    public int getGrupo() => grupo;
    public Sprite GetImagen() => preview;
}
