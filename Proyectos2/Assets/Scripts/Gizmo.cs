using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gizmo : MonoBehaviour
{
    //Por ahora todas estarán en public para que podamos checar como funcionan desde unity
    [Header("Cosas relacionadas a Colocar objetos")]
    public GameObject[] objetos;
    public int selectedIndex;
    public Collider piso;
    public float distance;

    private RaycastHit hit;
    private Ray ray;

    [Header("Comodin")]
    public GameObject seleccionado;

    [Header("Cosas relacionadas a Gizmos")]
    public GameObject gizmoTrans;
    public GameObject gizmoRotation;

    [Header("Bools")]
    public bool enMano;
    public bool transformation = true;
    public bool rotation;
    public bool arrastrando;

    void Start()
    {
        piso = GameObject.FindGameObjectWithTag("suelo").GetComponent<MeshCollider>();
    }

  
    void Update()
    {
        //si no esta intentando poner un objeto
        if (!arrastrando)
        {
            Gizmos();
        }
        else
        {
            //Si está oprimiendo botón izquierdo y no lo suelta
            if (Input.GetMouseButton(0))
            {
                seleccionado.transform.position = setPosition();
            }
            if (Input.GetMouseButtonUp(0))
            {
                arrastrando = false;
            }
            //Si sielta el botón izquierdo del mouse
        }


    }

    // Relacionado a el funcionamiento de guizmos
    public void SetActivo(GameObject objeto)
    {
        seleccionado = objeto;
        enMano = true;
    }

    private void Gizmos()
    {
        //Si oprime T el gizmo a usar es el de transfromación, quiza luego lo cambie a un botón que se active con mouse

        if (Input.GetKeyDown(KeyCode.T))
        {
            transformation = true;
            rotation = false;
            gizmoTrans.SetActive(true);
            gizmoRotation.SetActive(false);
            if (seleccionado != null)
            {
                gizmoTrans.transform.position = seleccionado.transform.position;
            }

        }
        //Si oprime R pus el rotar
        else if (Input.GetKeyDown(KeyCode.R))
        {
            rotation = true;
            transformation = false;
            gizmoTrans.SetActive(false);
            gizmoRotation.SetActive(true);
            if (seleccionado != null)
            {
                gizmoRotation.transform.position = new Vector3(seleccionado.transform.position.x + 1.1f, seleccionado.transform.position.y, seleccionado.transform.position.z);
                gizmoRotation.transform.rotation = seleccionado.transform.rotation;

            }
        }
        //toDO Falta agregar el gizmo de escala

        //Esto es solo para adoptar los gizmos al mueble
        if (enMano && transformation)
        {
            seleccionado.transform.position = gizmoTrans.transform.position;
        }
        else if (enMano && rotation)
        {
            seleccionado.transform.rotation = gizmoRotation.transform.rotation;
        }
    }

    public char getState()
    {
        if (transformation)
            return 't';
        else
        {
            return 'r';
        }
    }

    //Cosas relacionadas al funcionamiento de colocar objetos

    //Los muebles llaman a esta función para que le den el index
    public void setIndex(int index)
    {
        selectedIndex = index;
        arrastrando = true;
        seleccionado = Instantiate(objetos[selectedIndex],setPosition(), new Quaternion(0,0,0,0));
    }

    Vector3 lastpos = new Vector3(999, 999, 999);
    private Vector3 setPosition()
    {
        
        transformation = false;
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if(hit.collider == piso)
            {
                distance = seleccionado.GetComponent<Renderer>().bounds.center.y - seleccionado.GetComponent<Renderer>().bounds.min.y;
                lastpos = new Vector3(hit.point.x, distance, hit.point.z);
            }
            /*
             * 0 = posicion del objeto -su centro + su borde
             * posicion del objeto = su centro - su borde inferior
             */
        }
        return lastpos;
    }
}
