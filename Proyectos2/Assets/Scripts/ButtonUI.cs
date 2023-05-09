using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonUI : MonoBehaviour
{
  
   
    private Gizmo helper;
    
    private MenuGrande MenuGrande;
    [SerializeField]private GameObject menu;
    [SerializeField] private GameObject gizmoTrans;
    [SerializeField] private GameObject aviso;
    string mode;


    bool mover;
    // Start is called before the first frame update
    void Start()
    {
        helper = GetComponent<Gizmo>();
        MenuGrande = GetComponent<MenuGrande>();
        
    }

    //Cambiar comodin
    public void Change(string mode)
    {
        if(helper.GetActivo().gameObject.name != "Helper")
        {
            if(mode == "eliminar")
            {
                this.mode = "mover";
                GameObject objetoADestruir = helper.GetActivo();
                helper.SetActivo(helper.gameObject);
                Destroy(objetoADestruir);
                menu.transform.Find("ChangeValues").gameObject.SetActive(false);
                menu.transform.Find("ColorShowCase").gameObject.SetActive(false);
                menu.transform.Find("Scroll").gameObject.SetActive(true);
                
            }
            else
            {
                menu.transform.Find("Scroll").gameObject.SetActive(false);
                if (mode != "color")
                {
                    menu.transform.Find("ChangeValues").gameObject.SetActive(true);
                    menu.transform.Find("ColorShowCase").gameObject.SetActive(false);
                    this.mode = mode;
                    if (mode == "mover")
                    {
                        menu.transform.Find("ChangeValues/Texto").GetComponent<Text>().text = "Mover";
                        menu.transform.Find("ChangeValues/X").GetComponent<Text>().text = "Posición en X";
                        menu.transform.Find("ChangeValues/Y").GetComponent<Text>().text = "Posición en Y";
                        menu.transform.Find("ChangeValues/Z").GetComponent<Text>().text = "Posición en Z";
                        Vector3 objeto = GetComponent<Gizmo>().GetActivo().transform.position;
                        ChangeValues(objeto);
                    }
                    else if (mode == "rotar")
                    {
                        menu.transform.Find("ChangeValues/Texto").GetComponent<Text>().text = "Rotar";
                        menu.transform.Find("ChangeValues/X").GetComponent<Text>().text = "Rotación en X";
                        menu.transform.Find("ChangeValues/Y").GetComponent<Text>().text = "Rotación en Y";
                        menu.transform.Find("ChangeValues/Z").GetComponent<Text>().text = "Rotación en Z";
                        Vector3 objeto = GetComponent<Gizmo>().GetActivo().transform.localEulerAngles;
                        ChangeValues(objeto);
                    }
                }
                else
                {
                    menu.transform.Find("ColorShowCase").gameObject.SetActive(true);
                    menu.transform.Find("ChangeValues").gameObject.SetActive(false);
                    this.mode = mode;
                    helper.GetMeshes();
                }
            }
          
            
        }
        else
        {
            if (!aviso.activeSelf)
                aviso.SetActive(true);
        }

    }
    //Relacionado al boton de mover
    public void ChangeValues(Vector3 objeto)
    {
        if(mode == "rotar")
        {
            menu.transform.Find("ChangeValues/X/InputField").GetComponent<InputField>().text = objeto.y.ToString();
            menu.transform.Find("ChangeValues/Y/InputField").GetComponent<InputField>().text = objeto.x.ToString();
            menu.transform.Find("ChangeValues/Z/InputField").GetComponent<InputField>().text = objeto.z.ToString();
        }
        else if( mode == "mover")
        {
            menu.transform.Find("ChangeValues/X/InputField").GetComponent<InputField>().text = objeto.x.ToString();
            menu.transform.Find("ChangeValues/Y/InputField").GetComponent<InputField>().text = objeto.y.ToString();
            menu.transform.Find("ChangeValues/Z/InputField").GetComponent<InputField>().text = objeto.z.ToString();
        }
        
    }

    public void InputMover(string eje)
    {
        if(mode == "mover")
        {
            switch (eje)
            {
                case "X":
                    gizmoTrans.transform.position = new Vector3(float.Parse(menu.transform.Find("ChangeValues/X/InputField").GetComponent<InputField>().text), helper.GetActivo().gameObject.transform.position.y, helper.GetActivo().gameObject.transform.position.z);
                    break;
                case "Y":
                    gizmoTrans.transform.position = new Vector3(helper.GetActivo().gameObject.transform.position.x, float.Parse(menu.transform.Find("ChangeValues/Y/InputField").GetComponent<InputField>().text), helper.GetActivo().gameObject.transform.position.z);
                    break;
                case "Z":
                    gizmoTrans.transform.position = new Vector3(helper.GetActivo().gameObject.transform.position.x, helper.GetActivo().gameObject.transform.position.y, float.Parse(menu.transform.Find("ChangeValues/Z/InputField").GetComponent<InputField>().text));
                    break;
                default:
                    break;
            }
        }
        else if(mode == "rotar"){

            GameObject objeto = helper.GetActivo();
            Vector3 rotacion = new Vector3(float.Parse(menu.transform.Find("ChangeValues/Y/InputField").GetComponent<InputField>().text), float.Parse(menu.transform.Find("ChangeValues/X/InputField").GetComponent<InputField>().text), float.Parse(menu.transform.Find("ChangeValues/Z/InputField").GetComponent<InputField>().text));
            objeto.transform.rotation = Quaternion.Euler(rotacion);
            

        }
        

    }

    //Relacionado al boton de rotar
    public void ChangeValuesRotar(Vector3 objeto)
    {
        
        menu.transform.Find("ChangeValues/X/InputField").GetComponent<InputField>().text = objeto.x.ToString();
        menu.transform.Find("ChangeValues/Y/InputField").GetComponent<InputField>().text = objeto.y.ToString();
        menu.transform.Find("ChangeValues/Z/InputField").GetComponent<InputField>().text = objeto.z.ToString();
    }

    public string GetMode()=> mode;
    


    //Cambiar botones en la UI
    public void cambiar(int grupo)
    {
        helper.CambioBotones(grupo);
        MenuGrande.OprimirBoton();
        if (!menu.transform.Find("Scroll").gameObject.activeSelf)
        {
            menu.transform.Find("Scroll").gameObject.SetActive(true);
            menu.transform.Find("ChangeValues").gameObject.SetActive(false);
            menu.transform.Find("ColorShowCase").gameObject.SetActive(false);
        }
    }
}
