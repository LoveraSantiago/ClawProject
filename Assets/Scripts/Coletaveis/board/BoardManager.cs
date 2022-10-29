using System.Collections;

public class BoardManager : AcaoBoardElevadoFim.ProdutorEvento,
                            Fornecedor<ColetaveisDescartadosDto>
{   
    private BoardDto boardDto;

    public  BoardElevador elevador { get; private set; }
    private BoardDevolvedor devolvedor;

    private BoardMontador montador; 
    private BoardMontador montadorExtra;

    public BoardManager(BoardDto boardDto)
    {
        this.boardDto = boardDto;
        devolvedor    = new BoardDevolvedor();        
        elevador      = new BoardElevador();        
    }

    public void configuradoPeloLevel(AbstractLevel level, BoardDto boardDto)
    {
        montador      = FactoryBoardMontador.getMontadorByLevel(level, boardDto.GoBoardPosicao);
        montadorExtra = FactoryBoardMontador.getMontadorExtraByLevel(level, boardDto.GoBoardPosicao);
        devolvedor.configuradoPeloLevel(level.devolverParaBoard());
    }   

    public IEnumerator create()
    {
        yield return montador.createBoard(boardDto);
        yield return montadorExtra.createBoard(boardDto);        
    }   

    public int subirBoard()
    {
        int qtdColetaveis = montadorExtra.getQtdAcrescentada();
        ContextoEstaticoUtils.MonoBehaviour.StartCoroutine(elevador.subirBoardComPool(boardDto, montadorExtra));
        return qtdColetaveis;
    }       

    public void devolver(bool combinacaoValida, ColetadoFimDto evento, Coletavel[] coletados)
    {
        devolvedor.devolver(combinacaoValida, evento, boardDto, coletados);        
    }

    public bool isDevolverBoard()
    {
        return devolvedor.devolverBoard;
    }

    public ColetaveisDescartadosDto fornecer()
    {
        return devolvedor.fornecer();
    }

    ProdutorDeEvento<SubidaBoardAcaoFim> AcaoBoardElevadoFim.ProdutorEvento.getProdutorDeEvento()
    {
        return ((AcaoBoardElevadoFim.ProdutorEvento)elevador).getProdutorDeEvento();
    }    
}
