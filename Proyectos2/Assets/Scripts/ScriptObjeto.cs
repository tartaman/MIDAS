using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class ScriptObjeto : MonoBehaviour, IPointerClickHandler
{
    Gizmo gizmoController;
    public Sprite preview;
    public int grupo;
    void Start()
    {
        gizmoController = GameObject.FindGameObjectWithTag("helper").GetComponent<Gizmo>();
        
    }


    public void setRotation(Vector3 rotacion)
    {

    }

    public int getGrupo() => grupo;
    public Sprite GetImagen() => preview;

    public void OnPointerClick(PointerEventData eventData)
    {
        gizmoController.SetActivo(gameObject);
    }
}
