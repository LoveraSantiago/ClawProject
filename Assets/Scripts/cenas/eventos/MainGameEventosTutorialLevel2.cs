public class MainGameEventosTutorialLevel2 : AbstractMainGameEventosTutorial
{
    private TutorialLevel2 tutorial;

    public MainGameEventosTutorialLevel2(AllGameManagers allGameManagers, TutorialLevel2 tutorial)
        : base(allGameManagers)
    {
        this.tutorial = tutorial;
    }

    public override void iniciar()
    {
        tutorial.iniciar();
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
}
