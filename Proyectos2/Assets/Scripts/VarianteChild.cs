using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VarianteChild : MonoBehaviour
{
    VarianteIrregular Father;
    // Start is called before the first frame update
    void Start()
    {
        Father = GetComponentInParent<VarianteIrregular>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Father.MouseIrregular();
    }
}
