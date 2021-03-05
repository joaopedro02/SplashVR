using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button_play : MonoBehaviour
{
    incia_tintas amarela;
    incia_tintas verde;
    incia_tintas azul;
    incia_tintas branca;
    incia_tintas rosa;
    incia_tintas vermelha;
    inicia_cavalete cavalete;
    public GameObject menu_secundario;
    // Start is called before the first frame update
    void Start()
    {
        cavalete = GameObject.Find("Cavalete").GetComponent<inicia_cavalete>();
        amarela =GameObject.Find("tinta_amarela").GetComponent<incia_tintas>();
        verde   =GameObject.Find("tinta_verde").GetComponent<incia_tintas>();
        azul    =GameObject.Find("tinta_azul").GetComponent<incia_tintas>();
        branca  =GameObject.Find("tinta_branca").GetComponent<incia_tintas>();
        rosa    =GameObject.Find("tinta_rosa").GetComponent<incia_tintas>();
        vermelha=GameObject.Find("tinta_vermelha").GetComponent<incia_tintas>();
    }

    

    public void click()
    {
        GameObject.Find("Menu principal").SetActive(false);

        amarela.tras_tintas();
        verde   .tras_tintas();
        azul    .tras_tintas();
        branca.tras_tintas();
        rosa    .tras_tintas();
        vermelha.tras_tintas();
        cavalete.tras_cavalete();

        Component[] quadros;
        quadros = GameObject.Find("Cavalete").GetComponentsInChildren<inicia_quadrados>();
        foreach (inicia_quadrados i in quadros)
        {
            i.aparece_quadros();
        }
        GameObject.Find("Contador").GetComponent<contador_tempo>().comeca = true;
        GameObject.Find("Particle System").GetComponent<ParticleLauncher>().comeca = true;
        menu_secundario.SetActive(true);
        GameObject.Find("radio").GetComponent<music_control>().toca_musica();

    }
}
