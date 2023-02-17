using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public float velocidadCamara;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        MovCamara(x,y);
    }

    private void MovCamara(float x, float y)
    {
        if(x != 0){
            transform.Translate(Vector3.right * x * velocidadCamara * Time.deltaTime);
        }
        if (y != 0){
            transform.Translate(Vector3.forward * y * velocidadCamara * Time.deltaTime);
        }
    }

}
