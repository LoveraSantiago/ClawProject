public class ModalFailGame : AbstractModalFim
{
    private ModalFailGameDto modalFailGameDto;

    public ModalFailGame(ModalFailGameDto modalFailOrdemDto)
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
