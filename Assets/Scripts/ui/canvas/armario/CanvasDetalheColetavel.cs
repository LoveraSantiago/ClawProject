using UnityEngine;
using UnityEngine.UI;

public class CanvasDetalheColetavel : AcaoItemArmarioSelecionado.ConsumidorEvento
{
    private static readonly int ABRIR_DETALHE  = Animator.StringToHash("abrir-detalhe");
    private static readonly int FECHAR_DETALHE = Animator.StringToHash("fechar-detalhe");
    private static readonly int DETALHE_ABERTO = Animator.StringToHash("detalhe-aberto");

    private CanvasDetalheColetavelDto canvasDetalheDto;    
    private ColetaveisParaPrateleiras coletaveisParaPrateleiras;
    private BotaoIrGameColetaveis     btnIrGameColetavel;   

    public CanvasDetalheColetavel(
        MainColetaveisDto mainDto, ColetaveisParaPrateleiras coletaveisParaPrateleiras, 
        OperacaoFicha operacaoFichaDeOuro, SomManagerColetaveis somManager)
    {
        this.canvasDetalheDto = mainDto.CanvasDetalheColetavelDto;        
        btnIrGameColetavel    = new BotaoIrGameColetaveis(mainDto, operacaoFichaDeOuro, somManager);
        this.coletaveisParaPrateleiras = coletaveisParaPrateleiras;
    }

    public void abrirDetalhe(IndiceArmarioSelecionadoDto indiceArmarioSelecionado)
    {        
        ItemPrateleiraDto itemSelecionado   = indiceArmarioSelecionado.itemSelecionado;
        Image imgItemPrateleria             = itemSelecionado.ImgItem;
        Sprite sprColetavel                 = imgItemPrateleria.sprite;
        ColetavelEntidade coletavelEntidade = coletaveisParaPrateleiras.getColetavelPeloSprite(sprColetavel);
        abrirDetalhe(coletavelEntidade, indiceArmarioSelecionado);        
        canvasDetalheDto.AnimatorCanvas.Play(ABRIR_DETALHE);
    }    

    private void abrirDetalhe(ColetavelEntidade coletavelEntidade, IndiceArmarioSelecionadoDto indiceArmarioSelecionado)
    {        
        ItemPrateleiraDto itemSelecionado = indiceArmarioSelecionado.itemSelecionado;
        Image imgItemPrateleria           = itemSelecionado.ImgItem;
        Sprite sprColetavel               = imgItemPrateleria.sprite;
        
        btnIrGameColetavel.prepararColetavelEntidade(coletavelEntidade, indiceArmarioSelecionado);

        Image imgDetalhe                 = canvasDetalheDto.ImgDetalhe;
        imgDetalhe.sprite                = sprColetavel;
        imgDetalhe.color                 = imgItemPrateleria.color;
        imgDetalhe.material              = imgItemPrateleria.material;
        canvasDetalheDto.LblNome.text    = coletavelEntidade.nome;
        canvasDetalheDto.LblFamilia.text = coletavelEntidade.mapaEntidade.title;
        canvasDetalheDto.ImgDetalhe.transform.position = itemSelecionado.ImgItem.transform.position;

        if (imgItemPrateleria.color == Color.black)
        {
            string texto = "Desbloqueie esse coletavel chegando no mapa da familia " + coletavelEntidade.mapaEntidade.title;
            canvasDetalheDto.LblTexto.text = texto;
            canvasDetalheDto.LblTexto.transform.gameObject.SetActive(true);
            canvasDetalheDto.CanvasBotoes.transform.gameObject.SetActive(false);
        }
        else if (MaterialGrayScale.isMaterialGrayScale(imgItemPrateleria.material))
        {
            canvasDetalheDto.CanvasBotoes.transform.gameObject.SetActive(true);
            canvasDetalheDto.LblTexto.transform.gameObject.SetActive(false);

            if (coletavelEntidade.isExclamacao)
            {
                itemSelecionado.ImgExclamacao.SetActive(false);
                coletavelEntidade.desligarExclamacao();
                PlayerPrefsMapas.consumirColetavelEstadoLiberadosDoMapa(coletavelEntidade);
            }            
        }
        else
        {
            string texto = "Parabens voce ja conquistou o coletavel " + coletavelEntidade.nome;
            canvasDetalheDto.LblTexto.text = texto;
            canvasDetalheDto.LblTexto.transform.gameObject.SetActive(true);
            canvasDetalheDto.CanvasBotoes.transform.gameObject.SetActive(false);
        }
    }

    public void detalheAberto(ColetavelEntidade coletavelEntidade, IndiceArmarioSelecionadoDto indiceArmarioSelecionado)
    {
        abrirDetalhe(coletavelEntidade, indiceArmarioSelecionado);
        canvasDetalheDto.AnimatorCanvas.Play(DETALHE_ABERTO);
    }

    public void fecharDetalhe()
    {
        canvasDetalheDto.AnimatorCanvas.Play(FECHAR_DETALHE);        
    }

    void AcaoItemArmarioSelecionado.ConsumidorEvento.consumirEvento(IndiceArmarioSelecionadoDto evento)
    {
        abrirDetalhe(evento);
    }
}
