using System.Collections;
using UnityEngine;

public class BoardDevolvedor 
{
    public bool devolverBoard { get; private set; }

    public void configuradoPeloLevel(bool devolverParaBoard)
    {
        this.devolverBoard = devolverParaBoard;
    }

    public void devolver(
        bool combinacaoValida, ColetadoFim evento, BoardDto boardDto, Coletavel[] coletados)
    {
        if ((devolverBoard && evento.isTodosColetados() && !combinacaoValida) || 
            evento.isRollback)
        {
            Coletavel[] coletadosOriginais = Utils.copiarArray(coletados);
            Utils.MonoBehaviour.StartCoroutine(devolverParaBoard(evento.clears, boardDto, coletadosOriginais));            
        }
    }

    private IEnumerator devolverParaBoard(bool[]resultados, BoardDto boardDto, Coletavel[] coletados)
    {
        Debug.Log("Devolver para o board chamado");
        for (int contador = 0; contador < coletados.Length; contador++)
        {
            if(coletados[contador] != null && resultados[contador])
            {
                float anguloDevolucao = Random.Range(180, 230);
                Coletavel coletavel = coletados[contador];
                coletavel.ligar();
                coletavel.desimantar();
                coletavel.disparar(boardDto.PosicaoRefVoltaBoard.position, anguloDevolucao, boardDto.VelocidadeDevolucao);

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
