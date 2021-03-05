using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class muda_cor_simplificado : MonoBehaviour
{
    ParticleSystem particle_system;
    ParticleLauncher particle_laucher;
    OVRCursor m_Cursor;
   
    
    float ultima_colisao;
    bool clicou;
    
   
    void Start()
    {
        clicou = false;
        ultima_colisao = -50f;
      
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
    }

    void OnParticleCollision(GameObject other)
    {
        if (clicou)
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
