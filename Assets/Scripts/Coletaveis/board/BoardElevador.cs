using System.Collections;
using UnityEngine;

public class BoardElevador : AcaoBoardElevadoFim.ProdutorEvento
{
    private ProdutorDeEvento<SubidaBoardAcaoFim> produtorDeEvento;

    public BoardElevador()
    {
        produtorDeEvento = new ProdutorDeEvento<SubidaBoardAcaoFim>();
    }

    public IEnumerator subirBoardComPool(BoardDto boardDto, BoardMontadorExtra montadorExtra)
    {
        yield return new WaitForSeconds(0.6f);

        float limite                  = boardDto.BoardPosicao.position.y + boardDto.Subida;
        Vector3 posInicialParedeAlta  = boardDto.ParedeAlta.position;
        Vector3 posInicialParedeBaixa = boardDto.ParedeBaixa.position;
        Vector3 posVoltaBoard         = boardDto.PosicaoRefVoltaBoard.position;
        float acrescimo               = boardDto.BoardPosicao.position.y;

        HelperColetaveisInGame helperInGame = new HelperColetaveisInGame();
        helperInGame.fixarTodosColetaveisEixoXY();

        while (isBoardAbaixoDoLimite(boardDto, limite))
        {
            subirBoard(boardDto);
            yield return new WaitForFixedUpdate();
        }

        if (isAlgumColetavelAcimaDoLimiteGameOver(boardDto))
        {
            produtorDeEvento.produziuEvento(SubidaBoardAcaoFim.ofGameOver());
        }
        else
        {
            boardDto.ParedeAlta.position           = posInicialParedeAlta;
            boardDto.ParedeBaixa.position          = posInicialParedeBaixa;
            boardDto.PosicaoRefVoltaBoard.position = posVoltaBoard;

            helperInGame.desafixarTodosColetaveisXY();
            montadorExtra.createBoard(boardDto);

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

    private bool isAlgumColetavelAcimaDoLimiteGameOver(BoardDto boardDto)
    {
        HelperColetaveisInGame helperInGame = new HelperColetaveisInGame();
        return helperInGame.isAlgumColetavelAcimaDaHaltura(boardDto.LimiteSubida);        
    }

    ProdutorDeEvento<SubidaBoardAcaoFim> AcaoBoardElevadoFim.ProdutorEvento.getProdutorDeEvento()
    {
        return produtorDeEvento;
    }
}
