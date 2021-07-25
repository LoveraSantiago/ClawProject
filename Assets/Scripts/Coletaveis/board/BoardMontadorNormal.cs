using UnityEngine;

public class BoardMontadorNormal : BoardMontador
{
    private int[,] arrayDeColetaveis;

    public void configuradoPeloLevel(AbstractLevel level)
    {        
        arrayDeColetaveis = level.getArrayDeColetaveis();
    }

    public int create(BoardDto boardDto, PoolDeColetaveis poolDeColetaveis)
    {
        int contadorDeColetaveis = 0;

        ColetavelQuery coletavelQuery = new ColetavelQuery();
        for (int contadorLinha = 0; contadorLinha < boardDto.PosicoesEixoY.Length; contadorLinha++)
        {
            float[] eixoX = getEixoX(boardDto, contadorLinha);
            for (int contadorColuna = 0; contadorColuna < eixoX.Length; contadorColuna++)
            {
                int id = arrayDeColetaveis[contadorLinha, contadorColuna];
                ColetavelEntidade coletavelEntidade = coletavelQuery.getColetavelEntidadeById(id);

                if (coletavelEntidade.isVazio())//SE FOR VAZIO VAI PARA A PROXIMA ITERACAO
                {
                    continue;
                }
                else if (coletavelEntidade.isRandom())//SE FOR RANDOMICO SORTEIA UM COLETAVEL ENTIDADE POR FAMILIA
                {
                    coletavelEntidade = coletavelQuery.getColetavelEntidadeByFamilia(familia);
                }

                contadorDeColetaveis++;
                Vector3 posicao = new Vector3(eixoX[contadorColuna], boardDto.PosicoesEixoY[contadorLinha]);

                Coletavel coletavel = poolDeColetaveis.criarColetavel();
                //Debug.Log("Colocando Coletavel : " + coletavel.nome +" posicao: " + posicao);
                coletavel.ligar();
                coletavel.receberSprite(coletavelEntidade.nomeSprite);
                coletavel.colocarNaPosicao(posicao);
            }
        }
        return contadorDeColetaveis;
    }

        //TODO adicionar validacao para os coletaveis q vazam da maquina
    public void validacaoArray(int eixoY, int eixoX)
    {
        if (arrayDeColetaveis.GetLength(0) != eixoY)
        {
            Debug.LogError("QTD DE LINHAS DO ARRAY E DAS POSICOES EIXO Y ESTAO DIFERENTES.");
        }

        if (arrayDeColetaveis.GetLength(1) != eixoX)
        {
            Debug.LogError("QTD DE COLUNA DO ARRAY E DAS POSICOES EIXO X ESTAO DIFERENTES.");
        }
    }    
}
