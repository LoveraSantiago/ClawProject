public class ModalMapsManager : AcaoMapaNavegado.ConsumidorEvento,
                                AcaoBotaoMapaAcionado.ConsumidorEvento
{
    private ModalFase modalFase;
    private ModalNoFicha modalNoFicha;
    private MapaEntidade mapaEntidadeAtual;
    private SomMap somMap;

    public ModalMapsManager(MainMapaDto mainMapaDto, SomMap somMap)
    {
        modalFase = new ModalFase(mainMapaDto.ModalFaseDto, somMap);
        modalNoFicha = new ModalNoFicha(mainMapaDto.ModalNoFichaDto, somMap);
        this.somMap = somMap;
    }

    private void abrirModal(MapaEntidade mapaEntidade, int indiceLevel)
    {
        if(PlayerPrefsFichas.possueFichas(Ficha.PRATA, 1))
        {
            modalFase.ligar(mapaEntidade, indiceLevel, somMap);
        }
        else
        {
            modalNoFicha.ligar(Ficha.PRATA, somMap);
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
