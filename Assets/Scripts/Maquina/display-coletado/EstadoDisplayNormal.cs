using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoDisplayNormal : EstadoDisplay
{
    private EstadoDisplayChanger estadoChanger;

    public EstadoDisplayNormal(EstadoDisplayChanger estadoChanger)
    {
        this.estadoChanger = estadoChanger;
    }

    public void acionarPowerUp(
        GrupoDisplays grupoDisplays,
        PowerUpInteracaoDisplayColetado interacaoDisplayColetado,
        InformacaoDisplayColetado informacaoDisplayColetado,
        MonoBehaviour monoBehaviour)
    {
        
    }

    public IEnumerator mostrarSprite(
        float delay, GrupoDisplays grupoDisplays, 
        InformacoesColetadoDto evento, ArcoIrisEfeito arcoIris,
        ProdutorDeEvento<ColetadoFim> produtorDeEventoFimColetagem)
    {
        int indiceDesocupado = grupoDisplays.getIndicePrimeiroDisplayDesocupado();
        DisplayDeColetado[] displayDeColetado = grupoDisplays.displayDeColetado;
        yield return displayDeColetado[indiceDesocupado].subirSlotBaixo(evento.sprite);

        if (grupoDisplays.isTodosDisplayOcupados())
        {
            if (evento.resultCombinacao)
            {
                arcoIris.ligarBlinkVerde();
            }
            else
            {
                arcoIris.ligarBlinkRed();
            }

            yield return displayDeColetado[0].descerSlotBaixo();
            yield return displayDeColetado[1].descerSlotBaixo();
            yield return displayDeColetado[2].descerSlotBaixo();
            yield return new WaitForSeconds(delay);

            arcoIris.desligarEfeito();
            produtorDeEventoFimColetagem.produziuEvento(new ColetadoFim(true, true, true));
        }
        else
        {
            produtorDeEventoFimColetagem.produziuEvento(new ColetadoFim(false, false, false));
        }
    }
}
