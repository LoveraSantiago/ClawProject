using UnityEngine;

public interface InformacaoDisplayColetado 
{
    bool acertouDisplay(Vector2 toque);
    bool isTodosDisplaysDesocupados();
    void restartPowerUp(PowerUpEntidade.TIPO tipo, PowerUpInteracaoDisplayColetado interacao);
}
