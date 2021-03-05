using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class incia_tintas : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Renderer>().enabled=false;        
    }

    public void tras_tintas()
    {
        gameObject.GetComponent<Renderer>().enabled = true;
        gameObject.GetComponent<Animator>().Play("anim_tintas_aparece");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
