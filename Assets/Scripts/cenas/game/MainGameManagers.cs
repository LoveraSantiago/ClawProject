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
    public DraggavelManager  draggavelManager  { get; private set; }

    public MainGameManagers(MainGameDto mainDto, Loading loading, Consumidor<UpdaterManagers> consumidorUpdateManagers)
    {
        ColetorDeDados coletorDeDados = new ColetorDeDados();

        inputGame         = new InputGameImpl();
        garraManager      = new GarraManager(mainDto.GarraDto);
        coletaveisManager = new ColetaveisManager(mainDto.ColetaveisDto);
        maquinaManager    = new MaquinaManager(mainDto.MaquinaDto);
        powerUpManager    = new PowerUpManager(mainDto.PowerUpDto, inputGame);
        uiManager         = new UiGameManager(mainDto, coletorDeDados);
        cameraManager     = new CameraManager(mainDto.CameraDto);
        draggavelManager  = new DraggavelManager(mainDto.DragCollider);

        configurandoLevel(mainDto);
        configurandoEventos();
        consumidorUpdateManagers.consumir(new UpdaterEmptyManagers());

        coletorDeDados
            .addProvedorDadosTempo(maquinaManager.displayTimer.contadorTimer.dadosDeTempo)
            .addProvedorDadosColetaveis(coletaveisManager)            
            .addProvedorSubidasDaGarra(garraManager)
            .addProvedorSubidasDoElevador(coletaveisManager.board.elevador)
            .addProvedorDadosPowerUp(powerUpManager);

        ContextoEstaticoUtils.MonoBehaviour.StartCoroutine(startLaizy(mainDto, consumidorUpdateManagers));        
    }   

    private void configurandoLevel(MainGameDto mainDto)
    {
        AbstractLevel levelEscolhido = ContextoEstaticoUtils.level;
        coletaveisManager.configuradoPeloLevel(levelEscolhido, mainDto.ColetaveisDto);
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
        garraManager.start(mainDto.GarraDto);
        consumidorUpdateManagers.consumir(getUpdatables());        
    }

    private UpdaterMainGameManagers getUpdatables()
    {
        return new UpdaterMainGameManagers(garraManager, maquinaManager, powerUpManager, inputGame);
    }

    private InformacaoDisplayColetado getInformacaoDisplayColetado()
    {
        return maquinaManager.displayDeColetados.modoColetados;
    }
}
