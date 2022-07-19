public class CanvasDetalheColetavel 
{
    private CanvasDetalheColetavelDto canvasDetalheDto;

    public CanvasDetalheColetavel(CanvasDetalheColetavelDto canvasDetalheDto)
    {
        this.canvasDetalheDto = canvasDetalheDto;
    }

    public void abrirDetalhe(int indicePrateleira, int indiceItem, PrateleirasDto prateleirasDto)
    {
        ItemPrateleiraDto itemSelecionado = prateleirasDto.PrateleiraDto[indicePrateleira].ItensPrateleira[indiceItem];


        canvasDetalheDto.ImgDetalhe.sprite   = itemSelecionado.ImgItem.sprite;
        canvasDetalheDto.ImgDetalhe.color    = itemSelecionado.ImgItem.color;
        canvasDetalheDto.ImgDetalhe.material = itemSelecionado.ImgItem.material;
        canvasDetalheDto.AnimatorCanvas.Play("abrir-detalhe");
    }    
}
