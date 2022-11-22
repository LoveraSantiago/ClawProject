public class MainGameEventosTutorial : MainGameEventos
{
    private Tutorial tutorial;

    public MainGameEventosTutorial(MainGameManagers mainGameManagers, Tutorial tutorial)
        :base(mainGameManagers)
    {
        this.tutorial = tutorial;
    }

    protected override AcaoColetado configurarAcaoColetado()
    {
        AcaoColetado acaoColetado = new AcaoColetado();
        acaoColetado.configurarProdutor(coletaveisManager)
            .adicionarConsumidor(garraManager)
            .adicionarConsumidor(maquinaManager.displayTimer)
            .adicionarConsumidor(maquinaManager.displayDeColetados)
            .adicionarConsumidor(maquinaManager.displayDeScores)
            .adicionarConsumidor(maquinaManager.botoesPowerUp);            

        return acaoColetado;
    }

    protected override AcaoColetadoFim configurarAcaoColetadoFim()
    {
        AcaoColetadoFim acaoColetadoFim = base.configurarAcaoColetadoFim();
        acaoColetadoFim.adicionarConsumidor(tutorial);
        return acaoColetadoFim;
    }
}
