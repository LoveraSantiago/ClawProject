public class ModalFimCacaNiquelIndividual : AbstractModalFim
{
    private CacaNiquelEventoDto evento;
    private LinhaModalPontos[] linhasModal;

    public ModalFimCacaNiquelIndividual(CacaNiquelEventoDto evento, LinhaModalPontos[] linhasModal)
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

        int indicePup = PlayerPrefsPowerUp.recuperarIndicePup();
        PowerUpEntidade pupEscolhido = FactoryPowerUpEntidade.getPowerUpFromIndice(indicePup);

        montarLinhaPupSingle(0, evento, pupEscolhido);
        montarLinhaPupSingle(1, evento, pupEscolhido);
        montarLinhaPupSingle(2, evento, pupEscolhido);

        if (evento.isTripleSucess())
        {
            linhasModal[3].ligar();
            linhasModal[3].passarInfos("Bonus!!!", pupEscolhido.sprPowerUp, "3");
            PlayerPrefsPowerUp.adicionarPup(pupEscolhido.nome, 3);
        }
        else if (evento.isTripleFail())
        {
            linhasModal[3].ligar();
            linhasModal[3].passarInfos("Consolação", pupEscolhido.sprPowerUp, "1");
            PlayerPrefsPowerUp.adicionarPup(pupEscolhido.nome, 1);
        }

        modalManipulacao.setScoreAtual("Power Ups Ganhos");        
    }

    private void montarLinhaPupSingle(int indice, CacaNiquelEventoDto evento, PowerUpEntidade pup)
    {

        if (evento.isResultSucesso(indice))
        {
            linhasModal[indice].passarInfos(pup.nome, evento.sprResultados[indice], "OK");
            PlayerPrefsPowerUp.adicionarPup(pup.nome, 1);
        }
        else if (evento.isResultFail(indice))
        {
            linhasModal[indice].passarInfos("Nada", evento.sprResultados[indice], "NOK");
        }
        else
        {
            linhasModal[indice].passarInfos("Ficha", evento.sprResultados[indice], "OK");
            PlayerPrefsFichas.comprarFicha(Ficha.BRONZE, 1);
        }
    }

    protected override void irParaCena()
    {
        CenaUtils.irParaCenaPup();
    }
}
