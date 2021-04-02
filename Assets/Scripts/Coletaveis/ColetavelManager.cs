using System.Collections.Generic;
using UnityEngine;

public class ColetavelManager : ContadorDeColetaveis.ColetavelCallback, ConsumidorDeEvento<GameObject>
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
    }

    public ConsumidorDeEvento<GameObject> getConsumidorDeColetado()
    {
        return this;
    }

    public void consumirEvento(GameObject gameObjectColetado)
    {
        adicionarColetado(gameObjectColetado);
    }

    private void adicionarColetado(GameObject gameObjectColetado)
    {
        int qtdColetados = contadorDeColetaveis.getQtdColetados();
        Sprite sprite = gameObjectColetado.GetComponent<SpriteRenderer>().sprite;

        coletaveisDto.ColetadosPosicoes[qtdColetados].sprite = sprite;
        contadorDeColetaveis.adicionarColetado(gameObjectColetado.name);
        gameObjectColetado.SetActive(false);
        coletados.Add(gameObjectColetado);
        AudioController.current.PlayAudio(AudioController.current.coletar);
    }

    public void FixedUpdate() { }

    public void match(bool result)
    {
        if (result)
        {
            atualizaScore();
        }
        else
        {
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
