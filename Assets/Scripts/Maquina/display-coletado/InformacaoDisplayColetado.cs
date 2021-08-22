using UnityEngine;

public interface InformacaoDisplayColetado 
{
    bool acertouDisplay(Vector2 toque);
    bool isTodosDisplaysDesocupados();
    void restartPowerUp(PowerUpInteracaoDisplayColetado interacao);
}
