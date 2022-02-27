using UnityEngine;

public abstract class BoardMontador 
{
    private static ColetavelEntidade.FAMILIA familia;
    private int[,] arrayDeColetaveis;   

    public void createBoard(BoardDto boardDto)
    {
        if (hasColetaveisInArray())
        {
            create(boardDto);
        }
    }    

    protected void montarLinha(PosicaoItensDoBoardDto posItem, int contadorLinha, float altura)
    {
        HelperColetavelEntidade helperColetavel = new HelperColetavelEntidade();

        for (int contadorColuna = 0; contadorColuna < posItem.Total; contadorColuna++)
        {
            int id = arrayDeColetaveis[contadorLinha, contadorColuna];
            ColetavelEntidade coletavelEntidade = helperColetavel.getColetavelEntidadeById(id);

            if (coletavelEntidade.isVazio())//SE FOR VAZIO VAI PARA A PROXIMA ITERACAO
            {
                continue;
            }
            else if (coletavelEntidade.isRandom())//SE FOR RANDOMICO SORTEIA UM COLETAVEL ENTIDADE POR FAMILIA
            {
                coletavelEntidade = helperColetavel.getRandomColetavelEntidadeByFamilia(familia);
            }

            float posX = posItem.Inicio + (posItem.Acrescimo * contadorColuna);
            Vector3 posicao = new Vector3(posX, altura, 0);
            Coletavel coletavel = HelperColetaveisInGame.criarColetavel(coletavelEntidade.nomeSprite, posicao);
            onColetavelCriado(coletavel);
        }
    }

    public abstract void configuradoPeloLevel(AbstractLevel level);
    protected abstract void create(BoardDto boardDto);
    protected abstract void onColetavelCriado(Coletavel coletavel);

    public virtual int getQtdAcrescentada()
    {
        return 0;
    }   

    protected PosicaoItensDoBoardDto getPosicaoItem(BoardDto boardDto, int indice)
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
