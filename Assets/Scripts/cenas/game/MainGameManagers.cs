using System.Collections;

public class MainGameManagers 
{    
    public GarraManager      garraManager      { get; private set; }
    public MaquinaManager    maquinaManager    { get; private set; }
    public PowerUpManager    powerUpManager    { get; private set; }
    public ColetaveisManager coletaveisManager { get; private set; }
    public CameraManager     cameraManager     { get; private set; }
    public UiGameManager     uiManager         { get; private set; }    
    public InputGameImpl     inputGame         { get; private set; }

    public MainGameManagers(
        MainGameDto mainDto, AbstractLevel levelEscolhido, Consumidor<UpdaterManagers> consumidorUpdateManagers)
    {
        inputGame         = new InputGameImpl();
        garraManager      = new GarraManager(mainDto.GarraDto);
        coletaveisManager = new ColetaveisManager(mainDto.ColetaveisDto);
        maquinaManager    = new MaquinaManager(mainDto.MaquinaDto);
        powerUpManager    = new PowerUpManager(mainDto.PowerUpDto, inputGame);
        uiManager         = new UiGameManager(mainDto.UiDto);        
        cameraManager     = new CameraManager(mainDto.CameraDto);

        configurandoLevel(mainDto, levelEscolhido);
        configurandoEventos();
        consumidorUpdateManagers.consumir(new UpdaterEmptyManagers());

        Utils.MonoBehaviour.StartCoroutine(startLaizy(mainDto, consumidorUpdateManagers));        
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

    private IEnumerator startLaizy(MainGameDto mainDto, Consumidor<UpdaterManagers> consumidorUpdateManagers)
    {
        yield return coletaveisManager.start();

        maquinaManager.start(inputGame);
        uiManager.start();        
        garraManager.start(mainDto.GarraDto);
        consumidorUpdateManagers.consumir(getUpdatables());

        yield return null;
    }

    private UpdaterMainGameManagers getUpdatables()
    {
        return new UpdaterMainGameManagers(garraManager, maquinaManager, powerUpManager, inputGame);
    }

    private InformacaoDisplayColetado getInformacaoDisplayColetado()
    {
        return maquinaManager.displaysDeSlots.displayDeColetados;
    }
}
