using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuGrande : MonoBehaviour
{
    public GameObject panel;
    public GameObject UI;
    private bool pressed;
    
    public void OprimirBoton()
    {
        if (!pressed)
        {
            pressed = true;
            panel.SetActive(true);
            UI.SetActive(false);
        }
        else
        {
            pressed = false;
            panel.SetActive(false);
            UI.SetActive(true);
        }
        
    }
}
