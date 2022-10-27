using UnityEngine;
using System.Collections.Generic;

public class ChallengeCombinacaoColetaveis : Challenge
{
    private int indice1;
    private int indice2;
    private int indice3;
    protected bool prevencao;

    public ChallengeCombinacaoColetaveis(AbstractLevel abstractLevel, int indice1, int indice2, int indice3)
    {
        this.indice1 = indice1;
        this.indice2 = indice2;
        this.indice3 = indice3;
        validarPrevencaoDeChallenge(abstractLevel);
    }

    public virtual ChallengeLabel getLabelChallenge(MapaEntidade mapaEntidade)
    {
        Sprite[] sprites = indicesToSprite(mapaEntidade);
        ChallengeLabel challengeLabel = new ChallengeLabel("Colete a combinacao ");
        challengeLabel.addIgms(sprites[0], sprites[1], sprites[2]);
        return challengeLabel; 
    }

    public virtual bool resultado(ResultadoLevelDto resultadoLevelsDto)
    {
        return prevencao || 
               validarCombinacao(resultadoLevelsDto) || 
               isCombinacaoNaoPossivelInGame(resultadoLevelsDto);
    }

    private void validarPrevencaoDeChallenge(AbstractLevel abstractLevel)
    {
        if(abstractLevel.devolverParaBoard() && !isMesmoIndices())
        {
            prevencao = true;
        }
    }

    private bool isMesmoIndices()
    {
        return indice1 == indice2 && indice2 == indice3;
    }

    private bool validarCombinacao(ResultadoLevelDto resultadoLevelsDto)
    {
        Sprite[] sprites = indicesToSprite();

        List<TrincaColetaveisDescartadosDto> coletaveisDescartados = resultadoLevelsDto.resultadosColetaveis.coletaveisDescartados.listaDeTrincaDeDescartados;
        for(int contador = 0; contador < coletaveisDescartados.Count; contador++)
        {
            bool resultado = coletaveisDescartados[contador].isSpritesIguais(sprites[0], sprites[1], sprites[2]);
            if (resultado)
            {
                return resultado;
            }
        }
        return false;
    }

    protected Sprite[] indicesToSprite()
    {
        MapaEntidade mapaEntidade = ContextoEstaticoUtils.mapaEntidade;
        return indicesToSprite(mapaEntidade);
    }

    private Sprite[] indicesToSprite(MapaEntidade mapaEntidade)
    {
        return new Sprite[] {
            mapaEntidade.getColetavelEntidadeByIndice(indice1).sprite,
            mapaEntidade.getColetavelEntidadeByIndice(indice2).sprite,
            mapaEntidade.getColetavelEntidadeByIndice(indice3).sprite
        };
    }

    protected bool isCombinacaoNaoPossivelInGame(ResultadoLevelDto resultadoLevelsDto)
    {
        Sprite[] sprites = indicesToSprite();
        Dictionary<Sprite, int> dicionarioDeSprites   = indicesParaDicionario(sprites);
        Dictionary<Sprite, int> dicionarioDescartados = TrincaColetaveisDescartadosDto.descartadosToDictionary(resultadoLevelsDto.resultadosColetaveis.coletaveisDescartados.listaDeTrincaDeDescartados);

        foreach(KeyValuePair<Sprite, int> keyValue in dicionarioDeSprites)
        {
            if (!dicionarioDescartados.ContainsKey(keyValue.Key))
            {
                Debug.Log("Combinacao nao possivel");
                return true;
            }

            int qtdDescartados = dicionarioDescartados[keyValue.Key];
            if(qtdDescartados < keyValue.Value)
            {
                Debug.Log("Combinacao nao possivel");
                return true;
            }
        }
        return false;
    }

    private Dictionary<Sprite, int> indicesParaDicionario(Sprite[] sprites)
    {
        Dictionary<Sprite, int> dicionarioDeSprites = new Dictionary<Sprite, int>();
        for (int contadorSprites = 0; contadorSprites < sprites.Length; contadorSprites++)
        {
            Sprite spriteIt = sprites[contadorSprites];
            if (dicionarioDeSprites.ContainsKey(spriteIt))
            {
                dicionarioDeSprites[spriteIt] = dicionarioDeSprites[spriteIt] + 1;
            }
            else
            {
                dicionarioDeSprites.Add(spriteIt, 1);
            }
        }        
        return dicionarioDeSprites;
    }
}
