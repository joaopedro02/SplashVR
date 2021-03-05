using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class muda_cor : MonoBehaviour
{
    ParticleSystem particle_system;
    ParticleLauncher particle_laucher;
    OVRCursor m_Cursor;
    verifica_sudoku verificador;
    int c;//coluna desse quadrado
    int l;//linha desse quadrado
    float ultima_colisao;
    bool clicou;
    // Start is called before the first frame update
    void atribui_coluna_linha()
    {
        string num = name.Substring(name.IndexOf("_") + 1, 3);
        int aux = int.Parse(num);
        Debug.Log(aux);
        l = aux / 5;
        c = aux % 5;
        Debug.Log(aux.ToString() + " " + l.ToString() + " " + c.ToString());
    }

    void Start()
    {
        clicou = false;
        ultima_colisao = -50f;
        atribui_coluna_linha();//atribui o valor da coluna e da linha com base no nome dos objetos que representam os quadrados
        verificador = GameObject.Find("Cavalete").GetComponent<verifica_sudoku>();
        m_Cursor = GameObject.Find("Cursor").GetComponent<OVRCursor>();
        particle_system = GameObject.Find("Particle System").GetComponent<ParticleSystem>();
        particle_laucher = GameObject.Find("Particle System").GetComponent<ParticleLauncher>();
    }

    string verifica_mira()
    {
        GameObject camera = GameObject.Find("OVRCameraRig");

        RaycastHit hit;
        Vector3 raycastdir = m_Cursor.transform.position - camera.transform.position;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(camera.transform.position, raycastdir, out hit, Mathf.Infinity))
        {
            string name = hit.collider.gameObject.name;

            Debug.Log("Did Hit");
            return name;
        }
        else
        {
            return "";
        }
    }

    public IEnumerator Color_fill()
    {
        yield return new WaitForSeconds(0.1f);
        GetComponent<Renderer>().material.color = particle_system.startColor;
        GameObject.Find("Som Splash").GetComponent<AudioSource>().Play();
        verificador.Insere_na_matriz_resp(l,c, particle_laucher.Get_cor(),gameObject);
        verificador.confere_corretude();
    }

    void OnParticleCollision(GameObject other)
    {   if (clicou)
        {
            clicou = false;
            if (Time.time - ultima_colisao > 0.7f)
            {
                ultima_colisao = Time.time;
                StartCoroutine(Color_fill());
                Debug.Log("colisao");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (verifica_mira().Equals(name))
            {
                clicou = true;
            }
        }
    }
}
