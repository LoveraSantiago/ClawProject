using System.Collections;
using UnityEngine;

public class BoardManager 
{    
    private bool devolverParaBoard;
    
    private int[,] arrayDeColetaveisSub;

    private BoardDto boardDto;

    private PoolList<ColetavelTile> poolExtraSubs;
    private BoardMontador montador;

    public BoardManager(BoardDto boardDto)
    {
        this.boardDto = boardDto;
        montador = new BoardMontador();
    }

    public void configuradoPeloLevel(AbstractLevel level)//TODO CRIAR INTERFACE PADRONIZAR CONFIGURADOS PELO LEVEL ALEM DE ADICIONAR SEMANTICA
    {        
        montador.configuradoPeloLevel(level);
        montador.validacaoArray(boardDto.PosicoesEixoY.Length, boardDto.PosicoesEixoXPar.Length);

        arrayDeColetaveisSub = level.getArrayDeColetaveisSub();

        devolverParaBoard = level.devolverParaBoard();        

        if (hasExtraSubColetaveis())
        {
            poolExtraSubs = new PoolList<ColetavelTile>();
        }
    }

    public int create(PoolDeColetaveis poolDeColetaveis)
    {
        int qtdColetaveisCriados = montador.create(boardDto, poolDeColetaveis);
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

    public void createSub(PoolDeColetaveis poolDeColetaveis)
    {       
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
                poolExtraSubs.addObjeto(coletavel);
            }
        }
    }    

    private bool hasExtraSubColetaveis()
    {
        return arrayDeColetaveisSub != null;
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
}
