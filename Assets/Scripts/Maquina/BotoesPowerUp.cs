using UnityEngine;

public class BotoesPowerUp 
{
    private BotaoPowerUp btnPUp1;
    private BotaoPowerUp btnPUp2;
    private BotaoPowerUp btnPUp3;
    private BotaoPowerUp btnPUp4;

    private InputGame inputGame;

    public BotoesPowerUp(PowerUpDto powerUpDto, InputGame inputGame)
    {
        this.inputGame = inputGame;

        btnPUp1 = new BotaoPowerUp(powerUpDto.BtnsPowerUp[0]);
        btnPUp2 = new BotaoPowerUp(powerUpDto.BtnsPowerUp[1]);
        btnPUp3 = new BotaoPowerUp(powerUpDto.BtnsPowerUp[2]);
        btnPUp4 = new BotaoPowerUp(powerUpDto.BtnsPowerUp[3]);
    }

    public void update()
    {
        if (inputGame.aconteceuTapNaAreaInferior())
        {
            Vector2 posicaoTap = inputGame.getPosicaoTap();
            if (btnPUp1.isPosicaoDentroAreaBotao(posicaoTap))
            {
                Debug.Log("BTN1 CRICADO!!!");
            }
            else if (btnPUp2.isPosicaoDentroAreaBotao(posicaoTap))
            {
                Debug.Log("BTN2 CRICADO!!!");
            }
            else if (btnPUp3.isPosicaoDentroAreaBotao(posicaoTap))
            {
                Debug.Log("BTN3 CRICADO!!!");
            }
            else if (btnPUp4.isPosicaoDentroAreaBotao(posicaoTap))
            {
                Debug.Log("BTN4 CRICADO!!!");
            }
        }
    }
}
