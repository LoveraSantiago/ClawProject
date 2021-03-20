using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Coletaveis 
{
    private GameObject[] coletados = new GameObject[3];
    private Vector2[] coletadosBackPosition = new Vector2[3];

    private bool checkCombinacao = false;
    private bool moveToPosition;

    private int score = 0;
    private int maxScore = 4;

    private ColetaveisDto coletaveisDto;

    public Coletaveis(ColetaveisDto coletaveisDto)
    {
        this.coletaveisDto = coletaveisDto;
        coletaveisDto.GoTriggerDeColetado.GetComponent<DetectorDeTriggers>()
            .registrarConsumidorDeCollider2d(
            (collider2d) => //temporariamente aqui p validar
            {
                //Retirar getcomponent daqui
                if(collider2d.gameObject.transform.GetComponent<Rigidbody2D>().velocity.y > 0 )
                {
                    GameObject.Destroy(collider2d.gameObject);
                }
            });
    }

    public void Start()
    {
        
    }

    public void Update()
    {
        
    }

    public void FixedUpdate() { }

    public void FixedUpdate2()//para nao ser chamado por enquanto
    {
        if (checkCombinacao)
        {
            GameObject checkColetavel = coletados[1];
            bool resposta = false;

            foreach (GameObject coletavel in coletados)
            {
                if (checkColetavel.gameObject.CompareTag(coletavel.tag))
                {
                    resposta = true;
                }
                else
                {
                    resposta = false;
                }
            }

            if (resposta)
            {
                Debug.Log("yes");

                for (int i = 0; i < coletados.Length; i++)
                {
                    GameObject.Destroy(coletados[i]);
                }

                score += 1;
                coletaveisDto.ScoreTextField.text = score.ToString();

                if (score == maxScore)
                {
                    OnClickPlay();
                }
            }
            else
            {
                Debug.Log("noooo");

                for (int i = 0; i < coletados.Length; i++)
                {
                    coletados[i].transform.localScale += Vector3.one * coletaveisDto.ColetadoScale;
                    coletados[i].gameObject.transform.position = coletadosBackPosition[i];

                    //coletadoPosicoes[i].gameObject.transform.position = coletadoOldPosicoes[i].transform.position;
                }
            }

            coletados = new GameObject[3];
            coletadosBackPosition = new Vector2[3];
            checkCombinacao = false;
        }

    }

    public void OnClickPlay()
    {
        SceneManager.LoadScene("TitleScene");
    }

    private void coletavelAtingido2(GameObject goColetavel)
    {
        //goColetavel.transform.GetComponent<Rigidbody2D>().mass = 0;
    }
    
    private void coletavelAtingido(GameObject goColetavel)//para nao ser chamdo por enquanto
    {
        //if (other.gameObject.tag == "Gummy")
        //{            
        //other.transform.position = coletado1.transform.position;
        //trocarParaAcaoSubindo();


        for (int i = 0; i < coletados.Length; i++)
        {
            if (coletados[i] == null)
            {
                //coletadoOldPosicoes[i] = other.gameObject;
                coletados[i] = goColetavel;
                coletadosBackPosition[i] = goColetavel.transform.position;

                goColetavel.transform.localScale -= Vector3.one * coletaveisDto.ColetadoScale;
                goColetavel.transform.position = coletaveisDto.ColetadoPosicoes[i].transform.position;

                if (i == coletados.Length - 1)
                {
                    checkCombinacao = true;
                }

                moveToPosition = true;
                //Destroy(other.gameObject);
                return;
            }
        }
        //}
    }

    public Action<GameObject> getConsumidorDeColetavelAtingito()
    {
        return (coletado) => coletavelAtingido2(coletado);
    }
}
