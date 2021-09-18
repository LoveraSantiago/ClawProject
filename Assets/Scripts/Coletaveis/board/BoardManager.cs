using System.Collections;
using UnityEngine;

public class BoardManager : AcaoBoardElevadoFim.ProdutorEvento
{   
    private BoardDto boardDto;

    private BoardDevolvedor devolvedor;
    private BoardMontadorNormal montador;
    private BoardMontadorExtra montadorExtra;

    private ProdutorDeEvento<BoardAcaoFim> produtorDeEvento;

    public BoardManager(BoardDto boardDto)
    {
        this.boardDto = boardDto;
        devolvedor    = new BoardDevolvedor();
        montador      = new BoardMontadorNormal();
        montadorExtra = new BoardMontadorExtra();

        produtorDeEvento = new ProdutorDeEvento<BoardAcaoFim>();
    }

    public void configuradoPeloLevel(AbstractLevel level)//TODO CRIAR INTERFACE PADRONIZAR CONFIGURADOS PELO LEVEL ALEM DE ADICIONAR SEMANTICA
    {
        BoardMontador.configurar(level.getFamiliaColetavel());
        montador.configuradoPeloLevel(level);

        montadorExtra.configuradoPeloLevel(level);
        devolvedor.configuradoPeloLevel(level.devolverParaBoard());        
    }

    public int create(PoolDeColetaveis poolDeColetaveis)
    {
        montador.create(boardDto, poolDeColetaveis);
        int qtdColetaveisCriados = poolDeColetaveis.getQtdDeColetaveis();

        montadorExtra.create(boardDto, poolDeColetaveis);
        return qtdColetaveisCriados;
    }   

    public int subirBoard(PoolDeColetaveis poolDeColetaveis)
    {
        int qtdColetaveis = montadorExtra.getQtdExtras();
        Utils.MonoBehaviour.StartCoroutine(subirBoardComPool(poolDeColetaveis));
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

    private IEnumerator subirBoardComPool(PoolDeColetaveis poolDeColetaveis)
    {
        yield return new WaitForSeconds(0.6f);
        float limite = boardDto.BoardPosicao.position.y + boardDto.Subida;        
        Vector3 posInicialParedeAlta  = boardDto.ParedeAlta.position;
        Vector3 posInicialParedeBaixa = boardDto.ParedeBaixa.position;
        Vector3 posVoltaBoard         = boardDto.PosicaoRefVoltaBoard.position;

        poolDeColetaveis.executeEmTodosColetaveis(new FixadorEixosXY());

        float acrescimo = boardDto.BoardPosicao.position.y;
        while (boardDto.BoardPosicao.position.y < limite)
        {
            boardDto.BoardPosicao.position += new Vector3(0, boardDto.VelocidadeSubida * Time.fixedDeltaTime, 0);
            yield return new WaitForFixedUpdate();
        }
        if(poolDeColetaveis.temEmAlgumColetavel(new AcimaHalturaColetavel(boardDto.LimiteSubida)))
        {
            produtorDeEvento.produziuEvento(new BoardAcaoFim(true, 0));
        }
        else
        {
            acrescimo = boardDto.BoardPosicao.position.y - acrescimo;

            boardDto.ParedeAlta.position           = posInicialParedeAlta;
            boardDto.ParedeBaixa.position          = posInicialParedeBaixa;
            boardDto.PosicaoRefVoltaBoard.position = posVoltaBoard;

            poolDeColetaveis.executeEmTodosColetaveis(new DesafixadorEixosXY());
            montadorExtra.create(boardDto, poolDeColetaveis);

            produtorDeEvento.produziuEvento(new BoardAcaoFim(false, acrescimo));
        }
        yield return null;
    }

    ProdutorDeEvento<BoardAcaoFim> AcaoBoardElevadoFim.ProdutorEvento.getProdutorDeEvento()
    {
        return produtorDeEvento;
    }
}
