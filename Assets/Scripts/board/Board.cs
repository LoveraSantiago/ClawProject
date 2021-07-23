using System.Collections;
using UnityEngine;

public class Board 
{    
    private bool devolverParaBoard;

    private int[,] arrayDeColetaveis;
    private int[,] arrayDeColetaveisSub;

    private BoardDto boardDto;
    private ColetavelEntidade.FAMILIA familia;

    private PoolList<ColetavelTile> poolExtraSubs;

    public Board(BoardDto boardDto)
    {
        this.boardDto = boardDto;        
    }

    public void configuradoPeloLevel(AbstractLevel level)
    {
        arrayDeColetaveis = level.getArrayDeColetaveis();
        arrayDeColetaveisSub = level.getArrayDeColetaveisSub();

        familia = level.getFamiliaColetavel();
        devolverParaBoard = level.devolverParaBoard();
        validacaoArray(arrayDeColetaveis);

        if (hasExtraSubColetaveis())
        {
            poolExtraSubs = new PoolList<ColetavelTile>();
        }
    }

    public int create(PoolDeColetaveis poolDeColetaveis)
    {
        int qtdColetaveisCriados = createNormal(poolDeColetaveis);
        createSub(poolDeColetaveis);
        return qtdColetaveisCriados;
    }   

    public void devolver(ColetavelTile[] coletados, MonoBehaviour monoBehaviour)
    {
        if (devolverParaBoard)
        {
            if (coletados.Length > 0)
            {
                monoBehaviour.StartCoroutine(coroutineDevolverParaBoard(coletados));
            }
        }       
    }

    public int ativarColetaveisSub()
    {
        int contadorAtivados = 0;
        while (poolExtraSubs.hasObjeto())
        {
            ColetavelTile coletavel = poolExtraSubs.getObjeto();
            coletavel.colocarNoLayerNormal();
            contadorAtivados++;
        }
        poolExtraSubs.reclicarPool();        

        return contadorAtivados;
    }
   
    private int createNormal(PoolDeColetaveis poolDeColetaveis)
    {
        int contadorDeColetaveis = 0;

        ColetavelQuery coletavelQuery = new ColetavelQuery();
        for (int contadorLinha = 0; contadorLinha < boardDto.PosicoesEixoY.Length; contadorLinha++)
        {
            float[] eixoX = getEixoX(contadorLinha);
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

    public void createSub(PoolDeColetaveis poolDeColetaveis)
    {
        Debug.Log("criando subs");
        if(hasExtraSubColetaveis())
        {
            ColetavelQuery coletavelQuery = new ColetavelQuery();

            float [] eixoX = getEixoX(0);
            for (int contadorColuna = 0; contadorColuna < eixoX.Length; contadorColuna++)
            {                
                int id = arrayDeColetaveisSub[0, contadorColuna];
                ColetavelEntidade coletavelEntidade = coletavelQuery.getColetavelEntidadeById(id);

                if (coletavelEntidade.isVazio())//SE FOR VAZIO VAI PARA A PROXIMA ITERACAO
                {
                    continue;
                }
                else if (coletavelEntidade.isRandom())//SE FOR RANDOMICO SORTEIA UM COLETAVEL ENTIDADE POR FAMILIA
                {
                    coletavelEntidade = coletavelQuery.getColetavelEntidadeByFamilia(familia);
                }

                Vector3 posicao = new Vector3(eixoX[contadorColuna], boardDto.PosAlturaSub, 0);
                ColetavelTile coletavel = poolDeColetaveis.criarColetavel();
                coletavel.colocarNoLayerElevador();
                coletavel.ligar();
                coletavel.receberSprite(coletavelEntidade.nomeSprite);
                coletavel.colocarNaPosicao(posicao);
                Debug.Log("coletavel sub nome: " + coletavel.nome + " pos: " + posicao);

                poolExtraSubs.addObjeto(coletavel);
            }
        }
    }    

    private bool hasExtraSubColetaveis()
    {
        return arrayDeColetaveisSub != null;
    }

    private float[] getEixoX(int indice)
    {
        if(indice % 2 == 0)
        {
            return boardDto.PosicoesEixoXPar;
        }
        else
        {
            return boardDto.PosicoesEixoXImpar;
        }
    }    

    private IEnumerator coroutineDevolverParaBoard(ColetavelTile[] coletados)
    {
        yield return new WaitForSeconds(boardDto.DelayInicialVoltaBoard);

        for (int contador = 0; contador < coletados.Length; contador++)
        {
            float anguloDevolucao = Random.Range(180, 230);
            Coletavel coletavel = coletados[contador];
            coletavel.ligar();
            coletavel.disparar(boardDto.PosicaoRefVoltaBoard.position, anguloDevolucao, 10f);

            yield return new WaitForSeconds(boardDto.DelayVoltaBoard);
        }
        yield return null;
    }

    //TODO adicionar validacao para os coletaveis q vazam da maquina
    private void validacaoArray(int[,] arrayDeColetaveis)
    {
        if (arrayDeColetaveis.GetLength(0) != boardDto.PosicoesEixoY.Length)
        {
            Debug.LogError("QTD DE LINHAS DO ARRAY E DAS POSICOES EIXO Y ESTAO DIFERENTES.");
        }

        if (arrayDeColetaveis.GetLength(1) != boardDto.PosicoesEixoXPar.Length)
        {
            Debug.LogError("QTD DE COLUNA DO ARRAY E DAS POSICOES EIXO X ESTAO DIFERENTES.");
        }
    }
}
