using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.EventSystems;

public class CuadroObjeto : EventTrigger
{
    public int index;
    
    

    //Esta funci�n se llama al oprimir el bot�n del mouse sobre el cuadro, llamar� al script de Gizmo

    public override void OnPointerDown(PointerEventData data)
    {
        GameObject.FindGameObjectWithTag("helper").GetComponent<Gizmo>().setIndex(index);
    }



    //Es una mausque herramienta que nos ayudar� m�s tarde
    public void setIndex(int index)
    {
        this.index = index;
    }

    public int getIndex()
    {
        return this.index;
    }
    
}
