using System.Collections;

public class BoardManager : AcaoBoardElevadoFim.ProdutorEvento
{   
    private BoardDto boardDto;

    private BoardElevador elevador;   
    private BoardDevolvedor devolvedor;

    private BoardMontador montador; 
    private BoardMontador montadorExtra;

    public BoardManager(BoardDto boardDto)
    {
        this.boardDto = boardDto;
        devolvedor    = new BoardDevolvedor();        
        elevador      = new BoardElevador();        
    }

    public void configuradoPeloLevel(AbstractLevel level)
    {
        BoardMontador.configurar(level.getFamiliaColetavel());
        inicializarMontador(level);        
        inicializarMontadorExtra(level);        
    }   

    public IEnumerator create()
    {
        yield return montador.createBoard(boardDto);
        yield return montadorExtra.createBoard(boardDto);        
    }   

    public int subirBoard()
    {
        int qtdColetaveis = montadorExtra.getQtdAcrescentada();
        Utils.MonoBehaviour.StartCoroutine(elevador.subirBoardComPool(boardDto, montadorExtra));
        return qtdColetaveis;
    }       

    public void devolver(bool combinacaoValida, ColetadoFim evento, Coletavel[] coletados)
    {
        devolvedor.devolver(combinacaoValida, evento, boardDto, coletados);        
    }

    public bool isDevolverBoard()
    {
        return devolvedor.devolverBoard;
    }

    private void inicializarMontador(AbstractLevel level)
    {
        if (LevelUtils.isNormalLevel(level))
        {
            montador = new BoardMontadorNormal();            
        }
        else if(LevelUtils.isObstaculoLevel(level)) 
        {
            montador = new BoardMontadorObstaculos();
        }
        else if (LevelUtils.isOvoLevel(level))
        {
            montador = new BoardMontadorOvo();
        }
        else
        {
            montador = new BoardMontadorNormal();
        }
        montador.configuradoPeloLevel(level);
    }

    private void inicializarMontadorExtra(AbstractLevel level)
    {
        if (LevelUtils.isElevadorLevel(level))
        {
            montadorExtra = new BoardMontadorExtra();
            montadorExtra.configuradoPeloLevel(level);
            devolvedor.configuradoPeloLevel(level.devolverParaBoard());
        }
        else
        {
            montadorExtra = new BoardMontadorVazio();
        }
    }

    ProdutorDeEvento<SubidaBoardAcaoFim> AcaoBoardElevadoFim.ProdutorEvento.getProdutorDeEvento()
    {
        return ((AcaoBoardElevadoFim.ProdutorEvento)elevador).getProdutorDeEvento();
    }
}
