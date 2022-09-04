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

    private void abrirModal(Level level)
    {
        if(PlayerPrefsFichas.possueFichas(Ficha.PRATA, 1))
        {
            modalFase.ligar(level);
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
        
    }
}
