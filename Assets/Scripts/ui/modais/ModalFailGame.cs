public class ModalFailGame : AbstractModalFim
{
    private ModalFailGameDto modalFailGameDto;
    private SomModais somModais;

    public ModalFailGame(ModalFailGameDto modalFailOrdemDto, SomModais somModais)
    {
        this.modalFailGameDto = modalFailOrdemDto;
        this.somModais = somModais;
        modalFailOrdemDto.BtnAvancar.onClick.AddListener(() => irParaCena());
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

    public override void ligar()
    {
        somModais.playSomAbrirModal();
        modalFailGameDto.GoModal.SetActive(true);        
    }

    protected override void irParaCena()
    {
        somModais.playSomCliquePositivo();
        ContextoEstaticoUtils.loading.irParaMapScene();
    }
}
