using UnityEngine;

public interface InformacaoDisplayColetado 
{
    bool acertouDisplay(Vector2 toque);
    bool isTodosDisplaysDesocupados();
    int getQtdDisplaysOcupados();
    void restartPowerUp(PowerUpEnums.TIPO tipo, PowerUpInteracaoComDisplayColetado interacao);
    void restaurarEstadoAntesPowerUp(Executor executor);
}
