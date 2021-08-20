using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoDisplayPowerUp : EstadoDisplay
{
    private EstadoDisplayChanger estadoChanger;

    public EstadoDisplayPowerUp(EstadoDisplayChanger estadoChanger)
    {
        this.estadoChanger = estadoChanger;
    }

    public void acionarPowerUp(
        GrupoDisplays grupoDisplays, 
        PowerUpInteracaoDisplayColetado interacaoDisplayColetado,
        InformacaoDisplayColetado informacaoDisplayColetado,
        MonoBehaviour monoBehaviour)
    {
        grupoDisplays.setarEstadoPowerUp(true);
        grupoDisplays.acionarMostrarAlvos(monoBehaviour);
        interacaoDisplayColetado.iniciar(informacaoDisplayColetado);
    }

    public IEnumerator mostrarSprite(
        float delay, GrupoDisplays grupoDisplays, 
        InformacoesColetadoDto evento, ArcoIrisEfeito arcoIris, 
        ProdutorDeEvento<ColetadoFim> produtorDeEventoFimColetagem)
    {
        yield return null;
    }
}
