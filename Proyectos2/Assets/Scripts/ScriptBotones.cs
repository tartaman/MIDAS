using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class ScriptBotones : MonoBehaviour
{
    Gizmo helper;
    public int grupo = 1;
    // Start is called before the first frame update
    void Start()
    {
        helper = GameObject.FindGameObjectWithTag("helper").GetComponent<Gizmo>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void boton()
    {
        helper.CambioBotones(grupo);
    }

}
