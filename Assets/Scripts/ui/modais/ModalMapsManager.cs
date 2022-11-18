public class ModalMapsManager : AcaoMapaNavegado.ConsumidorEvento,
                                AcaoBotaoMapaAcionado.ConsumidorEvento
{
    private ModalFase modalFase;
    private ModalNoFicha modalNoFicha;

    private MapaEntidade mapaEntidadeAtual;

    public ModalMapsManager(MainMapaDto mainMapaDto, Loading loading)
    {
        modalFase = new ModalFase(mainMapaDto.ModalFaseDto, loading);
        modalNoFicha = new ModalNoFicha(mainMapaDto.ModalNoFichaDto, loading);
    }

    private void abrirModal(MapaEntidade mapaEntidade, int indiceLevel)
    {
        if(PlayerPrefsFichas.possueFichas(Ficha.PRATA, 1))
        {
            modalFase.ligar(mapaEntidade, indiceLevel);
        }
        else
        {
            modalNoFicha.ligar(Ficha.PRATA);
        }
    }

    void AcaoMapaNavegado.ConsumidorEvento.consumirEvento(WrapperLevelMapDto evento)
    {
        mapaEntidadeAtual = evento.mapaEntidade;
    }

    void AcaoBotaoMapaAcionado.ConsumidorEvento.consumirEvento(int evento)
    {
        abrirModal(mapaEntidadeAtual, evento);
    }
}
