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
        montador      = new BoardMontadorNormal();        
        elevador      = new BoardElevador();        
    }

    public void configuradoPeloLevel(AbstractLevel level)
    {
        BoardMontador.configurar(level.getFamiliaColetavel());
        montador.configuradoPeloLevel(level);
        inicializarMontadorExtra(level);        
    }

    public int create()
    {
        montador.createBoard(boardDto);

        HelperColetaveisInGame helperInGame = new HelperColetaveisInGame();
        int qtdColetaveisCriados = helperInGame.getQtdColetaveisInGame();

        montadorExtra.createBoard(boardDto);
        return qtdColetaveisCriados;
    }   

    public int subirBoard()
    {
        int qtdColetaveis = montadorExtra.getQtdAcrescentada();
        Utils.MonoBehaviour.StartCoroutine(elevador.subirBoardComPool(boardDto, montadorExtra));
        return qtdColetaveis;
    }       

    public void devolver(bool combinacaoValida, ColetadoFim evento, ColetavelTile[] coletados)
    {
        devolvedor.devolver(combinacaoValida, evento, boardDto, coletados);        
    }

    public bool isDevolverBoard()
    {
        return devolvedor.devolverBoard;
    }

    private void inicializarMontadorExtra(AbstractLevel level)
    {
        if (level.isElevadorLevel())
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
