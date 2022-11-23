public class MainGameEventosTutorial : MainGameEventos
{
    private Tutorial tutorial;

    public MainGameEventosTutorial(MainGameManagers mainGameManagers, Tutorial tutorial)
        :base(mainGameManagers)
    {
        this.tutorial = tutorial;
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
}
