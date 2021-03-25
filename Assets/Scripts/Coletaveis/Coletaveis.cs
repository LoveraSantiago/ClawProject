using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Coletaveis : ContadorDeColetaveis.ColetavelCallback
{
    private GameObject[] coletados = new GameObject[3];
    private Vector2[] coletadosBackPosition = new Vector2[3];

    private bool checkCombinacao = false;
    private bool moveToPosition;

    private int score = 0;
    private int maxScore = 4;

    private ColetaveisDto coletaveisDto;
    private ContadorDeColetaveis contadorDeColetaveis;

    public Coletaveis(ColetaveisDto coletaveisDto)
    {
        contadorDeColetaveis = new ContadorDeColetaveis(coletaveisDto.ColetadosPosicoes, this);

        this.coletaveisDto = coletaveisDto;        
        this.coletaveisDto.GoTriggerDeColetado.GetComponent<DetectorDeTriggers>()
            .registrarConsumidorDeTrigger(
            (collider2d) => //temporariamente aqui p validar
            {
                //Retirar getcomponent daqui
                if (collider2d.gameObject.transform.GetComponent<Rigidbody2D>().velocity.y > 0)
                {
                    contadorDeColetaveis.adicionarColetado(collider2d.gameObject);
                    GameObject.Destroy(collider2d.gameObject);
                }
            });
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
            score += 30;
            coletaveisDto.ScoreTextField.text = score.ToString();

            foreach (SpriteRenderer spriteRenderer in coletaveisDto.ColetadosPosicoes)
            {
                spriteRenderer.sprite = null;
            }
        }
        else
        {
            foreach (SpriteRenderer spriteRenderer in coletaveisDto.ColetadosPosicoes)
            {
                spriteRenderer.sprite = null;
            }
        }
    }
}
