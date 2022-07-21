using UnityEngine;
using UnityEngine.UI;

public class CanvasDetalheColetavel 
{
    private static readonly int ABRIR_DETALHE = Animator.StringToHash("abrir-detalhe");
    private static readonly int FECHAR_DETALHE = Animator.StringToHash("fechar-detalhe");

    private CanvasDetalheColetavelDto canvasDetalheDto;
    private HelperColetavelEntidade helperColetavelEntidade;

    public CanvasDetalheColetavel(CanvasDetalheColetavelDto canvasDetalheDto)
    {
        this.canvasDetalheDto = canvasDetalheDto;
        helperColetavelEntidade = new HelperColetavelEntidade();
    }

    public void abrirDetalhe(int indicePrateleira, int indiceItem, PrateleirasDto prateleirasDto)
    {
        ItemPrateleiraDto itemSelecionado = prateleirasDto.PrateleiraDto[indicePrateleira].ItensPrateleira[indiceItem];
        Image imgItemPrateleria = itemSelecionado.ImgItem;
        Sprite sprColetavel = imgItemPrateleria.sprite;
        ColetavelEntidade coletavelEntidade = helperColetavelEntidade.getColetavelEntidadeBySprite(sprColetavel.name);

        Image imgDetalhe    = canvasDetalheDto.ImgDetalhe;
        imgDetalhe.sprite   = sprColetavel;
        imgDetalhe.color    = imgItemPrateleria.color;
        imgDetalhe.material = imgItemPrateleria.material;
        canvasDetalheDto.LblNome.text = coletavelEntidade.nome;
        canvasDetalheDto.LblFamilia.text = coletavelEntidade.familia.ToString();
        canvasDetalheDto.ImgDetalhe.transform.position = itemSelecionado.ImgItem.transform.position;

        if(imgItemPrateleria.color == Color.black)
        {
            string texto = "Desbloqueie esse coletavel chegando no mapa da familia " + coletavelEntidade.familia.ToString();
            canvasDetalheDto.LblTexto.text = texto;
            canvasDetalheDto.LblTexto.transform.gameObject.SetActive(true);
            canvasDetalheDto.CanvasBotoes.transform.gameObject.SetActive(false);
        }
        else if(MaterialGrayScale.isMaterialGrayScale(imgItemPrateleria.material))
        {
            canvasDetalheDto.CanvasBotoes.transform.gameObject.SetActive(true);
            canvasDetalheDto.LblTexto.transform.gameObject.SetActive(false);
        }
        else
        {
            string texto = "Parabens voce ja conquistou o coletavel " + coletavelEntidade.nome;
            canvasDetalheDto.LblTexto.text = texto;
            canvasDetalheDto.LblTexto.transform.gameObject.SetActive(true);
            canvasDetalheDto.CanvasBotoes.transform.gameObject.SetActive(false);
        }
        canvasDetalheDto.AnimatorCanvas.Play(ABRIR_DETALHE);
    }    

    public void fecharDetalhe()
    {
        canvasDetalheDto.AnimatorCanvas.Play(FECHAR_DETALHE);        
    }    
}
