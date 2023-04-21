using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BotonEvent : MonoBehaviour
{
    // Start is called before the first frame update
    public int index;

    public void ChangeIndex()
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
