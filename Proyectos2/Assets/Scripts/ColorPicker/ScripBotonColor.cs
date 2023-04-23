using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScripBotonColor : MonoBehaviour
{
    
    Gizmo helper;
    [SerializeField] MeshRenderer mesh;
    [SerializeField] int num;

    void Start()
    {
        helper = GameObject.FindGameObjectWithTag("helper").GetComponent<Gizmo>();
        
        //actual = transform.GetChild(1).GetComponent<MeshRenderer>();
        //numero = int.Parse(name);
    }

    private void Update()
    {
        //actual.material.color = mesh.material.color;
    }

    public void SetMesh(MeshRenderer meshE, int child)
    {
        mesh = meshE;
        num = child;
    }
    public void SetInColor()
    {
        helper.SetMeshCambio(mesh,num);
    }

}
