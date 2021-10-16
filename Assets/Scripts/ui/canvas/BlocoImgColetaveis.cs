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
            grupoImgColetaveis[contador].sprite = dicionarioDeSprites[coletaveis[contador].nomeSprite];
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
        produtorDeEvento.produziuEvento(new UiColetavelInfo(coletavelEntidade, sprProcurado));
    }

    ProdutorDeEvento<UiColetavelInfo> AcaoBlocoImgColetavelAtual.ProdutorEvento.getProdutorDeEvento()
    {
        return produtorDeEvento;
    }
}
