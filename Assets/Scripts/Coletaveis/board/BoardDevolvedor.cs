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
        if (devolverBoard)
        {            
            //PAREI AQUI
            //PAREI AQUI
            //PAREI AQUI
            //PAREI AQUI
            //PAREI AQUI
            //PAREI AQUI
            //PAREI AQUI
            //PAREI AQUI
            //PAREI AQUI
            //PAREI AQUI
            //PAREI AQUI
            //PAREI AQUI
            //PAREI AQUI
            //PAREI AQUI
            Utils.MonoBehaviour.StartCoroutine(devolverParaBoard(null, boardDto, coletados));            
        }
    }

    private IEnumerator devolverParaBoard(bool[]resultados, BoardDto boardDto, ColetavelTile[] coletados)
    {
        for (int contador = 0; contador < coletados.Length; contador++)
        {
            if(coletados[contador] != null && resultados[contador])
            {
                float anguloDevolucao = Random.Range(180, 230);
                ColetavelTile coletavel = coletados[contador];
                coletavel.ligar();            
                coletavel.disparar(boardDto.PosicaoRefVoltaBoard.position, anguloDevolucao, 10f);

                yield return new WaitForSeconds(boardDto.DelayVoltaBoard);
            }
            else
            {
                yield return null;
            }
        }
        yield return null;
    }
}
