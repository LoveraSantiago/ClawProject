public class MainGameEventosTutorial : MainGameEventos
{
    private Tutorial tutorial;

    public MainGameEventosTutorial(AllGameManagers allGameManagers, Tutorial tutorial)
        :base(allGameManagers)
    {
        this.tutorial = tutorial;
    }    

    public void iniciar()
    {
        tutorial.iniciar();
    }

    protected override AcaoColetadoFim configurarAcaoColetadoFim()
    {
        AcaoColetadoFim acaoColetadoFim = base.configurarAcaoColetadoFim();
        acaoColetadoFim.adicionarConsumidor(tutorial);
        return acaoColetadoFim;
    }

    protected override AcaoBotaoPowerUpVazio configurarAcaoBotaoPowerUpVazio()
    {
        AcaoBotaoPowerUpVazio acaoBotaoPupVazio = base.configurarAcaoBotaoPowerUpVazio();
        acaoBotaoPupVazio.adicionarConsumidor(tutorial);
        return acaoBotaoPupVazio;
    }

    protected override AcaoPupFromScrollSelecao configurarAcaoPupFromScrollSelecao()
    {
        AcaoPupFromScrollSelecao acaoPupScrollSelecao = base.configurarAcaoPupFromScrollSelecao();
        acaoPupScrollSelecao.adicionarConsumidor(tutorial);
        return acaoPupScrollSelecao;
    }

    protected override AcaoPowerUpAcionado configurarAcaoPowerUpAcionado()
    {
        AcaoPowerUpAcionado acaoPowerUpAcionado = base.configurarAcaoPowerUpAcionado();
        acaoPowerUpAcionado.adicionarConsumidor(tutorial);
        return acaoPowerUpAcionado;
    }

    protected override AcaoColetado configurarAcaoColetado()
    {
        AcaoColetado acaoColetado = base.configurarAcaoColetado();

        AcaoColetado acaoColetadoTutorial = new AcaoColetado();
        acaoColetadoTutorial.configurarProdutor(tutorial)
            .adicionarConsumidor(allGameManagers.getModalResultadosManager());

        return acaoColetado;
    }
}
