using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuGrande : MonoBehaviour
{
    public GameObject panel;
    public GameObject UI;
   
    
    public void OprimirBoton()
    {
        if (!panel.activeSelf)
        {
            
            panel.SetActive(true);
            UI.SetActive(false);
        }
        else
        {
            
            panel.SetActive(false);
            UI.SetActive(true);
        }
        
    }
}
