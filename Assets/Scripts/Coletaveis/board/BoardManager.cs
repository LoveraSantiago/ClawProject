using System.Collections;
using UnityEngine;

public class BoardManager 
{    
    private bool devolverParaBoard;
    private BoardDto boardDto;

    private BoardMontador montador;
    private BoardMontadorExtra montadorExtra;    

    public BoardManager(BoardDto boardDto)
    {
        this.boardDto = boardDto;
        montador = new BoardMontador();
        montadorExtra = new BoardMontadorExtra();
    }

    public void configuradoPeloLevel(AbstractLevel level)//TODO CRIAR INTERFACE PADRONIZAR CONFIGURADOS PELO LEVEL ALEM DE ADICIONAR SEMANTICA
    {        
        montador.configuradoPeloLevel(level);
        montador.validacaoArray(boardDto.PosicoesEixoY.Length, boardDto.PosicoesEixoXPar.Length);

        montadorExtra.configuradoPeloLevel(level);       

        devolverParaBoard = level.devolverParaBoard();        
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
        return montadorExtra.ativarColetaveisSub();
    } 

    public void createSub(PoolDeColetaveis poolDeColetaveis)
    {
        montadorExtra.create(boardDto, poolDeColetaveis);
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
