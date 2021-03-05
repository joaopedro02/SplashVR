using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botao_sair : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject MenuPrincipal;
    public GameObject MenuVitoria;
    public GameObject MenuSecundario;

    void Start()
    {
        
    }

    public void sair()
    {
        Component[] quadros;
        GameObject.Find("Contador").GetComponent<contador_tempo>().zera_cronometro();
        quadros = GameObject.Find("quadros_cavalete").GetComponentsInChildren<Renderer>();
        foreach (Renderer r in quadros)
        {
            r.material.color = Color.white;
        }
        GameObject.Find("Cavalete").GetComponent<verifica_sudoku>().recomeca();
        GameObject.Find("Cavalete").GetComponent<Animator>().Play("parado");
        MenuPrincipal.SetActive(true);
        MenuSecundario.SetActive(false);
        MenuVitoria.SetActive(false);
        quadros = GameObject.Find("quadros_cavalete").GetComponentsInChildren<Renderer>();
        Component[] tintas = GameObject.Find("tintas").GetComponentsInChildren<Renderer>();
        foreach (Renderer r in quadros)
        {
            r.enabled = false;
        }
        foreach (Renderer r in tintas)
        {
            r.enabled = false;
        }
        GameObject.Find("Contador").GetComponent<contador_tempo>().comeca = false;
        GameObject.Find("Particle System").GetComponent<ParticleLauncher>().comeca = false;
        GameObject.Find("radio").GetComponent<music_control>().toca_musica_tema();
    }

    public void sair_vitoria()
    {
        GameObject.Find("Cavalete").GetComponent<Animator>().Play("parado");
        MenuPrincipal.SetActive(true);
        MenuVitoria.SetActive(false);
        Component [] quadros=GameObject.Find("quadros_cavalete").GetComponentsInChildren<Renderer>();
        Component[] tintas = GameObject.Find("tintas").GetComponentsInChildren<Renderer>();
        foreach(Renderer r in quadros)
        {
            r.enabled = false;
        }
        foreach(Renderer r in tintas)
        {
            r.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
