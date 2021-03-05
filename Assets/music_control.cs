using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class music_control : MonoBehaviour
{
    ParticleSystem particle_system;
    ParticleLauncher particle_laucher;
    OVRCursor m_Cursor;
    public AudioClip musicaTema;
    public AudioClip musica;
    // Start is called before the first frame update
    void Start()
    {
        m_Cursor = GameObject.Find("Cursor").GetComponent<OVRCursor>();
        particle_system = GameObject.Find("Particle System").GetComponent<ParticleSystem>();
        particle_laucher = GameObject.Find("Particle System").GetComponent<ParticleLauncher>();
        toca_musica_tema();
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

    public void toca_musica_tema()
    {
        GetComponent<AudioSource>().clip = musicaTema;
        GetComponent<AudioSource>().Play();
    }
    public void toca_musica()
    {
        GetComponent<AudioSource>().clip = musica;
        GetComponent<AudioSource>().Play();
    }
    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetButtonDown("Fire1"))
        {
            if (verifica_mira().Equals(name))
            {
                if (!GetComponent<AudioSource>().isPlaying)
                {
                    GetComponent<AudioSource>().Play();
                }
                else
                {
                    GetComponent<AudioSource>().Pause();
                }      
            }
        }
    }
    
}
