public class ModalFimCacaNiquelIndividual : AbstractModalFim
{
    //private CacaNiquelEventoDto evento;
    private LinhaModalPontos[] linhasModal;

    private ModalCacaNiquelDto modalCacaNiquelDto;

    public ModalFimCacaNiquelIndividual(CacaNiquelEventoDto evento, ModalCacaNiquelDto modalCacaNiquelDto, CacaNiquelDto cacaNiquelDto)
    {
        //this.evento = evento;
        //this.linhasModal = linhasModal;
        this.modalCacaNiquelDto = modalCacaNiquelDto;
        configurar(evento, cacaNiquelDto);
    }

    //public override void configurar(ModalManipulacao modalManipulacao)
    public void configurar(CacaNiquelEventoDto evento, CacaNiquelDto cacaNiquelDto)
    {
        //linhasModal[0].ligar();
        //linhasModal[1].ligar();
        //linhasModal[2].ligar();
        //linhasModal[3].desligar();

        int indicePup = PlayerPrefsPowerUp.recuperarIndicePup();
        PowerUpEntidade pupEscolhido = FactoryPowerUpEntidade.getPowerUpFromIndice(indicePup);

        modalCacaNiquelDto.ImgHeadPup.sprite = pupEscolhido.sprPersonagemPup;
        modalCacaNiquelDto.LblNomePup.text = pupEscolhido.nome;
        montarSlotsResultados(evento, pupEscolhido, cacaNiquelDto);

        //montarSlotResultados(0, evento, pupEscolhido);
        //montarSlotResultados(1, evento, pupEscolhido);
        //montarSlotResultados(2, evento, pupEscolhido);

        if (evento.isTripleSucess())
        {
            linhasModal[3].ligar();
            linhasModal[3].passarInfos("Bonus!!!", pupEscolhido.sprIconPowerUp, "3");
            PlayerPrefsPowerUp.adicionarPup(pupEscolhido.nome, 3);
        }
        else if (evento.isTripleFail())
        {
            linhasModal[3].ligar();
            linhasModal[3].passarInfos("Consolação", pupEscolhido.sprIconPowerUp, "1");
            PlayerPrefsPowerUp.adicionarPup(pupEscolhido.nome, 1);
        }

        //modalManipulacao.setScoreAtual("Power Ups Ganhos");        
    }

    private void montarSlotsResultados(CacaNiquelEventoDto evento, PowerUpEntidade pup, CacaNiquelDto cacaNiquelDto)
    {
        for(int contador = 0; contador < modalCacaNiquelDto.SlotsCacaNiquel.Length; contador++)
        {
            modalCacaNiquelDto.SlotsCacaNiquel[contador].ImgResultado.sprite = evento.sprResultados[contador];
            if (evento.isResultSucesso(contador))
            {
                modalCacaNiquelDto.SlotsCacaNiquel[contador].ImgBackground.color = cacaNiquelDto.CorSucesso;
                //linhasModal[contador].passarInfos(pup.nome, evento.sprResultados[contador], "OK");
                //PlayerPrefsPowerUp.adicionarPup(pup.nome, 1);
            }
            else if (evento.isResultFail(contador))
            {
                modalCacaNiquelDto.SlotsCacaNiquel[contador].ImgBackground.color = cacaNiquelDto.CorFalha;
                //linhasModal[contador].passarInfos("Nada", evento.sprResultados[contador], "NOK");
            }
            else
            {
                modalCacaNiquelDto.SlotsCacaNiquel[contador].ImgBackground.color = cacaNiquelDto.CorMeio;
                //linhasModal[contador].passarInfos("Ficha", evento.sprResultados[contador], "OK");
                //PlayerPrefsFichas.comprarFicha(Ficha.BRONZE, 1);
            }
        }
    }

    public override void ligar()
    {
        modalCacaNiquelDto.Modal.SetActive(true);
    }

    protected override void irParaCena()
    {
        CenaUtils.irParaCenaPup();
    }
}
