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
            .adicionarConsumidor(uiManager);

        new AcaoBBarPupEscolhido<PowerUpBtnInfo>()
            .configurarProdutor(uiManager)
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
            .adicionarConsumidor(garraManager)
            .adicionarConsumidor(uiManager);
    }
}
