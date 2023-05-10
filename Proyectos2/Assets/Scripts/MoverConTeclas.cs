using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MoverConTeclas : MonoBehaviour
{
    public GameObject gizmoRot;
    public GameObject gizmoTrans;
    private ButtonUI manual;
    private Gizmo helper;
    bool rotandoTeclas = true;
    // Start is called before the first frame update
    void Start()
    {
        helper = GetComponent<Gizmo>();
        manual = GetComponent<ButtonUI>();
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("FlechasHor");
        float mouseY = Input.GetAxis("FlechasVer");
        if(mouseX != 0 || mouseY != 0)
        {
            
            Debug.Log(mouseY);
            if (helper.getState() == 'r')
            {
                rotandoTeclas = true;
                Rotar(mouseX, mouseY);
                manual.ChangeValues(new Vector3(helper.seleccionado.transform.localEulerAngles.x, helper.seleccionado.transform.localEulerAngles.y, helper.seleccionado.transform.localEulerAngles.z));
            }
            else if (helper.getState() == 't')
            {
                Transformar(mouseX, mouseY);
            }

        }
        if ( !Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow) && rotandoTeclas)
        {
            rotandoTeclas = false;
            if (helper.getState() == 'r')
            {
                gizmoRot.transform.rotation = Quaternion.Euler(Vector3.zero);
                helper.setRotando(false, 'q');
            }
            
        }
    }

    void Rotar(float mouseX, float mouseY)
    {
        if(mouseY != 0)
        {
            if (Camera.main.transform.rotation.eulerAngles.y < 315 && Camera.main.transform.rotation.eulerAngles.y >= 225)
            {

                gizmoRot.transform.Rotate(Vector3.right * 70 * Time.deltaTime * mouseY);

            }
            else if (Camera.main.transform.rotation.eulerAngles.y < 225 && Camera.main.transform.rotation.eulerAngles.y >= 135)
            {
                gizmoRot.transform.Rotate(Vector3.right * 70 * Time.deltaTime * -mouseY);
            }
            else if (Camera.main.transform.rotation.eulerAngles.y < 135 && Camera.main.transform.rotation.eulerAngles.y >= 45)
            {

                gizmoRot.transform.Rotate(Vector3.right * 70 * Time.deltaTime * mouseY);

            }
            else
            {
                gizmoRot.transform.Rotate(Vector3.right * 70 * Time.deltaTime * mouseY);
            }
            helper.setRotando(true, 'x');
        }
        else
        {
            gizmoRot.transform.Rotate(Vector3.up * -mouseX * Time.deltaTime * 70);
            
            helper.setRotando(true, 'y');
        }
    }

    void Transformar(float mouseX, float mouseY)
    {

        if (Camera.main.transform.rotation.eulerAngles.y < 315 && Camera.main.transform.rotation.eulerAngles.y >= 225)
        {
            gizmoTrans.transform.Translate(Vector3.right * -mouseY * Time.deltaTime * 3);
            gizmoTrans.transform.Translate(Vector3.forward * mouseX * Time.deltaTime * 3);
        }
        else if (Camera.main.transform.rotation.eulerAngles.y < 225 && Camera.main.transform.rotation.eulerAngles.y >= 135)
        {
            gizmoTrans.transform.Translate(Vector3.right * -mouseX * Time.deltaTime * 3);
            gizmoTrans.transform.Translate(Vector3.forward * -mouseY * Time.deltaTime * 3);
        }
        else if (Camera.main.transform.rotation.eulerAngles.y < 135 && Camera.main.transform.rotation.eulerAngles.y >= 45)
        {
            gizmoTrans.transform.Translate(Vector3.right * mouseY * Time.deltaTime * 3);
            gizmoTrans.transform.Translate(Vector3.forward * -mouseX * Time.deltaTime * 3);
        }
        else
        {
            gizmoTrans.transform.Translate(Vector3.right * mouseX * Time.deltaTime * 3);
            gizmoTrans.transform.Translate(Vector3.forward * mouseY * Time.deltaTime * 3);
        }
        if (manual.GetMode() == "mover")
        {
            manual.ChangeValues(gizmoTrans.transform.position);
        }
    }
}
