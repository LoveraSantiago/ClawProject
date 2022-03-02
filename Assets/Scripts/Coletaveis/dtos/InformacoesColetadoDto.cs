using UnityEngine;

public class InformacoesColetadoDto
{    
    public bool resultCombinacao { get; private set; }    
    public InformacoesFimDeJogoDto infosFimDeJogo { get; private set; }

    public int score { get; private set; }
    public int ordem { get; private set; }

    public Sprite sprite { get; private set; }

    public InformacoesColetadoDto addInfosDisplayScore(int score, int ordem)
    {
        this.ordem = ordem;
        this.score = score;
        return this;
    }

    public InformacoesColetadoDto addInfosDisplayColetados(Sprite sprite, bool resultCombinacao)
    {
        this.sprite = sprite;        
        this.resultCombinacao = resultCombinacao;
        return this;
    }

    public InformacoesColetadoDto addInfoFimDeJogo(InformacoesFimDeJogoDto infosFimDeJogo)
    {
        this.infosFimDeJogo = infosFimDeJogo;
        return this;
    }
}
