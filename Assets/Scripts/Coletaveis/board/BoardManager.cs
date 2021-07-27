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

    public int subirBoard(PoolDeColetaveis poolDeColetaveis, MonoBehaviour monoBehaviour)
    {
        int qtdColetaveis = montadorExtra.getQtdExtras();
        monoBehaviour.StartCoroutine(subirBoard(poolDeColetaveis));
        return qtdColetaveis;
    }       

    public void devolver(ColetavelTile[] coletados, MonoBehaviour monoBehaviour)
    {
        devolvedor.devolver(boardDto, coletados, monoBehaviour);
    }

    private IEnumerator subirBoard(PoolDeColetaveis poolDeColetaveis)
    {
        yield return new WaitForSeconds(0.6f);
        float limite = boardDto.BoardPosicao.position.y + boardDto.Subida;        
        Vector3 posInicialParedeAlta  = boardDto.ParedeAlta.position;
        Vector3 posInicialParedeBaixa = boardDto.ParedeBaixa.position;
        Vector3 posVoltaBoard         = boardDto.PosicaoRefVoltaBoard.position;

        poolDeColetaveis.executeEmTodosColetaveis(new FixadorEixosXY());

        while (boardDto.BoardPosicao.position.y < limite)
        {
            boardDto.BoardPosicao.position += new Vector3(0, boardDto.VelocidadeSubida * Time.fixedDeltaTime, 0);
            yield return new WaitForFixedUpdate();
        }

        boardDto.ParedeAlta.position           = posInicialParedeAlta;
        boardDto.ParedeBaixa.position          = posInicialParedeBaixa;
        boardDto.PosicaoRefVoltaBoard.position = posVoltaBoard;

        poolDeColetaveis.executeEmTodosColetaveis(new DesafixadorEixosXY());
        montadorExtra.create(boardDto, poolDeColetaveis);

        produtorDeEvento.produziuEvento(null);
        yield return null;
    }

    ProdutorDeEvento<BoardAcaoFim> AcaoBoardElevadoFim.ProdutorEvento.getProdutorDeEventoColetado()
    {
        return produtorDeEvento;
    }
}
