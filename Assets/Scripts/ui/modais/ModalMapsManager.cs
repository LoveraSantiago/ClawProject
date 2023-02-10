public class ModalMapsManager : AcaoMapaNavegado.ConsumidorEvento,
                                AcaoBotaoMapaAcionado.ConsumidorEvento
{
    private ModalFase modalFase;
    private ModalNoFicha modalNoFicha;
    private MapaEntidade mapaEntidadeAtual;
    private SomManagerMap somMap;

    public ModalMapsManager(MainMapaDto mainMapaDto, SomManagerMap somManagerMap)
    {
        modalFase = new ModalFase(mainMapaDto.ModalFaseDto, somManagerMap);
        modalNoFicha = new ModalNoFicha(mainMapaDto.ModalNoFichaDto, somManagerMap);
        this.somMap = somManagerMap;
    }

    private void abrirModal(MapaEntidade mapaEntidade, int indiceLevel)
    {
        if(UtilsFicha.possuiFichasDePrata(1))
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
