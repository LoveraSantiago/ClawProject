using UnityEngine;

public class MaquinaManager 
{
    private DisplayDeColetados displayDeImgs;
    private DisplayDeScores displayDeScores;
    private JoystickHaste joystickHaste;

    public MaquinaManager(MaquinaDto maquinaDto, float velocidadeJoystick, MonoBehaviour monoBehaviour)
    {
        displayDeImgs = new DisplayDeColetados(maquinaDto.DisplayDeColetadoDto, monoBehaviour);
        displayDeScores = new DisplayDeScores(maquinaDto.GosDisplayScores);
        joystickHaste = new JoystickHaste(maquinaDto.HasteJoystick, velocidadeJoystick);
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
