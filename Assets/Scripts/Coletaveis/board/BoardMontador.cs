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

    protected void montarLinha(float[] eixoX, int contadorLinha, float altura)
    {
        HelperColetavelEntidade helperColetavel = new HelperColetavelEntidade();        

        for (int contadorColuna = 0; contadorColuna < eixoX.Length; contadorColuna++)
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

            Vector3 posicao = new Vector3(eixoX[contadorColuna], altura, 0);
            ColetavelTile coletavel = criarColetavel(coletavelEntidade.nomeSprite, posicao);            
            onColetavelCriado(coletavel);
        }
    }

    protected abstract void create(BoardDto boardDto);
    protected abstract void onColetavelCriado(ColetavelTile coletavelTile);

    protected float[] getEixoX(BoardDto boardDto, int indice)
    {
        if (indice % 2 == 0)
        {
            return boardDto.PosicoesEixoXPar;
        }
        else
        {
            return boardDto.PosicoesEixoXImpar;
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

    private ColetavelTile criarColetavel(string nomeSprite, Vector3 posicao)
    {
        HelperColetaveisInGame helperInGame = new HelperColetaveisInGame();

        ColetavelTile coletavel = helperInGame.criarColetavel();
        coletavel.receberSprite(nomeSprite);
        coletavel.colocarNaPosicao(posicao);
        coletavel.ligar();

        return coletavel;
    }

    public static void configurar(ColetavelEntidade.FAMILIA familiaArg)
    {
        familia = familiaArg;
    }
}
