public class MainGameEventos 
{
    protected GarraManager      garraManager;
    protected ColetaveisManager coletaveisManager;
    protected MaquinaManager    maquinaManager;
    protected UiGameManager     uiManager;
    protected PowerUpManager    powerUpManager;
    protected CameraManager     cameraManager;
    protected InputGameImpl     inputGameImpl;
    protected DraggavelManager  draggavelManager;

    public MainGameEventos(MainGameManagers mainGameManagers)
    {
        garraManager      = mainGameManagers.garraManager;
        coletaveisManager = mainGameManagers.coletaveisManager;
        maquinaManager    = mainGameManagers.maquinaManager;
        uiManager         = mainGameManagers.uiManager;
        powerUpManager    = mainGameManagers.powerUpManager;
        cameraManager     = mainGameManagers.cameraManager;
        inputGameImpl     = mainGameManagers.inputGame;
        draggavelManager  = mainGameManagers.draggavelManager;
    }

    public void configurarEventos()
    {
        //TODO sugestao de especificar exatamente os consumidores e os produtores
        configurarAcaoColetado();
        configurarAcaoColetadoFim();
        configurarAcaoInfoDaGarra();
        configurarAcaoPowerUpAcionado();

        new AcaoSincroniaComDirecaoDaGarra()
            .configurarProdutor(garraManager)
            .adicionarConsumidor(maquinaManager);        

        configurarAcaoBotaoPowerUpVazio();
        configurarAcaoPupFromScrollSelecao();

        new AcaoTempoEsgotado()
            .configurarProdutor(maquinaManager.displayTimer)
            .adicionarConsumidor(maquinaManager.botoesPowerUp)
            .adicionarConsumidor(maquinaManager.arcoIrisEfeito)
            .adicionarConsumidor(garraManager)
            .adicionarConsumidor(uiManager.modalResultados)
            .adicionarConsumidor(coletaveisManager);

        new AcaoBoardElevadoFim()
            .configurarProdutor(coletaveisManager.board)
            .adicionarConsumidor(maquinaManager)
            .adicionarConsumidor(garraManager)
            .adicionarConsumidor(uiManager.modalResultados);

        new AcaoCacaNiquel()
            .configurarProdutor(maquinaManager.displayDeColetados)
            .adicionarConsumidor(cameraManager)
            .adicionarConsumidor(garraManager)
            .adicionarConsumidor(uiManager.modalResultados)
            .adicionarConsumidor(maquinaManager.arcoIrisEfeito);

        new AcaoDesligarMaquina()
            .configurarProdutor(maquinaManager)
            .adicionarConsumidor(uiManager.modalSair)
            .adicionarConsumidor(inputGameImpl);

        new AcaoDesligarMaquinaResultado()
            .configurarProdutor(uiManager.modalSair)
            .adicionarConsumidor(maquinaManager.botaoLigaDesliga)
            .adicionarConsumidor(maquinaManager.botoesPowerUp)
            .adicionarConsumidor(inputGameImpl);
    }

    protected virtual AcaoColetado configurarAcaoColetado()
    {
        AcaoColetado acaoColetado = new AcaoColetado();
        acaoColetado.configurarProdutor(coletaveisManager)
            .adicionarConsumidor(garraManager)
            .adicionarConsumidor(maquinaManager.displayTimer)
            .adicionarConsumidor(maquinaManager.displayDeColetados)
            .adicionarConsumidor(maquinaManager.displayDeScores)
            .adicionarConsumidor(maquinaManager.botoesPowerUp)
            .adicionarConsumidor(uiManager.modalResultados);

        return acaoColetado;
    }

    protected virtual AcaoColetadoFim configurarAcaoColetadoFim()
    {
        AcaoColetadoFim acaoColetadoFim = new AcaoColetadoFim();
        acaoColetadoFim.configurarProdutor(maquinaManager.displayDeColetados.modoColetados)
            .adicionarConsumidor(coletaveisManager)
            .adicionarConsumidor(garraManager)
            .adicionarConsumidor(maquinaManager.displayTimer)
            .adicionarConsumidor(maquinaManager.botoesPowerUp);

        return acaoColetadoFim;
    }

    protected virtual AcaoInfoDaGarra configurarAcaoInfoDaGarra()
    {        
        AcaoInfoDaGarra acaoInfoDaGarra = new AcaoInfoDaGarra();
        acaoInfoDaGarra.configurarProdutor(garraManager)
                       .adicionarConsumidor(coletaveisManager);
        return acaoInfoDaGarra;
    }

    protected virtual AcaoBotaoPowerUpVazio configurarAcaoBotaoPowerUpVazio()
    {
        AcaoBotaoPowerUpVazio acaoBotaoPupVazio = new AcaoBotaoPowerUpVazio();
        acaoBotaoPupVazio.configurarProdutor(maquinaManager.botoesPowerUp)
            .adicionarConsumidor(cameraManager)
            .adicionarConsumidor(maquinaManager)
            .adicionarConsumidor(draggavelManager);

        return acaoBotaoPupVazio;
    }

    protected virtual AcaoPupFromScrollSelecao configurarAcaoPupFromScrollSelecao()
    {
        AcaoPupFromScrollSelecao acaoPupScrollSelecao = new AcaoPupFromScrollSelecao();
        acaoPupScrollSelecao.configurarProdutor(maquinaManager.scrollPupsManager.scrollSelecao)
            .adicionarConsumidor(maquinaManager.botoesPowerUp)
            .adicionarConsumidor(cameraManager)
            .adicionarConsumidor(draggavelManager)
            .adicionarConsumidor(maquinaManager);

        return acaoPupScrollSelecao;
    }

    protected virtual AcaoPowerUpAcionado configurarAcaoPowerUpAcionado()
    {
        AcaoPowerUpAcionado acaoPowerUpAcionado = new AcaoPowerUpAcionado();
        acaoPowerUpAcionado.configurarProdutor(powerUpManager)
            .adicionarConsumidor(garraManager)
            .adicionarConsumidor(maquinaManager)
            .adicionarConsumidor(coletaveisManager)
            .adicionarConsumidor(maquinaManager.scrollPupsManager)
            .adicionarConsumidor(draggavelManager);

        return acaoPowerUpAcionado;
    }
}
