public class MainGameEventos 
{
    protected AllGameManagers allGameManagers;

    public MainGameEventos(AllGameManagers allGameManagers)
    {
        this.allGameManagers = allGameManagers;
    }

    public void configurarEventos()
    {
        //TODO sugestao de especificar exatamente os consumidores e os produtores
        configurarAcaoColetado();
        configurarAcaoColetadoFim();
        configurarAcaoInfoDaGarra();
        configurarAcaoPowerUpAcionado();

        new AcaoSincroniaComDirecaoDaGarra()
            .configurarProdutor(allGameManagers.getGarraManager())
            .adicionarConsumidor(allGameManagers.getMaquinaManager());        

        configurarAcaoBotaoPowerUpVazio();
        configurarAcaoPupFromScrollSelecao();

        new AcaoTempoEsgotado()
            .configurarProdutor (allGameManagers.getDisplayTimer())
            .adicionarConsumidor(allGameManagers.getBotoesPowerUp())
            .adicionarConsumidor(allGameManagers.getArcoIrisEfeito())
            .adicionarConsumidor(allGameManagers.getGarraManager())
            .adicionarConsumidor(allGameManagers.getModalResultadosManager())
            .adicionarConsumidor(allGameManagers.getColetaveisManager());

        new AcaoBoardElevadoFim()
            .configurarProdutor (allGameManagers.getBoardElevador())
            .adicionarConsumidor(allGameManagers.getMaquinaManager())
            .adicionarConsumidor(allGameManagers.getGarraManager())
            .adicionarConsumidor(allGameManagers.getModalResultadosManager());

        new AcaoCacaNiquel()
            .configurarProdutor (allGameManagers.getDisplaysDeColetados())
            .adicionarConsumidor(allGameManagers.getCameraManager())
            .adicionarConsumidor(allGameManagers.getGarraManager())
            .adicionarConsumidor(allGameManagers.getModalResultadosManager())
            .adicionarConsumidor(allGameManagers.getArcoIrisEfeito());

        new AcaoDesligarMaquina()
            .configurarProdutor (allGameManagers.getMaquinaManager())
            .adicionarConsumidor(allGameManagers.getModalSair())
            .adicionarConsumidor((InputGameImpl)allGameManagers.getInputGame());

        new AcaoDesligarMaquinaResultado()
            .configurarProdutor(allGameManagers.getModalSair())
            .adicionarConsumidor(allGameManagers.getBotaoLigaDesliga())
            .adicionarConsumidor(allGameManagers.getBotoesPowerUp())
            .adicionarConsumidor((InputGameImpl)allGameManagers.getInputGame());
    }

    protected virtual AcaoColetado configurarAcaoColetado()
    {
        AcaoColetado acaoColetado = new AcaoColetado();
        acaoColetado.configurarProdutor(allGameManagers.getColetaveisManager())
            .adicionarConsumidor(allGameManagers.getGarraManager())
            .adicionarConsumidor(allGameManagers.getDisplayTimer())
            .adicionarConsumidor(allGameManagers.getDisplaysDeColetados())
            .adicionarConsumidor(allGameManagers.getDisplayDeScores())
            .adicionarConsumidor(allGameManagers.getBotoesPowerUp())
            .adicionarConsumidor(allGameManagers.getModalResultadosManager());

        return acaoColetado;
    }

    protected virtual AcaoColetadoFim configurarAcaoColetadoFim()
    {
        AcaoColetadoFim acaoColetadoFim = new AcaoColetadoFim();
        acaoColetadoFim.configurarProdutor(allGameManagers.getModoColetados())
            .adicionarConsumidor(allGameManagers.getColetaveisManager())
            .adicionarConsumidor(allGameManagers.getGarraManager())
            .adicionarConsumidor(allGameManagers.getDisplayTimer())
            .adicionarConsumidor(allGameManagers.getBotoesPowerUp());

        return acaoColetadoFim;
    }

    protected virtual AcaoInfoDaGarra configurarAcaoInfoDaGarra()
    {        
        AcaoInfoDaGarra acaoInfoDaGarra = new AcaoInfoDaGarra();
        acaoInfoDaGarra.configurarProdutor(allGameManagers.getGarraManager())
                       .adicionarConsumidor(allGameManagers.getColetaveisManager());
        return acaoInfoDaGarra;
    }

    protected virtual AcaoBotaoPowerUpVazio configurarAcaoBotaoPowerUpVazio()
    {
        AcaoBotaoPowerUpVazio acaoBotaoPupVazio = new AcaoBotaoPowerUpVazio();
        acaoBotaoPupVazio.configurarProdutor(allGameManagers.getBotoesPowerUp())
            .adicionarConsumidor(allGameManagers.getCameraManager())
            .adicionarConsumidor(allGameManagers.getMaquinaManager())
            .adicionarConsumidor(allGameManagers.getDraggavelManager());

        return acaoBotaoPupVazio;
    }

    protected virtual AcaoPupFromScrollSelecao configurarAcaoPupFromScrollSelecao()
    {
        AcaoPupFromScrollSelecao acaoPupScrollSelecao = new AcaoPupFromScrollSelecao();
        acaoPupScrollSelecao.configurarProdutor(allGameManagers.getScrollSelecao())
            .adicionarConsumidor(allGameManagers.getBotoesPowerUp())
            .adicionarConsumidor(allGameManagers.getCameraManager())
            .adicionarConsumidor(allGameManagers.getDraggavelManager())
            .adicionarConsumidor(allGameManagers.getMaquinaManager());

        return acaoPupScrollSelecao;
    }

    protected virtual AcaoPowerUpAcionado configurarAcaoPowerUpAcionado()
    {
        AcaoPowerUpAcionado acaoPowerUpAcionado = new AcaoPowerUpAcionado();
        acaoPowerUpAcionado.configurarProdutor(allGameManagers.getPowerUpManager())
            .adicionarConsumidor(allGameManagers.getGarraManager())
            .adicionarConsumidor(allGameManagers.getMaquinaManager())
            .adicionarConsumidor(allGameManagers.getColetaveisManager())
            .adicionarConsumidor(allGameManagers.getScrollPupsManager())
            .adicionarConsumidor(allGameManagers.getDraggavelManager());

        return acaoPowerUpAcionado;
    }
}
