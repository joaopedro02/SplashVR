using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class crossfade_panel : MonoBehaviour
{
    // can ignore the update, it's just to make the coroutines get called for example
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Q))
        //{
        //    FadeToFull();
        //}
        //if (Input.GetKeyDown(KeyCode.E))
        //{
        //    FadeToZero();
        //}
    }

    void Start()
    {
        Image i = GetComponent<Image>();
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        Text t = GameObject.Find("mensagem_errado").GetComponent<Text>();
        t.color = new Color(t.color.r, t.color.g, t.color.b, 0);
    }

    public void FadeToFull()
    {
        StartCoroutine(GameObject.Find("mensagem_errado").GetComponent<crossfade>().FadeTextToFullAlpha(1f, GameObject.Find("mensagem_errado").GetComponent<Text>()));
        StartCoroutine(FadeTextToFullAlpha(1f, GetComponent<Image>()));
    }

    public void FadeToZero()
    {
        StartCoroutine(GameObject.Find("mensagem_errado").GetComponent<crossfade>().FadeTextToZeroAlpha(1f, GameObject.Find("mensagem_errado").GetComponent<Text>()));
        StartCoroutine(FadeTextToZeroAlpha(1f, GetComponent<Image>()));
    } 


    public IEnumerator FadeTextToFullAlpha(float t, Image i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        while (i.color.a < 1.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            yield return null;
        }
    }

    public IEnumerator FadeTextToZeroAlpha(float t, Image i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
        while (i.color.a > 0.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
            yield return null;
        }
    }
}