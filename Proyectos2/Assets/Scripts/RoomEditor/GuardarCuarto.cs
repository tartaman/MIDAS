using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GuardarCuarto : MonoBehaviour
{
    [SerializeField] string nombre;
    [SerializeField] GameObject cuarto;
    void Start()
    {
        Guardar();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Guardar()
    {
        string localPath = "Assets/Guardados/" + nombre + ".prefab";

        localPath = AssetDatabase.GenerateUniqueAssetPath(localPath);

        PrefabUtility.SaveAsPrefabAssetAndConnect(cuarto, localPath, InteractionMode.UserAction);

        Debug.Log("Creado");
    }
}
