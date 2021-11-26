using System.Collections;
using UnityEngine;

public class BoardElevador : AcaoBoardElevadoFim.ProdutorEvento
{
    private ProdutorDeEvento<SubidaBoardAcaoFim> produtorDeEvento;

    public BoardElevador()
    {
        produtorDeEvento = new ProdutorDeEvento<SubidaBoardAcaoFim>();
    }

    public IEnumerator subirBoardComPool(BoardDto boardDto, BoardMontadorExtra montadorExtra, PoolDeColetaveis poolDeColetaveis)
    {
        yield return new WaitForSeconds(0.6f);

        float limite                  = boardDto.BoardPosicao.position.y + boardDto.Subida;
        Vector3 posInicialParedeAlta  = boardDto.ParedeAlta.position;
        Vector3 posInicialParedeBaixa = boardDto.ParedeBaixa.position;
        Vector3 posVoltaBoard         = boardDto.PosicaoRefVoltaBoard.position;
        float acrescimo               = boardDto.BoardPosicao.position.y;

        poolDeColetaveis.executeEmTodosColetaveis(new FixadorEixosXY());

        while (isBoardAbaixoDoLimite(boardDto, limite))
        {
            subirBoard(boardDto);
            yield return new WaitForFixedUpdate();
        }

        if (isAlgumColetavelAcimaDoLimiteGameOver(boardDto, poolDeColetaveis))
        {
            produtorDeEvento.produziuEvento(SubidaBoardAcaoFim.ofGameOver());
        }
        else
        {
            boardDto.ParedeAlta.position           = posInicialParedeAlta;
            boardDto.ParedeBaixa.position          = posInicialParedeBaixa;
            boardDto.PosicaoRefVoltaBoard.position = posVoltaBoard;

            poolDeColetaveis.executeEmTodosColetaveis(new DesafixadorEixosXY());
            montadorExtra.create(boardDto);

            acrescimo = boardDto.BoardPosicao.position.y - acrescimo;
            produtorDeEvento.produziuEvento(SubidaBoardAcaoFim.of(acrescimo));
        }
        yield return null;
    }

    private bool isBoardAbaixoDoLimite(BoardDto boardDto, float limite)
    {
        return boardDto.BoardPosicao.position.y < limite;
    }

    private void subirBoard(BoardDto boardDto)
    {
        boardDto.BoardPosicao.position += new Vector3(0, boardDto.VelocidadeSubida * Time.fixedDeltaTime, 0);
    }    

    private bool isAlgumColetavelAcimaDoLimiteGameOver(BoardDto boardDto, PoolDeColetaveis poolDeColetaveis)
    {
        return poolDeColetaveis.temEmAlgumColetavel(new AcimaHalturaColetavel(boardDto.LimiteSubida));
    }

    ProdutorDeEvento<SubidaBoardAcaoFim> AcaoBoardElevadoFim.ProdutorEvento.getProdutorDeEvento()
    {
        return produtorDeEvento;
    }
}
