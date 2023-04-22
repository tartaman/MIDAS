using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ScriptObjeto : MonoBehaviour
{
    Gizmo gizmoController;
    public Sprite preview;
    public int grupo;
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
        
    }

    public void setRotation(Vector3 rotacion)
    {

    }

    public int getGrupo() => grupo;
    public Sprite GetImagen() => preview;
}
