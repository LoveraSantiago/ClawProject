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

    public void configuradoPeloLevel(BoardDto boardDto)
    {
        montador      = FactoryBoardMontador.getMontadorByLevel(boardDto.GoBoardPosicao);
        montadorExtra = FactoryBoardMontador.getMontadorExtraByLevel(boardDto.GoBoardPosicao);
        devolvedor.configuradoPeloLevel(ContextoEstaticoUtils.level.devolverParaBoard());
    }   

    public IEnumerator create()
    {
        yield return montador.createBoard(boardDto);
        yield return montadorExtra.createBoard(boardDto);        
    }   

    public int subirBoard()
    {
        int qtdColetaveis = montadorExtra.getQtdAcrescentada();
        ContextoEstaticoUtils.monoBehaviour.StartCoroutine(elevador.subirBoardComPool(boardDto, montadorExtra));
        return qtdColetaveis;
    }       

    public void devolver(ContadorManager contador, ColetadoFimDto evento, SomColetagem somColetagem)
    {
        devolvedor.devolver(contador, evento, boardDto, somColetagem);        
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
