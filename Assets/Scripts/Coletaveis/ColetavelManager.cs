using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class ColetavelManager : ContadorDeColetaveis.ColetavelCallback
{
    private List<GameObject> coletados = new List<GameObject>();        

    private int score = 0;    
    private ColetaveisDto coletaveisDto;
    private ContadorDeColetaveis contadorDeColetaveis;

    public ColetavelManager(ColetaveisDto coletaveisDto)
    {
        //contadorDeColetaveis = new ContadorDeColetaveis(coletaveisDto.ColetadosPosicoes, this);
        contadorDeColetaveis = new ContadorDeColetaveis(this);

        this.coletaveisDto = coletaveisDto;        
        this.coletaveisDto.GoTriggerDeColetado.GetComponent<DetectorDeTriggers>()
            .registrarConsumidorDeTrigger(
            (collider2d) => //temporariamente aqui p validar
            {
                //Retirar getcomponent daqui
                if (collider2d.gameObject.transform.GetComponent<Rigidbody2D>().velocity.y > 0)
                {                   
                    adicionarColetado(collider2d.gameObject);
                }
            });
    }

    private void adicionarColetado(GameObject gameObject)
    {
        int qtdColetados = contadorDeColetaveis.getQtdColetados();
        Sprite sprite = gameObject.GetComponent<SpriteRenderer>().sprite;

        coletaveisDto.ColetadosPosicoes[qtdColetados].sprite = sprite;
        contadorDeColetaveis.adicionarColetado(gameObject.GetComponent<SpriteRenderer>().sprite);
        gameObject.SetActive(false);
        coletados.Add(gameObject);
    }

    public void FixedUpdate() { }

    //public void FixedUpdate2()//para nao ser chamado por enquanto
    //{
    //    if (checkCombinacao)
    //    {
    //        GameObject checkColetavel = coletados[1];
    //        bool resposta = false;
    //        if (resposta)
    //        {
    //            Debug.Log("yes");

    //            for (int i = 0; i < coletados.Length; i++)
    //            {
    //                GameObject.Destroy(coletados[i]);
    //            }

    //            score += 1;
    //            coletaveisDto.ScoreTextField.text = score.ToString();

    //            if (score == maxScore)
    //            {
    //                OnClickPlay();
    //            }
    //        }
    //        else
    //        {
    //            Debug.Log("noooo");

    //            for (int i = 0; i < coletados.Length; i++)
    //            {
    //                coletados[i].transform.localScale += Vector3.one * coletaveisDto.ColetadoScale;
    //                coletados[i].gameObject.transform.position = coletadosBackPosition[i];

    //                //coletadoPosicoes[i].gameObject.transform.position = coletadoOldPosicoes[i].transform.position;
    //            }
    //        }

    //        coletados = new GameObject[3];
    //        coletadosBackPosition = new Vector2[3];
    //        checkCombinacao = false;
    //    }

    //}

    public void OnClickPlay()
    {
        SceneManager.LoadScene("TitleScene");
    }

    private void coletavelAtingido2(GameObject goColetavel)
    {
        Debug.Log("coletavelAtingido2");
        //goColetavel.transform.GetComponent<Rigidbody2D>().mass = 0;
    }

    public Action<GameObject> getConsumidorDeColetavelAtingito()
    {
        return (coletado) => coletavelAtingido2(coletado);
    }

    public void match(bool result)
    {
        if (result)
        {
            atualizaScore();
        }
        else
        {

            //foreach (GameObject gameObject in coletados)
            //{
            //    gameObject.SetActive(true);

            //}
            

            resetColetadosPosicoes();
        }
    }

    private void atualizaScore()
    {
        score += 30;
        coletaveisDto.ScoreTextField.text = score.ToString();

        resetColetadosPosicoes();
    }

    private void resetColetadosPosicoes()
    {
        Debug.Log("resetColetadosPosicoes");
        foreach (SpriteRenderer spriteRenderer in coletaveisDto.ColetadosPosicoes)
        {
            spriteRenderer.sprite = null;
        }

        coletados.Clear();
    }
}
