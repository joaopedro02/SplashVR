using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class contador_tempo : MonoBehaviour
{
    float time;
    public bool comeca { set; get; } = false;
    Text cronometro;
    // Start is called before the first frame update
    void Start()
    {
        cronometro = GetComponent<Text>();
        time = 0;
    }
    public void zera_cronometro()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (comeca)
        {
            time += Time.deltaTime;
            cronometro.text = Mathf.Floor(time / 3600).ToString("00") + ":" + Mathf.Floor(time % 3600 / 60).ToString("00") + ":" + (time % 60).ToString("00");

        }
    }
}
