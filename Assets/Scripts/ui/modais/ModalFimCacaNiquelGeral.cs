public class ModalFimCacaNiquelGeral : AbstractModalFim
{
    private CacaNiquelResult evento;
    private LinhaModalPontos[] linhasModal;

    public ModalFimCacaNiquelGeral(CacaNiquelResult evento, LinhaModalPontos[] linhasModal)
    {
        this.evento = evento;
        this.linhasModal = linhasModal;
    }

    public override void configurar(ModalManipulacao modalManipulacao)
    {
        linhasModal[0].ligar();
        linhasModal[1].ligar();
        linhasModal[2].ligar();
        linhasModal[3].desligar();

        string[] nomes = PowerUpHelper.getNomesPupsBySprites(evento.sprResultados);

        linhasModal[0].passarInfos(nomes[0], evento.sprResultados[0], "1");
        linhasModal[1].passarInfos(nomes[1], evento.sprResultados[1], "1");
        linhasModal[2].passarInfos(nomes[2], evento.sprResultados[2], "1");

        PlayerPrefsPup.adicionarPup(nomes[0], 1);
        PlayerPrefsPup.adicionarPup(nomes[1], 1);
        PlayerPrefsPup.adicionarPup(nomes[2], 1);

        modalManipulacao.setScoreAtual("Power Ups Ganhos");
    }

    protected override void irParaCena()
    {
        CenaUtils.irParaCenaPup();
    }
}
