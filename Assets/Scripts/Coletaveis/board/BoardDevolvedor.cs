using System.Collections;
using UnityEngine;

public class BoardDevolvedor 
{
    private bool devolverParaBoard;

    public void configuradoPeloLevel(bool devolverParaBoard)
    {
        this.devolverParaBoard = devolverParaBoard;
    }

    public void devolver(BoardDto boardDto, ColetavelTile[] coletados, MonoBehaviour monoBehaviour)
    {
        if (devolverParaBoard && coletados.Length > 0)
        {            
            monoBehaviour.StartCoroutine(coroutineDevolverParaBoard(boardDto, coletados));            
        }
    }

    private IEnumerator coroutineDevolverParaBoard(BoardDto boardDto, ColetavelTile[] coletados)
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
