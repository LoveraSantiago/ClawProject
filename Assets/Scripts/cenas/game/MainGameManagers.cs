public class MainGameManagers 
{    
    public GarraManager      garraManager      { get; private set; }
    public MaquinaManager    maquinaManager    { get; private set; }
    public PowerUpManager    powerUpManager    { get; private set; }
    public ColetaveisManager coletaveisManager { get; private set; }
    public CameraManager     cameraManager     { get; private set; }
    public UiGameManager     uiManager         { get; private set; }    
    public InputGameImpl     inputGame         { get; private set; }

    public MainGameManagers(MainGameDto mainDto, AbstractLevel levelEscolhido)
    {
        inputGame         = new InputGameImpl();
        garraManager      = new GarraManager(mainDto.GarraDto);
        coletaveisManager = new ColetaveisManager(mainDto.ColetaveisDto);
        maquinaManager    = new MaquinaManager(mainDto.MaquinaDto, inputGame);
        powerUpManager    = new PowerUpManager(mainDto.PowerUpDto, inputGame);
        uiManager         = new UiGameManager(mainDto.UiDto);        
        cameraManager     = new CameraManager(mainDto.CameraDto);

        configurandoLevel(mainDto, levelEscolhido);
        configurandoEventos();
        startLaizy(mainDto);
    }

    public UpdateMainGameManagers getUpdatables()
    {
        return new UpdateMainGameManagers(garraManager, maquinaManager, inputGame);
    }

    private void configurandoLevel(MainGameDto mainDto, AbstractLevel levelEscolhido)
    {
        garraManager     .configuradoPeloLevel(mainDto.GarraDto, levelEscolhido);
        coletaveisManager.configuradoPeloLevel(levelEscolhido);
        maquinaManager   .configuradoPeloLevel(levelEscolhido, mainDto.MaquinaDto);
        uiManager        .configurandoLevel(levelEscolhido);

        powerUpManager.configurarGosPowerUps(
            getInformacaoDisplayColetado(), coletaveisManager.getFornecedorTrocadorDeOrdem());
    }

    private void configurandoEventos()
    {
        MainGameEventos eventos = new MainGameEventos();
        eventos.configurarEventos(this);
    }

    private void startLaizy(MainGameDto mainDto)
    {
        coletaveisManager.start();
        maquinaManager.start();
        uiManager.start();        
        garraManager.start(mainDto.GarraDto);
    }         

    private InformacaoDisplayColetado getInformacaoDisplayColetado()
    {
        return maquinaManager.displaysDeSlots.displayDeColetados;
    }
}
