using UnityEngine;

public class CanvasDetalheColetavel 
{
    private static readonly int ABRIR_DETALHE = Animator.StringToHash("abrir-detalhe");
    private static readonly int FECHAR_DETALHE = Animator.StringToHash("fechar-detalhe");

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
        canvasDetalheDto.ImgDetalhe.transform.gameObject.SetActive(true);
        canvasDetalheDto.ImgDetalhe.transform.position = itemSelecionado.ImgItem.transform.position;
        canvasDetalheDto.AnimatorCanvas.Play(ABRIR_DETALHE);
    }    

    public void fecharDetalhe()
    {
        canvasDetalheDto.AnimatorCanvas.Play(FECHAR_DETALHE);        
    }

    public void fecharDetalheColetavel()
    {
        canvasDetalheDto.ImgDetalhe.transform.gameObject.SetActive(false);
    }
}
