public class ModalFailOrdem : AbstractModalFim
{
    private ModalFailGameDto modalFailGameDto;

    public ModalFailOrdem(ModalFailGameDto modalFailOrdemDto)
    {
        this.modalFailGameDto = modalFailOrdemDto;
        modalFailOrdemDto.BtnAvancar.onClick.AddListener(() => irParaCena());
    }

    public override void ligar()
    {
        modalFailGameDto.GoModal.SetActive(true);        
    }

    protected override void irParaCena()
    {
        CenaUtils.irParaCenaMap();
    }
}
