using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BotonEvent : MonoBehaviour
{
    // Start is called before the first frame update
    public int index;
    Gizmo helper;
    private void Awake()
    {
        helper = GameObject.FindGameObjectWithTag("helper").GetComponent<Gizmo>();
    }

    public void ChangeIndex()
    {
        helper.setIndex(index);

    }


    //Es una herramienta que nos ayudar� m�s tarde
    public void setIndex(int index)
    {
        this.index = index;
    }

    public int getIndex()
    {
        return this.index;
    }

}
