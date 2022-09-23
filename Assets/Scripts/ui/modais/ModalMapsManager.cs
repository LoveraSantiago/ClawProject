public class ModalMapsManager : AcaoMapaNavegado.ConsumidorEvento,
                                AcaoBotaoMapaAcionado.ConsumidorEvento
{
    private ModalFase modalFase;
    private ModalNoFicha modalNoFicha;

    private MapaEntidade mapaEntidadeAtual;

    public ModalMapsManager(ModalFaseDto modalFaseDto, ModalNoFichaDto modalNoFichaDto)
    {
        modalFase = new ModalFase(modalFaseDto);
        modalNoFicha = new ModalNoFicha(modalNoFichaDto);
    }

    private void abrirModal(MapaEntidade mapaEntidade, int indiceLevel)
    {
        if(PlayerPrefsFichas.possueFichas(Ficha.PRATA, 1))
        {
            modalFase.ligar(mapaEntidade, indiceLevel);
        }
        else
        {
            modalNoFicha.ligar();
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
