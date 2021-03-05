using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//aqui é configurada a direçao e a cor das particulas quando mira em uma lata de tinta, também e configurado a cor do ponteiro de mira

public class ParticleLauncher : MonoBehaviour
{
    public ParticleSystem particles;
    public OVRCursor m_Cursor;
    public bool comeca= false;
    private Su_cores cor;  
    private Vector3 dire;
    private Vector3 frente;
    private Quaternion quartenion;
    private int apertou;

    // Start is called before the first frame update
    void Start()
    {
        cor = Su_cores.vermelho;
        apertou = 0;
        quartenion = new Quaternion();
    }

    string verifica_mira()
    {
        GameObject camera = GameObject.Find("OVRCameraRig");

        RaycastHit hit;
        Vector3 raycastdir = m_Cursor.transform.position - camera.transform.position;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(camera.transform.position, raycastdir, out hit, Mathf.Infinity))
        {
            string name=hit.collider.gameObject.name;

            Debug.Log("Did Hit");
            return name;
        }
        else
        {
            return "";
        }
    }
    public Su_cores Get_cor()
    {
        return cor;
    }

    bool verifica_cor(string name)
    {
        Color new_color;
        SpriteRenderer spriterenderer = GameObject.Find("GazeIcon").GetComponent<SpriteRenderer>();

        if (name.Equals("tinta_branca"))
        {
            new_color=new Color(1,1,1);
            spriterenderer.color = new_color;
            particles.startColor = new_color;
            cor = Su_cores.branco;
            GameObject.Find("Som escolha tinta").GetComponent<AudioSource>().Play();
            return true;
        }else if (name.Equals("tinta_rosa")){
            new_color = new Color(1, 0.12157f, 0.9686f);
            spriterenderer.color = new_color;
            particles.startColor = new_color;
            cor = Su_cores.rosa;
            GameObject.Find("Som escolha tinta").GetComponent<AudioSource>().Play();
            return true;
        }
        else if (name.Equals("tinta_azul")){
            new_color = new Color(0, 0, 1);
            spriterenderer.color = new_color;
            particles.startColor = new_color;
            cor = Su_cores.azul;
            GameObject.Find("Som escolha tinta").GetComponent<AudioSource>().Play();
            return true;
        }
        else if (name.Equals("tinta_amarela")){
            new_color = new Color(1, 0.8667f, 0.12157f);
            spriterenderer.color = new_color;
            particles.startColor = new_color;
            cor = Su_cores.amarelo;
            GameObject.Find("Som escolha tinta").GetComponent<AudioSource>().Play();
            return true;
        }
        else if (name.Equals("tinta_verde")){
            new_color = new Color(0, 1, 0);
            spriterenderer.color = new_color;
            particles.startColor = new_color;
            cor = Su_cores.verde;
            GameObject.Find("Som escolha tinta").GetComponent<AudioSource>().Play();
            return true;
        }
        else if (name.Equals("tinta_vermelha")){
            new_color = new Color(1, 0, 0);
            spriterenderer.color = new_color;
            particles.startColor = new_color;
            cor = Su_cores.vermelho;
            GameObject.Find("Som escolha tinta").GetComponent<AudioSource>().Play();
            return true;
        }

        return false;

    }
    // Update is called once per frame
    bool equadro(string nome)
    {
        if (nome.Equals("Cube_002") || nome.Equals("Cube_003") || nome.Equals("quadro_000") || nome.Equals("quadro_001") || nome.Equals("quadro_002") || nome.Equals("quadro_003") || nome.Equals("quadro_004") || nome.Equals("quadro_005") || nome.Equals("quadro_006") || nome.Equals("quadro_007") || nome.Equals("quadro_008") || nome.Equals("quadro_009") || nome.Equals("quadro_010") || nome.Equals("quadro_011") || nome.Equals("quadro_012") || nome.Equals("quadro_013") || nome.Equals("quadro_014") || nome.Equals("quadro_015") || nome.Equals("quadro_016") || nome.Equals("quadro_017") || nome.Equals("quadro_018") || nome.Equals("quadro_019") || nome.Equals("quadro_020") || nome.Equals("quadro_021") || nome.Equals("quadro_022") || nome.Equals("quadro_023") || nome.Equals("quadro_024"))
            return true;
        return false;        
    }
    void Update()
    {
        
        
        if (Input.GetButton("Fire1")&&apertou==0&&comeca)
        {
            string tinta = verifica_mira();
            apertou = 1;
            verifica_cor(tinta);
            if (equadro(tinta))
            {
                dire = m_Cursor.transform.position - particles.transform.position;
                frente = transform.TransformDirection(new Vector3(0, 0, 1));
                quartenion.SetFromToRotation(frente, dire);
                transform.rotation = quartenion * transform.rotation;
                GetComponent<AudioSource>().Play();
                particles.Emit(24);
            }
        }
        else if(!Input.GetButton("Fire1"))
        {
            apertou = 0;
        }

    }
}
