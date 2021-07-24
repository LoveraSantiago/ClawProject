using UnityEngine;

public class BoardManager 
{   
    private BoardDto boardDto;

    private BoardDevolvedor devolvedor;
    private BoardMontador montador;
    private BoardMontadorExtra montadorExtra;    

    public BoardManager(BoardDto boardDto)
    {
        this.boardDto = boardDto;
        devolvedor    = new BoardDevolvedor();
        montador      = new BoardMontador();
        montadorExtra = new BoardMontadorExtra();
    }

    public void configuradoPeloLevel(AbstractLevel level)//TODO CRIAR INTERFACE PADRONIZAR CONFIGURADOS PELO LEVEL ALEM DE ADICIONAR SEMANTICA
    {        
        montador.configuradoPeloLevel(level);
        montador.validacaoArray(boardDto.PosicoesEixoY.Length, boardDto.PosicoesEixoXPar.Length);

        montadorExtra.configuradoPeloLevel(level);
        devolvedor.configuradoPeloLevel(level.devolverParaBoard());        
    }

    public int create(PoolDeColetaveis poolDeColetaveis)
    {
        int qtdColetaveisCriados = montador.create(boardDto, poolDeColetaveis);
        createSub(poolDeColetaveis);
        return qtdColetaveisCriados;
    }   

    public void devolver(ColetavelTile[] coletados, MonoBehaviour monoBehaviour)
    {
        devolvedor.devolver(boardDto, coletados, monoBehaviour);
    }

    public int ativarColetaveisSub()
    {
        return montadorExtra.ativarColetaveisSub();
    } 

    public void createSub(PoolDeColetaveis poolDeColetaveis)
    {
        montadorExtra.create(boardDto, poolDeColetaveis);
    }           
}
