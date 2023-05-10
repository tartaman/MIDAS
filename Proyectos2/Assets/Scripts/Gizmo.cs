
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Gizmo : MonoBehaviour
{
    //Por ahora todas estarán en public para que podamos checar como funcionan desde unity
    [Header("Cosas relacionadas a Colocar objetos")]
    public GameObject[] objetos;
    public int[] grupos;
    public int selectedIndex = -1;
    public Collider piso;
    public float distance;

    private RaycastHit hit;
    private Ray ray;

    [Header("Comodin")]
    public GameObject seleccionado;

    [Header("Cosas relacionadas a Gizmos")]
    [SerializeField] GameObject gizmoTransGO;
    [SerializeField] GameObject gizmoRotGO;
    [SerializeField] GameObject gizmoEscala;
    public GameObject gizmoTrans;
    public GameObject gizmoRotation;
    public char ejeR;

    [Header("Cosas relacionadas a Botones")]
    public GameObject contenido;
    public GameObject cuadro;
    public ButtonUI manual;


    [Header("Bools")]
    public bool enMano;
    public bool transformation = true;
    public bool rotation;
    public bool rotando;
    public bool escala;
    [SerializeField] bool puedeArrastrar = true;
    [SerializeField] bool arrastrando;
    private bool irregularChecked;
    private bool tocado;

    [Header("Cosas relacionadas a Cambios de color")]
    [SerializeField] GameObject ColorShowButton;
    [SerializeField] GameObject contenidoColor;
    [SerializeField] GameObject ColorPalette;
    [SerializeField] ColorPickerController ColorPickerController;
    //private MeshRenderer[] meshes;
    //[SerializeField] private List< MeshRenderer> Meshes;


    private void Awake()
    {
        puedeArrastrar = true;
        selectedIndex = -1;
        piso = GameObject.FindGameObjectWithTag("suelo").GetComponent<BoxCollider>();
        objetos = MergeSort(objetos);
        CambioBotones(1);
        manual = GetComponent<ButtonUI>();
        ColorPickerController = ColorPalette.GetComponent<ColorPickerController>();
    }

    
    void LateUpdate()
    {
        //si no esta intentando poner un objeto
        if (!arrastrando)
        {
            Gizmos();
        }
        else if( arrastrando && puedeArrastrar && seleccionado!= null)

        {
            //Si está oprimiendo botón izquierdo y no lo suelta
            if (Input.GetMouseButton(0))
            {
                seleccionado.transform.position = setPosition();
            }
            //Si sielta el botón izquierdo del mouse
            if (Input.GetMouseButtonUp(0))
            {
                arrastrando = false;
                if (seleccionado.transform.position == new Vector3(999, 999, 999))
                {
                    Destroy(seleccionado);
                    seleccionado = null;
                }
                else
                {
                    gizmoTrans.transform.position = seleccionado.transform.position;
                    enMano = true;
                    ActualGizmo();
                    
                }

                irregularChecked = false;
                selectedIndex = -1;

            }

        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            gizmoTransGO.SetActive(false);
            gizmoRotGO.SetActive(false);
            gizmoEscala.SetActive(false);

        }
      
    }

    // Relacionado a el funcionamiento de gizmos
    public void SetActivo(GameObject objeto)
    {
        
        seleccionado = objeto;
        ActualGizmo();
        enMano = true;
        string mode = manual.GetMode();

        if (mode == "mover")
        {
            manual.ChangeValues(seleccionado.transform.position);
        }
        else if (mode == "rotar")
        {
            manual.ChangeValues(seleccionado.transform.localEulerAngles);
        }
        else if (mode == "color")
        {
            GetMeshes();
        }
        
    }

    public GameObject GetActivo() => seleccionado;


    private void ActualGizmo()
    {
        if (transformation)
        {
            gizmoTransGO.SetActive(true);
            gizmoTrans.transform.position = seleccionado.transform.position;
        }
        else if (rotation)
        {
            gizmoRotGO.SetActive(true);
            gizmoRotation.transform.position = new Vector3(seleccionado.transform.position.x + 1.1f, seleccionado.transform.position.y, seleccionado.transform.position.z);

        }
        else if (escala)
        {
            gizmoEscala.SetActive(true);
            gizmoEscala.transform.position = seleccionado.transform.position;
            DesignarEscala();

        }
    }


    private void Gizmos()
    {
        //Si oprime T el gizmo a usar es el de transfromación, quiza luego lo cambie a un botón que se active con mouse

        if (Input.GetKeyDown(KeyCode.T))
            ActivateTrans();
        //Si oprime R pus el rotar
        else if (Input.GetKeyDown(KeyCode.R))
            ActivateRot();
        else if (Input.GetKeyDown(KeyCode.E))
        {
            ActivateEsc();
            DesignarEscala();
        }
        //toDO Falta agregar el gizmo de escala

        //Esto es solo para adaptar los gizmos al mueble
        if (enMano && transformation)
        {
            seleccionado.transform.position = gizmoTrans.transform.position;

        }
        else if (enMano && rotation && rotando)
        {
            if (ejeR == 'x')
            {
                seleccionado.transform.localRotation *= Quaternion.Euler(gizmoRotation.transform.rotation.x, 0, 0);
            }
            else if (ejeR == 'z')
            {
                seleccionado.transform.localRotation *= Quaternion.Euler(0, 0, gizmoRotation.transform.rotation.z);
            }
            else if (ejeR == 'y')
            {
                seleccionado.transform.localRotation *= Quaternion.Euler(0, gizmoRotation.transform.rotation.y, 0);

            }

        }
    }

    public void ActivateTrans()
    {
        transformation = true;
        rotation = false;
        escala = false;
        gizmoTrans.SetActive(true);
        gizmoRotation.SetActive(false);
        gizmoEscala.SetActive(false);
        if (seleccionado != null)
        {
            gizmoTrans.transform.position = seleccionado.transform.position;
        }
    }

    public void ActivateRot()
    {
        rotation = true;
        transformation = false;
        escala = false;
        gizmoTrans.SetActive(false);
        gizmoRotation.SetActive(true);
        gizmoEscala.SetActive(false);
        if (seleccionado != null)
        {
            gizmoRotation.transform.position = new Vector3(seleccionado.transform.position.x + 1.1f, seleccionado.transform.position.y, seleccionado.transform.position.z);
        }
    }

    public void ActivateEsc()
    {
        escala = true;
        rotation = false;
        transformation = false;
        gizmoTrans.SetActive(false);
        gizmoRotation.SetActive(false);
        gizmoEscala.SetActive(true);
        if (seleccionado != null)
        {
            gizmoEscala.transform.position = seleccionado.transform.position;
        }
    }


    public char getState()
    {
        if (transformation)
            return 't';
        else if(rotation)
        {
            return 'r';
        }
        else
        {
            return 'e';
        }
    }

    private void DesignarEscala()
    {
        gizmoEscala.GetComponent<ScaleGizmo>().SetSeleccionado(seleccionado);
        foreach(Transform t in gizmoEscala.transform)
        {
            t.gameObject.transform.GetChild(0).GetComponent<ScaleGizmo>().SetSeleccionado(seleccionado);
        }
    } 

    //Cosas relacionadas al funcionamiento de colocar objetos

    //Los muebles llaman a esta función para que le den el index
    public void setIndex(int index)
    {
        if (puedeArrastrar)
        {
           
            selectedIndex = index;
            seleccionado = Instantiate(objetos[selectedIndex], setPosition(), new Quaternion(0, 0, 0, 0));
            arrastrando = true;
        }
        
    }

    Vector3 lastpos = new Vector3(999, 999, 999);
    private Vector3 setPosition()
    {

        gizmoTransGO.SetActive(false);
        gizmoRotGO.SetActive(false);
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider == piso)
            {
                if (seleccionado.GetComponent<Collider>() == null && !irregularChecked && seleccionado.name != "Helper")
                {
                    irregularChecked = true;
                    var child = seleccionado.transform.GetChild(0);
                    foreach (Transform hijo in child)
                    {
                        if (hijo.GetComponent<Collider>() != null)
                        {
                            distance = hijo.GetComponent<Collider>().bounds.center.y - hijo.GetComponent<Collider>().bounds.min.y;
                        }
                    }
                }
                else if (seleccionado.GetComponent<Collider>() != null)
                {
                    distance = seleccionado.GetComponent<Collider>().bounds.center.y - seleccionado.GetComponent<Collider>().bounds.min.y + 0.1f;

                }
                lastpos = new Vector3(hit.point.x, distance, hit.point.z);
            }
        }
        return lastpos;
    }

    public void BloqDrag(bool state)
    {
        puedeArrastrar = state;
    }

    public void setRotando(bool rotation, char eje)
    {
        rotando = rotation;
        ejeR = eje;
    }


    //Ordenar el arreglo dependiendo el grupo
    private  GameObject[] MergeSort(GameObject[] Arr)
    {
        if (Arr.Length < 2)
        {
            return Arr;
        }
        else
        {
            int mitad = Arr.Length / 2;
            GameObject[] izquierda = MergeSort(Arr.Take(mitad).ToArray());
            GameObject[] derecha = MergeSort(Arr.Skip(mitad).ToArray());
            return Merge(izquierda, derecha);
        }
    }
    private  GameObject[] Merge(GameObject[] izq, GameObject[] der)
    {
        int i = 0;
        int j = 0;
        GameObject[] respuesta = { };
        while (i < izq.Length && j < der.Length)
        {
            
            if (izq[i].GetComponent<ScriptObjeto>().getGrupo() < der[j].GetComponent<ScriptObjeto>().getGrupo())
            {
                respuesta = respuesta.Append(izq[i]).ToArray();
                
                i++;
            }
            else
            {
                respuesta = respuesta.Append(der[j]).ToArray();
                
                j++;
            }
        }
        respuesta = respuesta.Concat(izq.Skip(i)).ToArray();
        respuesta = respuesta.Concat(der.Skip(j)).ToArray();
        

        return respuesta;
    }

    //Hallar rangos
     private (int, int) BuscarLim(GameObject[] array, int x)
    {
        Debug.Log(x);
        int pivote = binarySearch(array, 0, array.Length - 1, x);
        Debug.Log(pivote);
        int limInf = 0;
        int limSup = array.Length - 1;
        for (int i = pivote; i >= 0; i--)
        {
            if (array[i].GetComponent<ScriptObjeto>().getGrupo() == x)
            {
                limInf = i;
            }
        }
        for (int i = pivote; i < array.Length; i++)
        {
            if (array[i].GetComponent<ScriptObjeto>().getGrupo() == x)
            {
                limSup = i;
            }
        }
        return (limInf, limSup);

     }

   private int binarySearch(GameObject[] array, int l, int h, int x)
   {
        int mid;
        if (h >= 1)
        {
            while (l <= h)
            {
                mid = (l + h) / 2;
                if (array[mid].GetComponent<ScriptObjeto>().getGrupo() == x)
                {
                    return mid;
                }
                else if (array[mid].GetComponent<ScriptObjeto>().getGrupo() < x)
                {
                    l = mid + 1;
                }
                else
                {
                    h = mid - 1;
                }
            }

        }
        return -1;
   }
    
    //cambio de botones
    public void CambioBotones(int grupo)
    {
        Debug.Log("num" + grupo);
        var limites = BuscarLim(objetos, grupo);
        foreach(Transform hijo in contenido.transform)
        {
            Destroy(hijo.gameObject);
        }
        Debug.Log(limites);
        
        for(int i = limites.Item1; i<= limites.Item2;i++)
        {

            GameObject cuadrito = Instantiate(cuadro, contenido.transform);
            //cuadrito.GetComponent<CuadroObjeto>().setIndex(i);
            cuadrito.GetComponent<BotonEvent>().setIndex(i);
            cuadrito.transform.GetChild(0).GetComponent<Image>().sprite = objetos[i].GetComponent<ScriptObjeto>().GetImagen();
            
        }
    }

    //cosas relacionadas al cambio de colores
    public void GetMeshes()
    {
        
        foreach(Transform Botones in contenidoColor.transform)
        {
            Destroy(Botones.gameObject);
        }

        GameObject objetoInterno = seleccionado.transform.GetChild(0).gameObject;
        //Meshes.Clear();
        for (int i = 0; i < objetoInterno.transform.childCount; i++)
        {
            GameObject temp = Instantiate(ColorShowButton, contenidoColor.transform);
            temp.name = i.ToString();
            
            temp.transform.Find("Texto").GetComponent<Text>().text = "Color " + (i +1);
            temp.transform.Find("Color").GetComponent<Image>().color = objetoInterno.transform.GetChild(i).GetComponent<MeshRenderer>().material.color;
            temp.GetComponent<ScripBotonColor>().SetMesh(objetoInterno.transform.GetChild(i).GetComponent<MeshRenderer>(), i);
            //Meshes.Add(objetoInterno.transform.GetChild(i).GetComponent<MeshRenderer>());
        }
    }

    public void SetMeshCambio(MeshRenderer Mesh, int num)
    {
        if(!ColorPalette.activeSelf)
            ColorPalette.SetActive(true);
        ColorPickerController.setMesh(Mesh, num);
    }

    

}
