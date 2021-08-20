using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface EstadoDisplay 
{
    void acionarPowerUp(GrupoDisplays grupoDisplays, PowerUpInteracaoDisplayColetado interacaoDisplayColetado, InformacaoDisplayColetado informacaoDisplayColetado, MonoBehaviour monoBehaviour);
    IEnumerator mostrarSprite(float delay, GrupoDisplays grupoDisplays, InformacoesColetadoDto evento, ArcoIrisEfeito arcoIris, ProdutorDeEvento<ColetadoFim> produtorDeEventoFimColetagem);
}
