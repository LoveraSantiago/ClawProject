public class ModalFailGame : AbstractModalFim
{
    private ModalFailGameDto modalFailGameDto;

    public ModalFailGame(ModalFailGameDto modalFailOrdemDto, Loading loading)
    {
        this.modalFailGameDto = modalFailOrdemDto;
        modalFailOrdemDto.BtnAvancar.onClick.AddListener(() => irParaCena(loading));
    }

    public void failOrdem()
    {
        modalFailGameDto.ImgFail.sprite = modalFailGameDto.SpriteOrderFail;
        modalFailGameDto.TxtTitle.text = "Ordem Fail";
        modalFailGameDto.TxtMsg.text = "Falha ao seguir ordem para coletar.";
    }

    public void failTimeOver()
    {
        modalFailGameDto.ImgFail.sprite = modalFailGameDto.SpriteTimeOver;
        modalFailGameDto.TxtTitle.text = "Time Over";
        modalFailGameDto.TxtMsg.text = "Tempo total esgotado.";
    }

    public void failElevador()
    {
        modalFailGameDto.ImgFail.sprite = modalFailGameDto.SpriteElevadorFail;
        modalFailGameDto.TxtTitle.text = "Elevador Fail";
        modalFailGameDto.TxtMsg.text = "O elevador atingiu sua posição máxima";
    }

    public override void ligar(SomModais somModais)
    {
        modalFailGameDto.GoModal.SetActive(true);        
    }

    protected override void irParaCena(Loading loading)
    {
        loading.irParaMapScene();
    }
}
