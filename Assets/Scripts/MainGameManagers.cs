public class MainGameManagers 
{    
    public GarraManager garraManager { get; private set; }
    public MaquinaManager maquinaManager { get; private set; }
    public PowerUpManager powerUpManager { get; private set; }
    public ColetaveisManager coletaveisManager { get; private set; }
    public CameraManager cameraManager { get; private set; }
    public UiGameManager uiManager { get; private set; }
    public ScrollManager scrollManager { get; private set; }
    public InputGame inputGame { get; private set; }

    public MainGameManagers(MainGameDto mainDto)
    {
        inputGame = new InputGameImpl(mainDto.MaquinaDto.ReferenciaChao);
        garraManager = new GarraManager(mainDto.GarraDto);
        coletaveisManager = new ColetaveisManager(mainDto.ColetaveisDto);
        maquinaManager = new MaquinaManager(mainDto.MaquinaDto, inputGame);
        powerUpManager = new PowerUpManager(mainDto.PowerUpDto, inputGame);
        uiManager = new UiGameManager(mainDto.UiDto);        
        cameraManager = new CameraManager(mainDto.CameraDto);
        scrollManager = new ScrollManager(mainDto.UiDto.PrefabBottomBar);
    }

    public void configurandoLevel(AbstractLevel levelEscolhido)
    {
        garraManager.configuradoPeloLevel(levelEscolhido);
        coletaveisManager.configuradoPeloLevel(levelEscolhido);
        maquinaManager.configuradoPeloLevel(levelEscolhido);
        uiManager.configurandoLevel(levelEscolhido);
        scrollManager.configuradoPeloLevel(levelEscolhido);
    }

    public void configurandoEventos()
    {
        new AcaoColetado()
            .configurarProdutor(coletaveisManager)
            .adicionarConsumidor(garraManager)
            .adicionarConsumidor(maquinaManager)
            .adicionarConsumidor(uiManager);

        new AcaoColetadoFim()
            .configurarProdutor(maquinaManager)
            .adicionarConsumidor(coletaveisManager)
            .adicionarConsumidor(garraManager);

        new AcaoImantadoPelaGarra()
            .configurarProdutor(garraManager)
            .adicionarConsumidor(coletaveisManager);

        new AcaoSubidaDaGarra()
            .configurarProdutor(garraManager)
            .adicionarConsumidor(coletaveisManager);

        new AcaoSincroniaComDirecaoDaGarra()
            .configurarProdutor(garraManager)
            .adicionarConsumidor(maquinaManager);

        new AcaoPUpAcionado()
            .configurarProdutor(powerUpManager)
            .adicionarConsumidor(garraManager)
            .adicionarConsumidor(maquinaManager)
            .adicionarConsumidor(coletaveisManager);

        new AcaoBotaoPUpVazio()
            .configurarProdutor(maquinaManager)
            .adicionarConsumidor(cameraManager)
            .adicionarConsumidor(scrollManager);

        new AcaoBBarPupEscolhido<PowerUpBtnInfo>()
            .configurarProdutor(scrollManager)
            .adicionarConsumidor(maquinaManager)
            .adicionarConsumidor(cameraManager);

        new AcaoTempoEsgotado()
            .configurarProdutor(maquinaManager)
            .adicionarConsumidor(garraManager)
            .adicionarConsumidor(uiManager)
            .adicionarConsumidor(coletaveisManager);

        new AcaoBoardElevadoFim()
            .configurarProdutor(coletaveisManager)
            .adicionarConsumidor(maquinaManager)
            .adicionarConsumidor(garraManager)
            .adicionarConsumidor(uiManager);

        new AcaoCacaNiquel()
            .configurarProdutor(maquinaManager)
            .adicionarConsumidor(cameraManager)
            .adicionarConsumidor(garraManager);
    }

    public void startLaizy()
    {
        coletaveisManager.start();
        garraManager.start();
        maquinaManager.start();
        scrollManager.start();
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
}
