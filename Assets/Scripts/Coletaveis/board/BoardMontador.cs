using UnityEngine;

public abstract class BoardMontador 
{
    protected static ColetavelEntidade.FAMILIA familia;
    protected int[,] arrayDeColetaveis;

    public static void configurar(ColetavelEntidade.FAMILIA familiaArg)
    {
        familia = familiaArg;
    }    

    protected void montarLinha(float[] eixoX, int contadorLinha, float altura)
    {
        HelperColetavelEntidade helperColetavelEntidade = new HelperColetavelEntidade();
        HelperColetaveisInGame  helperColetaveisInGame  = new HelperColetaveisInGame();

        for (int contadorColuna = 0; contadorColuna < eixoX.Length; contadorColuna++)
        {
            int id = arrayDeColetaveis[contadorLinha, contadorColuna];
            ColetavelEntidade coletavelEntidade = helperColetavelEntidade.getColetavelEntidadeById(id);

            if (coletavelEntidade.isVazio())//SE FOR VAZIO VAI PARA A PROXIMA ITERACAO
            {
                continue;
            }
            else if (coletavelEntidade.isRandom())//SE FOR RANDOMICO SORTEIA UM COLETAVEL ENTIDADE POR FAMILIA
            {
                coletavelEntidade = helperColetavelEntidade.getRandomColetavelEntidadeByFamilia(familia);
            }

            Vector3 posicao = new Vector3(eixoX[contadorColuna], altura, 0);
            ColetavelTile coletavel = helperColetaveisInGame.criarColetavel();
            coletavel.receberSprite(coletavelEntidade.nomeSprite);
            coletavel.colocarNaPosicao(posicao);
            coletavel.ligar();
            onColetavelCriado(coletavel);
        }
    }

    protected virtual void onColetavelCriado(ColetavelTile coletavelTile){}    

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
}
