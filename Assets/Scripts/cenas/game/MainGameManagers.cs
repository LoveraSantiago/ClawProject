public class MainGameManagers 
{    
    public GarraManager      garraManager      { get; private set; }
    public MaquinaManager    maquinaManager    { get; private set; }
    public PowerUpManager    powerUpManager    { get; private set; }
    public ColetaveisManager coletaveisManager { get; private set; }
    public CameraManager     cameraManager     { get; private set; }
    public UiGameManager     uiManager         { get; private set; }    
    public InputGame         inputGame         { get; private set; }

    public MainGameManagers(MainGameDto mainDto)
    {
        inputGame         = new InputGameImpl(mainDto.MaquinaDto.ReferenciaChao);
        garraManager      = new GarraManager(mainDto.GarraDto);
        coletaveisManager = new ColetaveisManager(mainDto.ColetaveisDto);
        maquinaManager    = new MaquinaManager(mainDto.MaquinaDto, inputGame);
        powerUpManager    = new PowerUpManager(mainDto.PowerUpDto, inputGame);
        uiManager         = new UiGameManager(mainDto.UiDto);        
        cameraManager     = new CameraManager(mainDto.CameraDto);        
    }

    public void configurandoLevel(AbstractLevel levelEscolhido)
    {
        garraManager.configuradoPeloLevel(levelEscolhido);
        coletaveisManager.configuradoPeloLevel(levelEscolhido);
        maquinaManager.configuradoPeloLevel(levelEscolhido);
        uiManager.configurandoLevel(levelEscolhido);

        powerUpManager.configurarGosPowerUps(
            getInformacaoDisplayColetado(), getTrocadorDeOrdem());
    }

    public void configurandoEventos()
    {
        MainGameEventos eventos = new MainGameEventos();
        eventos.configurarEventos(this);
    }

    public void startLaizy()
    {
        coletaveisManager.start();
        maquinaManager.start();
        uiManager.start();        
        garraManager.start();
    }

    public void update()
    {
        inputGame.update();
        garraManager.update(inputGame);
        maquinaManager.update(inputGame);
    }

    public void fixedUpdate()
    {
        garraManager.fixedUpdate();
        maquinaManager.fixedUpdate();
    }

    private TrocadorDeOrdem getTrocadorDeOrdem()
    {
        return coletaveisManager.contadorOrdenado;
    }

    private InformacaoDisplayColetado getInformacaoDisplayColetado()
    {
        return maquinaManager.displaysDeSlots.displayDeColetados;
    }
}
