using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateHelp : MonoBehaviour
{
    GameObject imagen;
    void Start()
    {
        imagen = transform.GetChild(0).gameObject;
    }

    public void Activar()
    {
        if (!imagen.activeSelf)
        {
            imagen.SetActive(true);
        }
        else
        {
            imagen.SetActive(false);
        }
    }
}
