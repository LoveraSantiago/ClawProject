using UnityEngine;

public class BoardElevadorReferencias 
{
    public float limite { get; private set; }
    public Vector3 posInicialParedeAlta { get; private set; }
    public Vector3 posInicialParedeBaixa { get; private set; }
    public Vector3 posVoltaBoard { get; private set; }
    public float acrescimo { get; private set; }

    public void iniciarRefs(BoardDto boardDto)
    {
        limite                = boardDto.BoardPosicao.position.y + boardDto.Subida;
        posInicialParedeAlta  = boardDto.ParedeAlta.position;
        posInicialParedeBaixa = boardDto.ParedeBaixa.position;
        posVoltaBoard         = boardDto.PosicaoRefVoltaBoard.position;
        acrescimo             = boardDto.BoardPosicao.position.y;
    }

    public void setarRefs(BoardDto boardDto)
    {
        boardDto.ParedeAlta.position = posInicialParedeAlta;
        boardDto.ParedeBaixa.position = posInicialParedeBaixa;
        boardDto.PosicaoRefVoltaBoard.position = posVoltaBoard;
    }
}
