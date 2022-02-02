public class ModalMapsManager 
{
    private ModalFase modalFase;
    private ModalNoFicha modalNoFicha;

    public ModalMapsManager(ModalFaseDto modalFaseDto, ModalNoFichaDto modalNoFichaDto)
    {
        modalFase = new ModalFase(modalFaseDto);
        modalNoFicha = new ModalNoFicha(modalNoFichaDto);
    }

    public void abrirModal(Level level)
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
}
