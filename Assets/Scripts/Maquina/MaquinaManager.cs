using UnityEngine;

public class MaquinaManager 
{
    private DisplayDeColetados displayDeImgs;
    private DisplayDeScores displayDeScores;
    private JoystickHaste joystickHaste;
    private BotoesPowerUp botoesPowerUp;

    public MaquinaManager(MaquinaDto maquinaDto, float velocidadeJoystick, InputGame inputGame, MonoBehaviour monoBehaviour)
    {
        displayDeImgs   = new DisplayDeColetados(maquinaDto.DisplayDeColetadoDto, monoBehaviour);
        displayDeScores = new DisplayDeScores(maquinaDto.DisplayDeScoreDto, monoBehaviour);
        joystickHaste   = new JoystickHaste(maquinaDto.HasteJoystick, velocidadeJoystick);
    }

    public void update()
    {
        botoesPowerUp.update();
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
