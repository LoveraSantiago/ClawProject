using System.Collections;
using UnityEngine;

public class BoardDevolvedor 
{
    private bool devolverBoard;

    public void configuradoPeloLevel(bool devolverParaBoard)
    {
        this.devolverBoard = devolverParaBoard;
    }

    public void devolver(BoardDto boardDto, ColetavelTile[] coletados)
    {
        if (devolverBoard && coletados.Length > 0)
        {            
            Utils.MonoBehaviour.StartCoroutine(devolverParaBoard(boardDto, coletados));            
        }
    }

    private IEnumerator devolverParaBoard(BoardDto boardDto, ColetavelTile[] coletados)
    {
        for (int contador = 0; contador < coletados.Length; contador++)
        {
            float anguloDevolucao = Random.Range(180, 230);
            ColetavelTile coletavel = coletados[contador];
            coletavel.ligar();            
            coletavel.disparar(boardDto.PosicaoRefVoltaBoard.position, anguloDevolucao, 10f);

            yield return new WaitForSeconds(boardDto.DelayVoltaBoard);
        }
        yield return null;
    }
}
