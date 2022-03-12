using UnityEngine;
using System.Collections;

public abstract class BoardMontador 
{
    private static ColetavelEntidade.FAMILIA familia;
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
        HelperColetavelEntidade helperColetavel = new HelperColetavelEntidade();

        for (int contadorColuna = 0; contadorColuna < posItem.Total; contadorColuna++)
        {
            int id = arrayDeColetaveis[contadorLinha, contadorColuna];
            ColetavelEntidade coletavelEntidade = helperColetavel.getColetavelEntidadeById(id);
            Vector3 posicao = calcularPosicao(posItem, contadorColuna, altura);            

            if (coletavelEntidade.isVazio())//SE FOR VAZIO VAI PARA A PROXIMA ITERACAO
            {               
                onPosicaoVaziaCriado(contadorColuna, contadorLinha, posicao);
                yield return new WaitForSeconds(0.1f);
                continue;
            }
            else if (coletavelEntidade.isRandom())//SE FOR RANDOMICO SORTEIA UM COLETAVEL ENTIDADE POR FAMILIA
            {
                coletavelEntidade = helperColetavel.getRandomColetavelEntidadeByFamilia(familia);
            }

            Coletavel coletavel = HelperColetaveisInGame.criarColetavel(coletavelEntidade.nomeSprite, posicao);
            onColetavelCriado(contadorColuna, contadorLinha,coletavel);
            yield return new WaitForSeconds(0.1f);
        }
    }

    private Vector3 calcularPosicao(PosicaoItensDoBoardDto posItem, int contadorColuna, float altura)
    {
        float posX = posItem.Inicio + (posItem.Acrescimo * contadorColuna);
        Vector3 posicao = new Vector3(posX, altura, 0);
        return posicao;
    }

    public abstract void configuradoPeloLevel(AbstractLevel level);
    protected abstract IEnumerator create(BoardDto boardDto);
    protected abstract void onColetavelCriado(int posX, int posY, Coletavel coletavel);

    protected virtual void onPosicaoVaziaCriado(int posX, int posY, Vector3 posicao) { }

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

    public static void configurar(ColetavelEntidade.FAMILIA familiaArg)
    {
        familia = familiaArg;
    }
}
