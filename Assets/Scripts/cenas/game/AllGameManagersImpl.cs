public class AllGameManagersImpl : AllGameManagers
{
    private GarraManager      garraManager;
    private MaquinaManager    maquinaManager;
    private PowerUpManager    powerUpManager;
    private ColetaveisManager coletaveisManager;
    private CameraManager     cameraManager;
    private UiGameManager     uiManager;
    private DraggavelManager  draggavelManager;
    private InputGame         inputGame;

    public CameraManager getCameraManager()
    {
        return cameraManager;
    }

    public ColetaveisManager getColetaveisManager()
    {
        return coletaveisManager;
    }

    public DraggavelManager getDraggavelManager()
    {
        return draggavelManager;
    }

    public GarraManager getGarraManager()
    {
        return garraManager;
    }

    public InputGame getInputGame()
    {
        return inputGame;
    }

    public MaquinaManager getMaquinaManager()
    {
        return maquinaManager;
    }

    public PowerUpManager getPowerUpManager()
    {
        return powerUpManager;
    }

    public UiGameManager getUiManager()
    {
        return uiManager;
    }

    public ModalResultadosManager getModalResultadosManager()
    {
        return uiManager.modalResultados;
    }

    public DadosDeTempo getDadosTempo()
    {
        return maquinaManager.displayTimer.contadorTimer.dadosDeTempo;
    }

    public BoardElevador getBoardElevador()
    {
        return coletaveisManager.board.elevador;
    }

    public ModoColetados getModoColetados()
    {
        return maquinaManager.displayDeColetados.modoColetados;
    }

    public DisplayTimer getDisplayTimer()
    {
        return maquinaManager.displayTimer;
    }

    public DisplaysDeColetados getDisplaysDeColetados()
    {
        return maquinaManager.displayDeColetados;
    }

    public DisplayDeScores getDisplayDeScores()
    {
        return maquinaManager.displayDeScores;
    }

    public BotoesPowerUp getBotoesPowerUp()
    {
        return maquinaManager.botoesPowerUp;
    }

    public ScrollSelecao getScrollSelecao()
    {
        return maquinaManager.scrollPupsManager.scrollSelecao;
    }

    public ScrollPupsManager getScrollPupsManager()
    {
        return maquinaManager.scrollPupsManager;
    }

    public ArcoIrisEfeito getArcoIrisEfeito()
    {
        return maquinaManager.arcoIrisEfeito;
    }

    public ModalSair getModalSair()
    {
        return uiManager.modalSair;
    }

    public BotaoLigaDesliga getBotaoLigaDesliga()
    {
        return maquinaManager.botaoLigaDesliga;
    }

    public AllGameManagersImpl addInputManager(InputGame inputGame)
    {
        this.inputGame = inputGame;
        return this;
    }

    public AllGameManagersImpl addGarraManager(GarraManager garraManager)
    {
        this.garraManager = garraManager;
        return this;
    }

    public AllGameManagersImpl addColetaveisManager(ColetaveisManager coletaveisManager)
    {
        this.coletaveisManager = coletaveisManager;
        return this;
    }

    public AllGameManagersImpl addMaquinaManager(MaquinaManager maquinaManager)
    {
        this.maquinaManager = maquinaManager;
        return this;
    }

    public AllGameManagersImpl addPowerUpManager(PowerUpManager powerUpManager)
    {
        this.powerUpManager = powerUpManager;
        return this;
    }

    public AllGameManagersImpl addUiGameManager(UiGameManager uiManager)
    {
        this.uiManager = uiManager;
        return this;
    }

    public AllGameManagersImpl addCameraManager(CameraManager cameraManager)
    {
        this.cameraManager = cameraManager;
        return this;
    }

    public AllGameManagersImpl addDraggavelManager(DraggavelManager draggavelManager)
    {
        this.draggavelManager = draggavelManager;
        return this;
    }  
}
