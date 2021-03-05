using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inicia_cavalete : MonoBehaviour
{
    // Start is called before the first frame update
    public void tras_cavalete()
    {
        gameObject.GetComponent<Animator>().Play("anim_aparece_cavalete");
    }
}
