public class ModalFailOrdem : AbstractModalFim
{
    private ModalFailOrdemDto modalFailOrdemDto;

    public ModalFailOrdem(ModalFailOrdemDto modalFailOrdemDto)
    {
        this.modalFailOrdemDto = modalFailOrdemDto;
        modalFailOrdemDto.BtnAvancar.onClick.AddListener(() => irParaCena());
    }

    public override void ligar()
    {
        modalFailOrdemDto.GoModal.SetActive(true);        
    }

    protected override void irParaCena()
    {
        CenaUtils.irParaCenaMap();
    }
}
