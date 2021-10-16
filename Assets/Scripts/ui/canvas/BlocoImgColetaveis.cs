using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlocoImgColetaveis : AcaoBlocoImgColetavelAtual.ProdutorEvento
{
    private Image[] grupoImgColetaveis;
    private NavegacaoDeArray<ColetavelEntidade.FAMILIA> controleFamilia;
    private ProdutorDeEvento<UiColetavelInfo> produtorDeEvento;

    public BlocoImgColetaveis(
        Dictionary<string, Sprite> dicionarioDeSprites, BlocoImgColetaveisDto blocoImgsDto)
    {
        this.grupoImgColetaveis = blocoImgsDto.GrupoImgColetaveis;
        produtorDeEvento = new ProdutorDeEvento<UiColetavelInfo>();

        ColetavelEntidade.FAMILIA[] familias = { ColetavelEntidade.FAMILIA.FRUTAS,
                                                 ColetavelEntidade.FAMILIA.FAKE };

        controleFamilia = new NavegacaoDeArray<ColetavelEntidade.FAMILIA>(familias, 0);

        ColetavelHelper coletavelHelper = new ColetavelHelper();
        List<ColetavelEntidade> coletaveis = coletavelHelper.getListaDeColetaveisEntidadeByFamilia(familias[0]);
        for (int contador = 0; contador < coletaveis.Count; contador++)
        {
            Sprite sprIt = dicionarioDeSprites[coletaveis[contador].nomeSprite];

            Image imageIt = grupoImgColetaveis[contador];
            imageIt.sprite = sprIt;

            ColetavelEntidade coletavelIt = coletavelHelper.getColetavelEntidadeBySprite(sprIt.name);

            if (PlayerPrefsColetaveis.isFamiliaNotLocked(familias[0].ToString()))
            {
                if (PlayerPrefsColetaveis.isColetavelIndisponivel(coletavelIt.nome))
                {
                    Material matGray = new Material(Utils.materialGrayScale);
                    matGray.SetTexture("main_text", sprIt.texture);
                    imageIt.material = matGray;
                }
                imageIt.color = Color.white;
            }
            else
            {
                imageIt.color = Color.black;
            }
        }        
    }

    public void startLaizy()
    {
        produzirEventoDeColetavelAtual(0);
    }

    public void clicouNaImg(GameObject goClicado)
    {
        string nomeGo = goClicado.name;
        if (nomeGo.StartsWith("img-coletavel"))
        {
            string subStringIndice = nomeGo.Replace("img-coletavel", "");
            int indice = int.Parse(subStringIndice) - 1;
            produzirEventoDeColetavelAtual(indice);
        }
    }

    private void produzirEventoDeColetavelAtual(int indice)
    {
        ColetavelHelper coletavelHelper = new ColetavelHelper();
        Sprite sprProcurado = grupoImgColetaveis[indice].sprite;
        ColetavelEntidade coletavelEntidade = coletavelHelper.getColetavelEntidadeBySprite(sprProcurado.name);
        produtorDeEvento.produziuEvento(UiColetavelInfo.ofColetado(sprProcurado, coletavelEntidade));
    }

    ProdutorDeEvento<UiColetavelInfo> AcaoBlocoImgColetavelAtual.ProdutorEvento.getProdutorDeEvento()
    {
        return produtorDeEvento;
    }
}
