using System.Collections;
using UnityEngine;

public class BoardElevador : AcaoBoardElevadoFim.ProdutorEvento
{
    private ProdutorDeEvento<SubidaBoardAcaoFim> produtorDeEvento;

    public BoardElevador()
    {
        produtorDeEvento = new ProdutorDeEvento<SubidaBoardAcaoFim>();
    }

    public IEnumerator subirBoardComPool(BoardDto boardDto, BoardMontador montadorExtra)
    {
        yield return new WaitForSeconds(0.6f);

        BoardElevadorReferencias refs = new BoardElevadorReferencias();
        refs.iniciarRefs(boardDto);
        
        HelperColetaveisInGame.fixarTodosColetaveisEixoXY();
        while (isBoardAbaixoDoLimite(boardDto, refs.limite))
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
            refs.setarRefs(boardDto);

            HelperColetaveisInGame.desafixarTodosColetaveisXY();
            yield return montadorExtra.createBoard(boardDto);

            float acrescimoFinal = boardDto.BoardPosicao.position.y - refs.acrescimo;
            produtorDeEvento.produziuEvento(SubidaBoardAcaoFim.of(acrescimoFinal));
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
        return HelperColetaveisInGame.isAlgumColetavelAcimaDaHaltura(boardDto.LimiteSubida);        
    }

    ProdutorDeEvento<SubidaBoardAcaoFim> AcaoBoardElevadoFim.ProdutorEvento.getProdutorDeEvento()
    {
        return produtorDeEvento;
    }
}
