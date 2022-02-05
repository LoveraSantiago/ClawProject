public class ModalNoFicha 
{
    private ModalNoFichaDto modalNoFichaDto;

    public ModalNoFicha(ModalNoFichaDto modalNoFichaDto)
    {
        this.modalNoFichaDto = modalNoFichaDto;
        modalNoFichaDto.BtnOk.onClick.AddListener(() => desligar());
    }

    public void ligar()
    {
        modalNoFichaDto.ModalNoFicha.SetActive(true);
    }

    private void desligar()
    {
        modalNoFichaDto.ModalNoFicha.SetActive(false);
    }
}
