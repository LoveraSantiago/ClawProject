using UnityEngine;

public class InformacoesColetadoDto
{    
    public int score { get; private set; }

    public Sprite sprite { get; private set; }
    public bool resultCombinacao { get; private set; }    
    public bool fimColetados { get; private set; }

    public Vector3 posicao { get; private set; }

    public void addInfosDisplayScore(int score)
    {
        this.score = score;
    }

    public void addInfosDisplayColetados(Sprite sprite, bool resultCombinacao)
    {
        this.sprite = sprite;        
        this.resultCombinacao = resultCombinacao;
    }

    public void addInfosPosicao(Vector3 vector3)
    {
        this.posicao = vector3;
    }

    public void addInfoFinalizado(bool finalizado)
    {
        fimColetados = finalizado;
    }
}
