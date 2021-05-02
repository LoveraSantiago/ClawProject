using UnityEngine;

public class MaquinaManager : ConsumidorDeEvento<InformacoesColetado>,
                              ConsumidorDeEvento<PowerUpInfoFim>
{
    private DisplaysDeColetados displayDeColetados;
    private DisplayDeScores displayDeScores;
    private JoystickHaste joystickHaste;
    private BotoesPowerUp botoesPowerUp;

    //TODO RESOLVER EXCECO DE ARGUMENTOS NO CONSTRUTOR
    public MaquinaManager(MaquinaDto maquinaDto, float velocidadeJoystick, 
        PowerUp.TIPO[] arrayDePowerUpsParaBotoes,
        InputGame inputGame, MonoBehaviour monoBehaviour)
    {
        displayDeColetados = new DisplaysDeColetados(maquinaDto.DisplayDeColetadoDto, monoBehaviour);
        displayDeScores    = new DisplayDeScores(maquinaDto.DisplayDeScoreDto, monoBehaviour);
        joystickHaste      = new JoystickHaste(maquinaDto.HasteJoystick, velocidadeJoystick);
        botoesPowerUp      = new BotoesPowerUp(maquinaDto.BotoesPowerUpDto, arrayDePowerUpsParaBotoes, inputGame);
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

    public void onEndDragPowerUp(MonoBehaviour monoBehaviour)
    {
        botoesPowerUp.endDrag(monoBehaviour);
    }

    private void processarInformacoesDoColetado(InformacoesColetado infoColetado)
    {        
        displayDeColetados.adicionarSpriteAoDisplay(infoColetado.sprite, infoColetado.resultCombinacao);
        displayDeScores.mostrarScore(infoColetado.score, infoColetado.resultCombinacao);
    }

    private void processarPreFimDePowerUp()
    {
        displayDeScores.piscarAsteriscos();
    }

    private void processarFimDePowerUp()
    {
        displayDeScores.mostrarPontuacaoAcumulada();
        botoesPowerUp.desacionarBotao();
    }

    //IMPLEMENTACAO INTERFACE CONSUMIDORDEEVENTO<INFORMACOESCOLETADO> INICIO
    public void consumirEvento(InformacoesColetado infoColetado)
    {
        processarInformacoesDoColetado(infoColetado);
    }
    //IMPLEMENTACAO INTERFACE CONSUMIDORDEEVENTO<INFORMACOESCOLETADO> FIM

    //IMPLEMENTACAO CONSUMIDORDEEVENTO<INT> INICIO
    public void consumirEvento(PowerUpInfoFim powerUpInfoFim)
    {
        Debug.Log("Fim chamado");
        if (powerUpInfoFim.preFinalizar)
        {
            Debug.Log("Prefim");
            processarPreFimDePowerUp();
        }
        if (powerUpInfoFim.finalizar)
        {
            Debug.Log("Fim ");
            processarFimDePowerUp();
        }
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

    public ConsumidorDeEvento<PowerUpInfoFim> getConsumidorDePowerUpFim()
    {
        return this;
    }   
    //CONSUMIDORES DE EVENTOS FIM
}
