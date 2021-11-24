using System.Collections;
using UnityEngine;

public class BoardElevador : AcaoBoardElevadoFim.ProdutorEvento
{
    private ProdutorDeEvento<BoardAcaoFim> produtorDeEvento;

    public BoardElevador()
    {
        produtorDeEvento = new ProdutorDeEvento<BoardAcaoFim>();
    }

    public IEnumerator subirBoardComPool(BoardDto boardDto, BoardMontadorExtra montadorExtra, PoolDeColetaveis poolDeColetaveis)
    {
        yield return new WaitForSeconds(0.6f);

        float limite                  = boardDto.BoardPosicao.position.y + boardDto.Subida;
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
        if (poolDeColetaveis.temEmAlgumColetavel(new AcimaHalturaColetavel(boardDto.LimiteSubida)))
        {
            produtorDeEvento.produziuEvento(new BoardAcaoFim(true, 0));
        }
        else
        {
            acrescimo = boardDto.BoardPosicao.position.y - acrescimo;

            boardDto.ParedeAlta.position = posInicialParedeAlta;
            boardDto.ParedeBaixa.position = posInicialParedeBaixa;
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
