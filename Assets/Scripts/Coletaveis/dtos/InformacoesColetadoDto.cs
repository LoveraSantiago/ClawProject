using UnityEngine;

public class InformacoesColetadoDto
{    
    public bool resultCombinacao { get; private set; }    
    public InformacoesFimDeJogoDto infosFimDeJogo { get; private set; }

    public int score { get; private set; }
    public int ordem { get; private set; }

    public Sprite sprite { get; private set; }

    public void addInfosDisplayScore(int score, int ordem)
    {
        this.ordem = ordem;
        this.score = score;
    }

    public void addInfosDisplayColetados(Sprite sprite, bool resultCombinacao)
    {
        this.sprite = sprite;        
        this.resultCombinacao = resultCombinacao;
    }

    public void addInfoFimDeJogo(InformacoesFimDeJogoDto infosFimDeJogo)
    {
        this.infosFimDeJogo = infosFimDeJogo;
    }
}
