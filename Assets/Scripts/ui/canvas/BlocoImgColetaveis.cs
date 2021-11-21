using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlocoImgColetaveis : AcaoBlocoImgColetavelAtual.ProdutorEvento,
                                  AcaoBBarItemEscolhido<int>.ConsumidorEvento
{
    private BlocoImgColetaveisDto blocoImgsDto;
    private Dictionary<string, Sprite> dicionarioDeSprites;
    private NavegacaoDeArray<ColetavelEntidade.FAMILIA> controleFamilia;
    private ProdutorDeEvento<UiColetavelInfo> produtorDeEvento;

    public BlocoImgColetaveis(
        Dictionary<string, Sprite> dicionarioDeSprites, 
        BlocoImgColetaveisDto blocoImgsDto)
    {
        this.blocoImgsDto = blocoImgsDto;
        this.dicionarioDeSprites = dicionarioDeSprites;
        produtorDeEvento = new ProdutorDeEvento<UiColetavelInfo>();

        ColetavelEntidade.FAMILIA[] familias = ColetavelEntidade.getFamiliasDeColetaveis();
        controleFamilia = new NavegacaoDeArray<ColetavelEntidade.FAMILIA>(familias, 0);
        blocoImgsDto.BtnDireita.onClick.AddListener(()=> irParaDireita());
        blocoImgsDto.BtnEsquerda.onClick.AddListener(()=> irParaEsquerda());

        ColetavelEntidade.FAMILIA familia = controleFamilia.getItemIndiceAtual();
        montarBlocoImagemComFamilia(familia);
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

    private void irParaDireita()
    {
        ColetavelEntidade.FAMILIA familia = controleFamilia.getItemAnterior();
        montarBlocoImagemComFamilia(familia);
        produzirEventoDeColetavelAtual(0);
    }

    private void irParaEsquerda()
    {
        ColetavelEntidade.FAMILIA familia = controleFamilia.getItemProximo();
        montarBlocoImagemComFamilia(familia);
        produzirEventoDeColetavelAtual(0);
    }

    private void montarBlocoImagemComFamilia(ColetavelEntidade.FAMILIA familia)
    {
        blocoImgsDto.LblNomeFamilia.text = familia.ToString();

        ColetavelHelper coletavelHelper = new ColetavelHelper();
        List<ColetavelEntidade> coletaveis = coletavelHelper.getListaDeColetaveisEntidadeByFamilia(familia);
        for (int contador = 0; contador < coletaveis.Count; contador++)
        {
            Sprite sprIt = dicionarioDeSprites[coletaveis[contador].nomeSprite];

            Image imageIt = blocoImgsDto.GrupoImgColetaveis[contador];
            imageIt.sprite = sprIt;            

            ColetavelEntidade coletavelIt = coletavelHelper.getColetavelEntidadeBySprite(sprIt.name);

            if (PlayerPrefsColetaveis.isFamiliaNotLocked(familia.ToString()))
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
                imageIt.material = null;
            }
        }
    }

    private void produzirEventoDeColetavelAtual(int indice)
    {
        ColetavelHelper coletavelHelper = new ColetavelHelper();

        Sprite sprProcurado = blocoImgsDto.GrupoImgColetaveis[indice].sprite;
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

    void AcaoBBarItemEscolhido<int>.ConsumidorEvento.consumirEvento(int evento)
    {
        controleFamilia.setIndiceAtual(evento);
        ColetavelEntidade.FAMILIA familiaAtual = controleFamilia.getItemIndiceAtual();
        montarBlocoImagemComFamilia(familiaAtual);
        produzirEventoDeColetavelAtual(0);
    }

    ProdutorDeEvento<UiColetavelInfo> AcaoBlocoImgColetavelAtual.ProdutorEvento.getProdutorDeEvento()
    {
        return produtorDeEvento;
    }
}
