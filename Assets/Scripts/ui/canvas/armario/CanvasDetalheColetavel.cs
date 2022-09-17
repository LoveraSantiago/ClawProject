using UnityEngine;
using UnityEngine.UI;

public class CanvasDetalheColetavel 
{
    private static readonly int ABRIR_DETALHE  = Animator.StringToHash("abrir-detalhe");
    private static readonly int FECHAR_DETALHE = Animator.StringToHash("fechar-detalhe");
    private static readonly int DETALHE_ABERTO = Animator.StringToHash("detalhe-aberto");

    private CanvasDetalheColetavelDto canvasDetalheDto;    
    private BotaoIrGameColetaveis btnIrGameColetavel;

    public CanvasDetalheColetavel(MainColetaveisDto mainDto)
    {
        this.canvasDetalheDto = mainDto.CanvasDetalheColetavelDto;
        btnIrGameColetavel = new BotaoIrGameColetaveis(canvasDetalheDto.BtnColetavel, mainDto.ModalNoFichaDto);        
    }

    public void abrirDetalhe(IndiceArmarioSelecionadoDto indiceArmarioSelecionado, PrateleirasDto prateleirasDto)
    {
        PrateleiraArmarioDto prateleira = prateleirasDto.PrateleiraDto[indiceArmarioSelecionado.indicePrateleira];
        ItemPrateleiraDto itemSelecionado = prateleira.ItensPrateleira[indiceArmarioSelecionado.indiceItem];
        Image imgItemPrateleria = itemSelecionado.ImgItem;
        Sprite sprColetavel = imgItemPrateleria.sprite;
        ColetavelEntidade coletavelEntidade = HelperColetavelEntidade.getColetavelEntidadeBySprite(sprColetavel.name);
        abrirDetalhe(coletavelEntidade, indiceArmarioSelecionado, prateleirasDto);        
        canvasDetalheDto.AnimatorCanvas.Play(ABRIR_DETALHE);
    }    

    private void abrirDetalhe(ColetavelEntidade coletavelEntidade, IndiceArmarioSelecionadoDto indiceArmarioSelecionado, PrateleirasDto prateleirasDto)
    {
        PrateleiraArmarioDto prateleira = prateleirasDto.PrateleiraDto[indiceArmarioSelecionado.indicePrateleira];
        ItemPrateleiraDto itemSelecionado = prateleira.ItensPrateleira[indiceArmarioSelecionado.indiceItem];
        Image imgItemPrateleria = itemSelecionado.ImgItem;
        Sprite sprColetavel = imgItemPrateleria.sprite;
        
        btnIrGameColetavel.prepararColetavelEntidade(coletavelEntidade, indiceArmarioSelecionado);

        Image imgDetalhe = canvasDetalheDto.ImgDetalhe;
        imgDetalhe.sprite = sprColetavel;
        imgDetalhe.color = imgItemPrateleria.color;
        imgDetalhe.material = imgItemPrateleria.material;
        canvasDetalheDto.LblNome.text = coletavelEntidade.nome;
        canvasDetalheDto.LblFamilia.text = coletavelEntidade.mapaEnum.ToString();
        canvasDetalheDto.ImgDetalhe.transform.position = itemSelecionado.ImgItem.transform.position;

        if (imgItemPrateleria.color == Color.black)
        {
            string texto = "Desbloqueie esse coletavel chegando no mapa da familia " + coletavelEntidade.mapaEnum.ToString();
            canvasDetalheDto.LblTexto.text = texto;
            canvasDetalheDto.LblTexto.transform.gameObject.SetActive(true);
            canvasDetalheDto.CanvasBotoes.transform.gameObject.SetActive(false);
        }
        else if (MaterialGrayScale.isMaterialGrayScale(imgItemPrateleria.material))
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
    }

    public void detalheAberto(ColetavelEntidade coletavelEntidade, IndiceArmarioSelecionadoDto indiceArmarioSelecionado, PrateleirasDto prateleirasDto)
    {
        abrirDetalhe(coletavelEntidade, indiceArmarioSelecionado, prateleirasDto);
        canvasDetalheDto.AnimatorCanvas.Play(DETALHE_ABERTO);
    }

    public void fecharDetalhe()
    {
        canvasDetalheDto.AnimatorCanvas.Play(FECHAR_DETALHE);        
    }    
}
