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

    public void configuradoPeloLevel(AbstractLevel level, BoardDto boardDto)
    {
        BoardMontador.configurar(level.getFamiliaColetavel());
        montador      = FactoryBoardMontador.getMontadorByLevel(level);
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
        Utils.MonoBehaviour.StartCoroutine(elevador.subirBoardComPool(boardDto, montadorExtra));
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

    ProdutorDeEvento<SubidaBoardAcaoFim> AcaoBoardElevadoFim.ProdutorEvento.getProdutorDeEvento()
    {
        return ((AcaoBoardElevadoFim.ProdutorEvento)elevador).getProdutorDeEvento();
    }
}
