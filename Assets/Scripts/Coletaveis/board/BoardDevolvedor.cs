using System.Collections;
using UnityEngine;

public class BoardDevolvedor : Fornecedor<ColetaveisDescartadosDto>
{
    public bool devolverBoard { get; private set; }
    private ColetaveisDescartadosDto coletaveisDevolvidos;

    public BoardDevolvedor()
    {
        coletaveisDevolvidos = new ColetaveisDescartadosDto();
    }

    public void configuradoPeloLevel(bool devolverParaBoard)
    {
        this.devolverBoard = devolverParaBoard;
    }

    public void devolver(
        bool combinacaoValida, ColetadoFimDto evento, BoardDto boardDto, Coletavel[] coletados)
    {
        if ((devolverBoard && evento.isTodosColetados() && !combinacaoValida) || 
            evento.isRollback)
        {
            Coletavel[] coletadosOriginais = ArrayUtils.copiarArray(coletados);
            ContextoEstaticoUtils.MonoBehaviour.StartCoroutine(devolverParaBoard(evento.clears, boardDto, coletadosOriginais));            
        }
    }

    public ColetaveisDescartadosDto fornecer()
    {
        return coletaveisDevolvidos;
    }

    private IEnumerator devolverParaBoard(bool[]resultados, BoardDto boardDto, Coletavel[] coletados)
    {
        //Debug.Log("Devolver para o board chamado");
        Sprite[] spritesDevolvidos = new Sprite[coletados.Length];
        for (int contador = 0; contador < coletados.Length; contador++)
        {
            if(deveDevolver(contador, coletados, resultados))
            {
                Coletavel coletavelIt = coletados[contador];
                spritesDevolvidos[contador] = coletavelIt.getSprite();
                yield return devolverColetavel(coletados[contador], boardDto);
            }
            else
            {
                yield return null;
            }
        }
        coletaveisDevolvidos.addTrinca(spritesDevolvidos);
        yield return null;
    }

    private bool deveDevolver(int contador, Coletavel[] coletados, bool[] resultados)
    {
        return coletados[contador] != null && resultados[contador];
    }

    private IEnumerator devolverColetavel(Coletavel coletavel, BoardDto boardDto)
    {
        coletavel.ligar();
        coletavel.desimantar();

        float anguloDevolucao = Random.Range(180, 230);        
        coletavel.disparar(boardDto.PosicaoRefVoltaBoard.position, anguloDevolucao, boardDto.VelocidadeDevolucao);

        if (coletavel.isOvo())
        {
            yield return new WaitForSeconds(boardDto.DelayVoltaBoardOvo);
            coletavel.ligarAnimacaoFecharOvo();
            yield return new WaitForSeconds(boardDto.DelayVoltaBoard);
        }
        else
        {
            yield return new WaitForSeconds(boardDto.DelayVoltaBoard);
        }
    }   
}
