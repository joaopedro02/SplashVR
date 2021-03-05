using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botao_recomeca : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject MenuSecundario;
    public GameObject MenuVitoria;
    void Start()
    {
        
    }
    public void recomeca()
    {
        Component[] quadros;
        GameObject.Find("Contador").GetComponent<contador_tempo>().zera_cronometro();
        quadros=GameObject.Find("quadros_cavalete").GetComponentsInChildren<Renderer>();
        foreach(Renderer r in quadros)
        {
            r.material.color = Color.white;
        }
        GameObject.Find("Cavalete").GetComponent<verifica_sudoku>().recomeca();
    }

    public void recomeca_vitoria()
    {
        Component[] quadros;
        GameObject.Find("Contador").GetComponent<contador_tempo>().zera_cronometro();
        quadros = GameObject.Find("quadros_cavalete").GetComponentsInChildren<Renderer>();
        foreach (Renderer r in quadros)
        {
            r.material.color = Color.white;
        }
        GameObject.Find("Cavalete").GetComponent<verifica_sudoku>().recomeca();
        MenuSecundario.SetActive(true);
        MenuVitoria.SetActive(false);
      
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
