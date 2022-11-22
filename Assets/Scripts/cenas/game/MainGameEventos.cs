public class MainGameEventos 
{
    public void configurarEventos(MainGameManagers mainGameManagers)
    {
        GarraManager      garraManager      = mainGameManagers.garraManager;
        ColetaveisManager coletaveisManager = mainGameManagers.coletaveisManager;
        MaquinaManager    maquinaManager    = mainGameManagers.maquinaManager;
        UiGameManager     uiManager         = mainGameManagers.uiManager;
        PowerUpManager    powerUpManager    = mainGameManagers.powerUpManager;
        CameraManager     cameraManager     = mainGameManagers.cameraManager;
        InputGameImpl     inputGameImpl     = mainGameManagers.inputGame;
        DraggavelManager  draggavelManager = mainGameManagers.draggavelManager;

        //TODO sugestao de especificar exatamente os consumidores e os produtores
        new AcaoColetado()
            .configurarProdutor(coletaveisManager)
            .adicionarConsumidor(garraManager)
            .adicionarConsumidor(maquinaManager.displayTimer)
            .adicionarConsumidor(maquinaManager.displayDeColetados)
            .adicionarConsumidor(maquinaManager.displayDeScores)
            .adicionarConsumidor(maquinaManager.botoesPowerUp)
            .adicionarConsumidor(uiManager.modalResultados);

        configurarAcaoColetadoFim(mainGameManagers);
        configurarAcaoInfoDaGarra(mainGameManagers);

        new AcaoSincroniaComDirecaoDaGarra()
            .configurarProdutor(garraManager)
            .adicionarConsumidor(maquinaManager);

        new AcaoPowerUpAcionado()
            .configurarProdutor(powerUpManager)
            .adicionarConsumidor(garraManager)
            .adicionarConsumidor(maquinaManager)
            .adicionarConsumidor(coletaveisManager)
            .adicionarConsumidor(maquinaManager.scrollPupsManager)
            .adicionarConsumidor(draggavelManager);

        new AcaoBotaoPowerUpVazio()
            .configurarProdutor(maquinaManager.botoesPowerUp)
            .adicionarConsumidor(cameraManager)            
            .adicionarConsumidor(maquinaManager)
            .adicionarConsumidor(draggavelManager);

        new AcaoPupFromScrollSelecao()
            .configurarProdutor(maquinaManager.scrollPupsManager.scrollSelecao)
            .adicionarConsumidor(maquinaManager.botoesPowerUp)
            .adicionarConsumidor(cameraManager)
            .adicionarConsumidor(draggavelManager)
            .adicionarConsumidor(maquinaManager);

        new AcaoTempoEsgotado()
            .configurarProdutor(maquinaManager.displayTimer)
            .adicionarConsumidor(maquinaManager.botoesPowerUp)
            .adicionarConsumidor(maquinaManager.arcoIrisEfeito)
            .adicionarConsumidor(garraManager)
            .adicionarConsumidor(uiManager.modalResultados)
            .adicionarConsumidor(coletaveisManager);

        new AcaoBoardElevadoFim()
            .configurarProdutor(coletaveisManager)
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

    protected virtual AcaoColetadoFim configurarAcaoColetadoFim(MainGameManagers mainGameManagers)
    {
        MaquinaManager maquinaManager       = mainGameManagers.maquinaManager;
        ColetaveisManager coletaveisManager = mainGameManagers.coletaveisManager;
        GarraManager garraManager           = mainGameManagers.garraManager;

        AcaoColetadoFim acaoColetadoFim = new AcaoColetadoFim();
        acaoColetadoFim.configurarProdutor(maquinaManager.displayDeColetados.modoColetados)
            .adicionarConsumidor(coletaveisManager)
            .adicionarConsumidor(garraManager)
            .adicionarConsumidor(maquinaManager.displayTimer)
            .adicionarConsumidor(maquinaManager.botoesPowerUp);

        return acaoColetadoFim;
    }

    protected virtual AcaoInfoDaGarra configurarAcaoInfoDaGarra(MainGameManagers mainGameManagers)
    {
        GarraManager garraManager           = mainGameManagers.garraManager;
        ColetaveisManager coletaveisManager = mainGameManagers.coletaveisManager;

        AcaoInfoDaGarra acaoInfoDaGarra = new AcaoInfoDaGarra();
        acaoInfoDaGarra.configurarProdutor(garraManager)
                       .adicionarConsumidor(coletaveisManager);
        return acaoInfoDaGarra;
    }
}
