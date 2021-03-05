using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gaze_handler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GazeEnter(){
        Debug.Log("estou olhando para um objeto");
    }

    public void GazeExit(){
        Debug.Log("nao estao olhando");
    }
}
