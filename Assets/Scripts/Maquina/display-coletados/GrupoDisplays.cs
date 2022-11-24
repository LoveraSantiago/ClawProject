using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class GrupoDisplays 
{
    private bool powerUpDisplayColetado;    
    public SingleDisplayDeColetado[] singleDisplayDeColetado { get; private set; }
    private SomMaquina somMaquina;

    public GrupoDisplays(DisplaysColetadosDto displaysSlotsDto, SomMaquina somMaquina)
    {   
        SingleDisplayDeColetado.configurar(displaysSlotsDto);
        SingleSlotColetadoDto[] singleSlotColetadoDto = displaysSlotsDto.SingleSlotColetadoDto;
        singleDisplayDeColetado = new SingleDisplayDeColetado[singleSlotColetadoDto.Length];

        for(int contador = 0; contador < singleDisplayDeColetado.Length; contador++)
        {
            singleDisplayDeColetado[contador] = new SingleDisplayDeColetado(singleSlotColetadoDto[contador]);
        }
        this.somMaquina = somMaquina;
    }

    public void colorirDisplays(Dictionary<string, string> dicionarioDeCores)
    {
        ColoridorDisplaysColetadosV2 coloridor = new ColoridorDisplaysColetadosV2();
        coloridor.colorir(singleDisplayDeColetado, dicionarioDeCores);
    }

    public void setarEstadoPowerUp(bool estado)
    {
        powerUpDisplayColetado = estado;
    }      

    public void acionarMostrarAlvos(Executor executorFimMovimentacao)
    {
        ContextoEstaticoUtils.MonoBehaviour.StartCoroutine(singleDisplayDeColetado[0].mostrarAlvo(executorFimMovimentacao));
        ContextoEstaticoUtils.MonoBehaviour.StartCoroutine(singleDisplayDeColetado[1].mostrarAlvo(executorFimMovimentacao));
        ContextoEstaticoUtils.MonoBehaviour.StartCoroutine(singleDisplayDeColetado[2].mostrarAlvo(executorFimMovimentacao));
    }

    public void desligarAlvos(Executor executorFimMovimentacao)
    {
        ContextoEstaticoUtils.MonoBehaviour.StartCoroutine(singleDisplayDeColetado[0].desligarAlvo(executorFimMovimentacao));
        ContextoEstaticoUtils.MonoBehaviour.StartCoroutine(singleDisplayDeColetado[1].desligarAlvo(executorFimMovimentacao));
        ContextoEstaticoUtils.MonoBehaviour.StartCoroutine(singleDisplayDeColetado[2].desligarAlvo(executorFimMovimentacao));
    }

    public IEnumerator mostrarSprColetado(int indice, Sprite sprite, bool powerUpAcionado)
    {
        yield return singleDisplayDeColetado[indice].mostrarSprColetado(sprite, somMaquina, powerUpAcionado);
    }

    public IEnumerator limparSprColetado(int indice)
    {
        yield return singleDisplayDeColetado[indice].limparSprColetado(somMaquina);
    }

    public IEnumerator mostrarAlvoELimparSprColetado(int indice)
    {

        singleDisplayDeColetado[indice].mostrarAlvoSelecionado();
        yield return singleDisplayDeColetado[indice].limparSprColetado(somMaquina);
    }

    public int getIndicePrimeiroDisplayDesocupado()
    {
        if (singleDisplayDeColetado[0].isDesocupado) return 0;
        if (singleDisplayDeColetado[1].isDesocupado) return 1;
        return 2;
    }

    public bool isTodosDisplayOcupados()
    {
        return singleDisplayDeColetado[0].isOcupado && 
               singleDisplayDeColetado[1].isOcupado && 
               singleDisplayDeColetado[2].isOcupado;
    }

    public bool isTodosDisplaysDesocupados()
    {
        return singleDisplayDeColetado[0].isDesocupado && 
               singleDisplayDeColetado[1].isDesocupado && 
               singleDisplayDeColetado[2].isDesocupado;
    }   

    public int getQtdDisplaysOcupados()
    {
        int total = 0;
        if (singleDisplayDeColetado[0].isOcupado) total++;
        if (singleDisplayDeColetado[1].isOcupado) total++;
        if (singleDisplayDeColetado[2].isOcupado) total++;

        return total;
    }

    public void ligarCacaNiquel(Sprite[] sprSlot1, Sprite[] sprSlot2, Sprite[] sprSlot3)
    {
        singleDisplayDeColetado[0].ligarCacaNiquel(sprSlot1);
        singleDisplayDeColetado[1].ligarCacaNiquel(sprSlot2);
        singleDisplayDeColetado[2].ligarCacaNiquel(sprSlot3);
    }

    public void pararSlotCacaNiquel(int indice, Sprite[] sprSlots, Sprite sprSucesso)
    {
        singleDisplayDeColetado[indice].pararCacaNiquel(sprSlots, sprSucesso);
    }

    public Sprite[] getResultadosCacaNiquel()
    {
        return new Sprite[] {
            getResultadoCacaNiquel(0),
            getResultadoCacaNiquel(1),
            getResultadoCacaNiquel(2)            
        };
    }

    public Sprite getResultadoCacaNiquel(int indice)
    {
        return singleDisplayDeColetado[indice].getSprResultCacaNiquel();
    }
}
