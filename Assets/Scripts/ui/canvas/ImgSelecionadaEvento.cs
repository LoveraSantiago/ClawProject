using UnityEngine;
using UnityEngine.UI;

public class ImgSelecionadaEvento : AcaoBlocoImgColetavelAtual.ProdutorEvento
{
    private ProdutorDeEvento<UiColetavelInfo> produtorDeEvento;

    public ImgSelecionadaEvento()
    {
        produtorDeEvento = new ProdutorDeEvento<UiColetavelInfo>();
    }

    public void selecionadoImg(int indice, Image[] imgs)
    {
        ColetavelHelper coletavelHelper = new ColetavelHelper();

        Sprite sprProcurado = imgs[indice].sprite;
        ColetavelEntidade coletavelEntidade = coletavelHelper.getColetavelEntidadeBySprite(sprProcurado.name);

        if (PlayerPrefsColetaveis.isFamiliaLocked(coletavelEntidade.familia.ToString()))
        {
            produtorDeEvento.produziuEvento(UiColetavelInfo.ofLockado(sprProcurado, coletavelEntidade));
        }
        else if (PlayerPrefsColetaveis.isColetavelDisponivel(coletavelEntidade.nome))
        {
            produtorDeEvento.produziuEvento(UiColetavelInfo.ofColetado(sprProcurado, coletavelEntidade));
        }
        else
        {
            produtorDeEvento.produziuEvento(UiColetavelInfo.ofNaoColetado(sprProcurado, coletavelEntidade));
        }
    }

    ProdutorDeEvento<UiColetavelInfo> AcaoBlocoImgColetavelAtual.ProdutorEvento.getProdutorDeEvento()
    {
        return produtorDeEvento;
    }
}
