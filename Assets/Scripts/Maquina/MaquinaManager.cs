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

        botoesPowerUp = new BotoesPowerUp(maquinaDto.PowerUpDto, inputGame, monoBehaviour);
    }

    public void update()
    {
        botoesPowerUp.update();
    }

    public void fixedUpdate()
    {
        joystickHaste.fixedUpdate();
    }

    public void recebendoPowerUp(AcaoBotaoPowerUp acaoBotaoPowerUp)
    {
        botoesPowerUp.recebendoPowerUp(acaoBotaoPowerUp);
    }

    public void beginDragPowerUp(Vector2 posicao)
    {
        botoesPowerUp.beginDrag(posicao);
    }

    public void onDragPowerUp(Vector2 delta)
    {
        botoesPowerUp.drag(delta);
    }

    public void onEndDragPowerUp()
    {
        botoesPowerUp.endDrag();
    }    

    //CONSUMIDORES DE EVENTOS INICIO
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

    public ConsumidorDeEvento<PowerUp> getConsumidorDePowerUp()
    {
        return displayDeScores.getConsumidorDePowerUp();
    }
    //CONSUMIDORES DE EVENTOS FIM
}
