using UnityEngine;
using System.Collections;

public abstract class BoardMontador 
{
    private int[,] arrayDeColetaveis;   

    public IEnumerator createBoard(BoardDto boardDto)
    {
        if (hasColetaveisInArray())
        {
            yield return create(boardDto);
        }        
    }    

    protected IEnumerator montarLinha(PosicaoItensDoBoardDto posItem, int contadorLinha, float altura)
    {
        MapaEntidade mapaEntidade = ContextoEstaticoUtils.mapaEntidade;

        for (int contadorColuna = 0; contadorColuna < posItem.Total; contadorColuna++)
        {
            int id = arrayDeColetaveis[contadorLinha, contadorColuna];
            Vector3 posicao = calcularPosicao(posItem, contadorColuna, altura);

            ColetavelEntidade coletavelEntidade = null;
            if (ColetavelEntidade.isIndiceVazio(id))//SE FOR VAZIO VAI PARA A PROXIMA ITERACAO
            {               
                yield return onPosicaoVaziaCriado(contadorColuna, contadorLinha, posicao);                
                continue;
            }
            else if (ColetavelEntidade.isIndiceRandom(id))//SE FOR RANDOMICO SORTEIA UM COLETAVEL ENTIDADE POR FAMILIA
            {
                coletavelEntidade = mapaEntidade.getColetavelEntidadeRandom();
            }
            else
            {
                coletavelEntidade = mapaEntidade.getColetavelEntidadeByIndice(id);
            }

            Coletavel coletavel = criarColetavel(coletavelEntidade.sprite, posicao);            
            yield return onColetavelCriado(contadorColuna, contadorLinha,coletavel);            
        }
    }

    protected virtual Coletavel criarColetavel(Sprite sprite, Vector3 posicao)
    {
        return HelperColetaveisInGame.criarColetavel(sprite, posicao); 
    }

    private Vector3 calcularPosicao(PosicaoItensDoBoardDto posItem, int contadorColuna, float altura)
    {
        float posX = posItem.Inicio + (posItem.Acrescimo * contadorColuna);
        Vector3 posicao = new Vector3(posX, altura, 0);
        return posicao;
    }

    public abstract void configuradoPeloLevel();
    protected abstract IEnumerator create(BoardDto boardDto);
    protected abstract IEnumerator onColetavelCriado(int posX, int posY, Coletavel coletavel);

    protected virtual IEnumerator onPosicaoVaziaCriado(int posX, int posY, Vector3 posicao)
    {
        yield return null;
    }

    public virtual int getQtdAcrescentada()
    {
        return 0;
    }   

    protected virtual PosicaoItensDoBoardDto getPosicaoItem(BoardDto boardDto, int indice)
    {   
        if (indice % 2 == 0)
        {
            return boardDto.PosicoesXPares;
        }
        else
        {
            return boardDto.PosicoesXImpares;
        }        
    }

    protected void setArrayDeColetavel(int[,] arrayDeColetaveis)
    {
        this.arrayDeColetaveis = arrayDeColetaveis;
    }

    protected bool hasColetaveisInArray()
    {
        return arrayDeColetaveis != null;
    }

    protected int getQtdItensDimensaoZero()
    {
        return arrayDeColetaveis.GetLength(0);
    }   

    protected virtual float getDelay()
    {
        return 0.1f;
    }   
}
