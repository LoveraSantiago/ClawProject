using UnityEngine;

public class MaquinaManager 
{
    private DisplayDeColetados displayDeImgs;
    private DisplayDeScores displayDeScores;
    private JoystickHaste joystickHaste;

    private BotaoPowerUp btnPUp1;
    private BotaoPowerUp btnPUp2;
    private BotaoPowerUp btnPUp3;
    private BotaoPowerUp btnPUp4;

    private InputGame inputGame;

    public MaquinaManager(MaquinaDto maquinaDto, float velocidadeJoystick, InputGame inputGame, MonoBehaviour monoBehaviour)
    {
        this.inputGame = inputGame;

        displayDeImgs   = new DisplayDeColetados(maquinaDto.DisplayDeColetadoDto, monoBehaviour);
        displayDeScores = new DisplayDeScores(maquinaDto.DisplayDeScoreDto, monoBehaviour);
        joystickHaste   = new JoystickHaste(maquinaDto.HasteJoystick, velocidadeJoystick);

        btnPUp1 = new BotaoPowerUp(maquinaDto.PowerUpDto.BtnsPowerUp[0]);
        btnPUp2 = new BotaoPowerUp(maquinaDto.PowerUpDto.BtnsPowerUp[1]);
        btnPUp3 = new BotaoPowerUp(maquinaDto.PowerUpDto.BtnsPowerUp[2]);
        btnPUp4 = new BotaoPowerUp(maquinaDto.PowerUpDto.BtnsPowerUp[3]);
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

    public void fixedUpdate()
    {
        joystickHaste.fixedUpdate();
    }

    public ConsumidorDeEvento<DirecaoDaGarra> getJoystickHasteConsumidorDirecao()
    {
        return joystickHaste.getConsumidorDeEventoDeDirecao();
    }

    public ConsumidorDeEvento<InformacoesColetado> getDisplayImagensConsumidorInfoColetado()
    {
        return displayDeImgs.getDisplayImagensConsumidor();
    }

    public ConsumidorDeEvento<InformacoesColetado> getDisplayScoreConsumidorInfoColetado()
    {
        return displayDeScores.getDisplayScoreConsumidor();
    }
}
