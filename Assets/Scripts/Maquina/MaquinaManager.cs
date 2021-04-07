using UnityEngine;

public class MaquinaManager 
{
    private DisplayDeImagens displayDeImgs;
    private DisplayDeScores displayDeScores;
    private JoystickHaste joystickHaste;

    public MaquinaManager(Transform hasteJoystick, float velocidade,
        SpriteRenderer[] coletadosSprites,
        GameObject[] displayScores,
        MonoBehaviour monoBehaviour)
    {
        displayDeImgs = new DisplayDeImagens(coletadosSprites, 0.5f, monoBehaviour);
        displayDeScores = new DisplayDeScores(displayScores);
        joystickHaste = new JoystickHaste(hasteJoystick, velocidade);
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
