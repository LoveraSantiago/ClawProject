public class BoardManager : AcaoBoardElevadoFim.ProdutorEvento
{   
    private BoardDto boardDto;

    private BoardElevador elevador;   
    private BoardDevolvedor devolvedor;

    private BoardMontadorNormal montador;
    private BoardMontadorExtra  montadorExtra;

    public BoardManager(BoardDto boardDto)
    {
        this.boardDto = boardDto;
        devolvedor    = new BoardDevolvedor();
        montador      = new BoardMontadorNormal();
        montadorExtra = new BoardMontadorExtra();
        elevador      = new BoardElevador();        
    }

    public void configuradoPeloLevel(AbstractLevel level)
    {
        BoardMontador.configurar(level.getFamiliaColetavel());
        montador.configuradoPeloLevel(level);

        montadorExtra.configuradoPeloLevel(level);
        devolvedor.configuradoPeloLevel(level.devolverParaBoard());        
    }

    public int create()
    {
        montador.create(boardDto);

        HelperColetaveisInGame helperInGame = new HelperColetaveisInGame();
        int qtdColetaveisCriados = helperInGame.getQtdColetaveisInGame();

        montadorExtra.create(boardDto);
        return qtdColetaveisCriados;
    }   

    public int subirBoard()
    {
        int qtdColetaveis = montadorExtra.getQtdExtras();
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

    ProdutorDeEvento<SubidaBoardAcaoFim> AcaoBoardElevadoFim.ProdutorEvento.getProdutorDeEvento()
    {
        return ((AcaoBoardElevadoFim.ProdutorEvento)elevador).getProdutorDeEvento();
    }
}
