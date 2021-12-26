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
            Coletavel coletavel = criarColetavel(coletavelEntidade.nomeSprite, posicao);            
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

    private Coletavel criarColetavel(string nomeSprite, Vector3 posicao)
    {
        HelperColetaveisInGame helperInGame = new HelperColetaveisInGame();
        HelperColetavelEntidade helperColetavel = new HelperColetavelEntidade();

        Coletavel coletavel = helperInGame.criarColetavel();
        Sprite sprite = helperColetavel.getSpriteColetavelByNomeSprite(nomeSprite);
        coletavel.receberSprite(sprite);
        coletavel.colocarNaPosicao(posicao);
        coletavel.ligar();

        return coletavel;
    }

    public static void configurar(ColetavelEntidade.FAMILIA familiaArg)
    {
        familia = familiaArg;
    }
}
