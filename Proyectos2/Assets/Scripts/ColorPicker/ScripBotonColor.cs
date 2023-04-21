using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScripBotonColor : MonoBehaviour
{
    
    Gizmo helper;
    [SerializeField] MeshRenderer mesh;
    MeshRenderer actual;
    Color color;

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

    public void SetMesh(MeshRenderer meshE)
    {
        mesh = meshE;
    }

    public void SetInColor()
    {
        helper.SetMeshCambio(mesh);
    }
    
}
