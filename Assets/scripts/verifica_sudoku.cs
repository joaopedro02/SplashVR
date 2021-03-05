using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Su_cores: int
{
    branco =0,
    azul =1,
    amarelo =2,
    verde =3,
    rosa =4,
    vermelho = 5
}

public class quadrado
{
    public int linha { get; set; }
    public int coluna { get; set; }
    GameObject quadro { get; set; }
    float last_animation;

    public quadrado(int linha, int coluna,GameObject quadro)
    {
        this.linha = linha;
        this.coluna = coluna;
        this.quadro = quadro;
        last_animation = -50f;
    }

    public override string ToString()
    {
        return " l:"+linha.ToString()+" c:"+coluna.ToString();
    }

    public void anim_wrong()
    {
       // if (Time.time - last_animation > 3f)
      //  {
            quadro.GetComponent<Animator>().Play("animation_wrong_tentativa2");
            last_animation = Time.time;
        //}
    }
    
}

public class verifica_sudoku : MonoBehaviour
{
    int[,] resp;
    int cont;
    List<quadrado> quadrados_errados;
    quadrado[,] quadrados;
    float last_anim;
    float apertou_botao;
    bool correto;
    public crossfade_panel mensagem_errado;
    float ultimo_aviso;
    public ParticleSystem confeti;
    public GameObject vitoriaMenu;
    public GameObject MenuSegundario;
    bool verifica;
    // Start is called before the first frame update
    void Start()
    {
        ultimo_aviso = -50f;
        mensagem_errado = GameObject.Find("panel_mensagem_errado").GetComponent<crossfade_panel>();
        correto = false;
        apertou_botao = -50f;
        last_anim = -50f;
        quadrados= new quadrado[5, 5];
        verifica = false;
        quadrados_errados = new List<quadrado>();
        resp = new int[5, 5];
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                quadrados[i, j] = null;
                resp[i, j] = 0; 
            }
        }
        cont = 0;
    }

    public void Insere_na_matriz_resp(int l,int c,Su_cores cor,GameObject quadro)
    {
        if (resp[l, c] == (int)Su_cores.branco && cor!= Su_cores.branco)
        {
            cont++;
        }else if (cor == Su_cores.branco && resp[l,c]!= (int)Su_cores.branco)
        {
            cont--;
        }
        resp[l, c] = (int) cor;
        if (quadrados[l, c] == null)
        {
            quadrados[l, c] = new quadrado(l,c,quadro);
        }
    }
    public void recomeca()
    {
        cont = 0;
        quadrados_errados.Clear();
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                resp[i, j] = 0;
            }
        }
    }

    public bool confere_corretude()//retorna falso quando nao e correto a solucao e verdadeiro quando e correto
    {
        bool jaadd = false;
        int[,] auxl = new int[5, 6];//para fazer a contagem das cores por linha
        int[,] auxc = new int[5,6];//para fazer a contagem das cores por coluna
        int[,] auxdigprinc = new int[7,6];//para fazer contagem diagonais direcao principal
        int[,] auxdigsec = new int[7,6];//para fazer contagem diagonais direcao secundaria
        quadrado[,] quadros_linha = new quadrado[5, 6];
        quadrado[,] quadros_colunas = new quadrado[5, 6];
        quadrado[,] quadros_dig_princ = new quadrado[7, 6];
        quadrado[,] quadros_dig_sec = new quadrado[7, 6];


        quadrados_errados.Clear();
        for(int i = 0; i < 7; i++)
        {
            for(int j = 0; j < 6; j++)
            {
                auxdigprinc[i, j] = 0;
                auxdigsec[i, j] = 0;
                if (i < 5)
                {
                    auxl[i, j] = 0;
                    auxc[i, j] = 0;
                }
            }
        }

        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (resp[i, j] != (int)Su_cores.branco)//nao contabiliza o branco nos erros e na contagem para ver se completou o problema
                {
                    //linhas
                    jaadd = false;
                    auxl[i, resp[i, j]]++;
                    if (auxl[i, resp[i, j]] == 1)
                        quadros_linha[i, resp[i, j]] = quadrados[i, j];
                    if (auxl[i, resp[i, j]] == 2)
                    {
                        auxl[i, resp[i, j]]++;
                        quadrados_errados.Add(quadros_linha[i, resp[i, j]]);
                    }
                    if (auxl[i, resp[i, j]] > 1)//verifica linha
                    {
                        jaadd = true;
                        quadrados_errados.Add(quadrados[i,j]);
                    }
                    //colunas
                    auxc[j, resp[i, j]]++;
                    if (auxc[j, resp[i, j]] == 1)
                        quadros_colunas[j, resp[i, j]] = quadrados[i, j];
                    if (auxc[j, resp[i, j]] == 2)
                    {
                        auxc[j, resp[i, j]]++;
                        quadrados_errados.Add(quadros_colunas[j, resp[i, j]]);
                    }
                    if (auxc[j, resp[i, j]] > 1 && !jaadd)//verifica coluna
                    {
                        jaadd = true;
                        quadrados_errados.Add(quadrados[i, j]);
                    }
                    //diagonais na direcao principal
                    for (int k = 0; k <=3; k++)
                    {
               
                        if (i == j + k)
                        {
                            auxdigprinc[k,resp[i, j]]++;
                            if (auxdigprinc[k, resp[i, j]] == 1)
                                quadros_dig_princ[k, resp[i, j]] = quadrados[i, j];
                            if (auxdigprinc[k, resp[i, j]] == 2)
                            {
                                auxdigprinc[k, resp[i, j]]++;
                                quadrados_errados.Add(quadros_dig_princ[k, resp[i, j]]);
                            }
                            if (auxdigprinc[k,resp[i, j]] > 1 && !jaadd)
                            {
                                jaadd = true;
                                quadrados_errados.Add(quadrados[i, j]);
                            }
                        }
                        if (k != 0 && i == j - k)
                        {
                            auxdigprinc[k + 3, resp[i, j]]++;
                            if (auxdigprinc[k + 3, resp[i, j]] == 1)
                                quadros_dig_princ[k + 3, resp[i, j]] = quadrados[i, j];
                            if (auxdigprinc[k + 3, resp[i, j]] == 2)
                            {
                                auxdigprinc[k + 3, resp[i, j]]++;
                                quadrados_errados.Add(quadros_dig_princ[k + 3, resp[i, j]]);
                            }
                            if (auxdigprinc[k+3, resp[i, j]] > 1 && !jaadd)
                            {
                                jaadd = true;
                                quadrados_errados.Add(quadrados[i, j]);
                            }

                        }
                    }
                    //diagonais na direcao da secundaria
                    for (int k = 1; k <= 7; k++)
                    {
                        if (i == (k - j))
                        {
                            auxdigsec[k - 1, resp[i, j]]++;
                            if (auxdigsec[k - 1, resp[i, j]] == 1)
                                quadros_dig_sec[k - 1, resp[i, j]] = quadrados[i, j];
                            if (auxdigsec[k - 1, resp[i, j]] == 2)
                            {
                                auxdigsec[k - 1, resp[i, j]]++;
                                quadrados_errados.Add(quadros_dig_sec[k - 1, resp[i, j]]);
                            }
                            if (auxdigsec[k-1,resp[i, j]] > 1 && !jaadd)
                            {
                                jaadd = true;
                                quadrados_errados.Add(quadrados[i, j]);
                            }
                        }
                    }
                }
            }
        }
        correto= (!(quadrados_errados.Count > 0)) && cont >= 25;
        roda_animacao_errado_no_proximo_update();
        if(cont>1 && quadrados_errados.Count > 0)
        {
            if (Time.time - ultimo_aviso > 10)
            {
               ultimo_aviso = Time.time;
               StartCoroutine(avisa());
            }
        }
        if (correto)
        {
            ganhou();
        }
        return correto;
    }

    public void ganhou()
    {
        confeti.enableEmission=true;
        confeti.Play();
        vitoriaMenu.SetActive(true);
        GameObject.Find("radio").GetComponent<AudioSource>().Pause();
        vitoriaMenu.GetComponent<AudioSource>().Play();

        MenuSegundario.SetActive(false);
    }

    public IEnumerator avisa()
    {
        mensagem_errado.FadeToFull();
        yield return new WaitForSeconds(2.4f);
        mensagem_errado.FadeToZero();
    }

    void roda_animacao_errado_no_proximo_update()
    {
        last_anim = -50f;//roda a animacao d novo se necessario
    }
    // Update is called once per frame
    void Update()
    {
        //retorna true se o jogo tiver terminado e estiver correto
        
        if (Time.time - last_anim > 10)
        {
            last_anim = Time.time;
            foreach (quadrado q in quadrados_errados)
            {
                q.anim_wrong();
              
            }
        }
        
    }
}
