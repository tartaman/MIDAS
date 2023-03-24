using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonUI : MonoBehaviour
{
  
   
    private Gizmo helper;
    private MenuGrande MenuGrande;
    // Start is called before the first frame update
    void Start()
    {
        helper = GetComponent<Gizmo>();
        MenuGrande = GetComponent<MenuGrande>();
    }

    // Update is called once per frame
    
    public void cambiar(int grupo)
    {
        helper.CambioBotones(grupo);
        MenuGrande.OprimirBoton();
    }
}
