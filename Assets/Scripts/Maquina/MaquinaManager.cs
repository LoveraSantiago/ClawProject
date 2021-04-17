using UnityEngine;

public class MaquinaManager : ConsumidorDeEvento<InformacoesColetado>,
                              ConsumidorDeEvento<Utils.EventoVazioPowerUpFim>
{
    private DisplayDeColetados displayDeColetados;
    private DisplayDeScores displayDeScores;
    private JoystickHaste joystickHaste;
    private BotoesPowerUp botoesPowerUp;

    public MaquinaManager(MaquinaDto maquinaDto, float velocidadeJoystick, InputGame inputGame, MonoBehaviour monoBehaviour)
    {
        displayDeColetados   = new DisplayDeColetados(maquinaDto.DisplayDeColetadoDto, monoBehaviour);
        displayDeScores = new DisplayDeScores(maquinaDto.DisplayDeScoreDto, monoBehaviour);
        joystickHaste   = new JoystickHaste(maquinaDto.HasteJoystick, velocidadeJoystick);

        botoesPowerUp = new BotoesPowerUp(maquinaDto.BotoesPowerUpDto, inputGame, monoBehaviour);
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

    private void processarInformacoesDoColetado(InformacoesColetado infoColetado)
    {
        displayDeColetados.adicionarSpriteAoDisplay(infoColetado.sprite, infoColetado.resetDisplay);
        displayDeScores.mostrarScore(infoColetado.score, infoColetado.resultCombinacao);
    }

    private void processarFimDePowerUp()
    {
        displayDeScores.finalizarContatemRegressiva();
        botoesPowerUp.desacionarBotao();
    }

    //IMPLEMENTACAO INTERFACE CONSUMIDORDEEVENTO<INFORMACOESCOLETADO> INICIO
    public void consumirEvento(InformacoesColetado infoColetado)
    {
        processarInformacoesDoColetado(infoColetado);
    }
    //IMPLEMENTACAO INTERFACE CONSUMIDORDEEVENTO<INFORMACOESCOLETADO> FIM

    //IMPLEMENTACAO CONSUMIDORDEEVENTO<INT> INICIO
    public void consumirEvento(Utils.EventoVazioPowerUpFim evento)
    {
        processarFimDePowerUp();
    }
    //IMPLEMENTACAO CONSUMIDORDEEVENTO<INT> FIM

    //CONSUMIDORES DE EVENTOS INICIO
    public ConsumidorDeEvento<DirecaoDaGarra> getJoystickHasteConsumidorDirecao()
    {
        return joystickHaste.getConsumidorDeEventoDeDirecao();
    }    

    public ConsumidorDeEvento<InformacoesColetado> getConsumidorInfoColetado()
    {
        return this;
    }

    public ConsumidorDeEvento<PowerUpInfo> getConsumidorDePowerUpInfo()
    {
        return displayDeScores.getConsumidorDePowerUpInfo();
    }

    public ConsumidorDeEvento<Utils.EventoVazioPowerUpFim> getConsumidorDePowerUpFim()
    {
        return this;
    }   
    //CONSUMIDORES DE EVENTOS FIM
}
