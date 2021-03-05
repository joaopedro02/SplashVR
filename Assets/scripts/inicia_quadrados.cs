using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inicia_quadrados : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Renderer>().enabled = false;
    }

    public void aparece_quadros()
    {
        gameObject.GetComponent<Renderer>().enabled = true;
        gameObject.GetComponent<Animator>().Play("anim_aparece");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
