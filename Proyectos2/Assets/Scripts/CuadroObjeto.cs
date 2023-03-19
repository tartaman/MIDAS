using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.EventSystems;

public class CuadroObjeto : EventTrigger
{
    public int index;
    
    

    //Esta función se llama al oprimir el botón del mouse sobre el cuadro, llamará al script de Gizmo

    public override void OnPointerDown(PointerEventData data)
    {
        GameObject.FindGameObjectWithTag("helper").GetComponent<Gizmo>().setIndex(index);
    }



    //Es una mausque herramienta que nos ayudará más tarde
    public void setIndex(int index)
    {
        this.index = index;
    }

    public int getIndex()
    {
        return this.index;
    }
    
}
