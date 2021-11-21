using System.Collections.Generic;
using UnityEngine;

public class BlocoImgColetaveis : AcaoBlocoImgColetavelAtual.ProdutorEvento,
                                  AcaoBBarItemEscolhido<int>.ConsumidorEvento
{
    private BlocoImgColetaveisDto blocoImgsDto;
    private MontadorBlocoImgFamilia montadorBlocoImg;

    private NavegacaoDeArray<ColetavelEntidade.FAMILIA> controleFamilia;

    private ProdutorDeEvento<UiColetavelInfo> produtorDeEvento;

    public BlocoImgColetaveis(
        Dictionary<string, Sprite> dicionarioDeSprites, 
        BlocoImgColetaveisDto blocoImgsDto)
    {
        this.blocoImgsDto = blocoImgsDto;
        
        produtorDeEvento = new ProdutorDeEvento<UiColetavelInfo>();

        ColetavelEntidade.FAMILIA[] familias = ColetavelEntidade.getFamiliasDeColetaveis();
        int indiceInicial = PlayerPrefsColetaveis.recuperarEApagarIndiceFamilia();
        controleFamilia = new NavegacaoDeArray<ColetavelEntidade.FAMILIA>(familias, indiceInicial);
        blocoImgsDto.BtnDireita.onClick.AddListener(()=> irParaDireita());
        blocoImgsDto.BtnEsquerda.onClick.AddListener(()=> irParaEsquerda());

        ColetavelEntidade.FAMILIA familia = controleFamilia.getItemIndiceAtual();

        montadorBlocoImg = new MontadorBlocoImgFamilia(dicionarioDeSprites);
        montadorBlocoImg.montarBlocoImagemComFamilia(blocoImgsDto, familia);
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
        montadorBlocoImg.montarBlocoImagemComFamilia(blocoImgsDto, familia);
        produzirEventoDeColetavelAtual(0);
    }

    private void irParaEsquerda()
    {
        ColetavelEntidade.FAMILIA familia = controleFamilia.getItemProximo();
        montadorBlocoImg.montarBlocoImagemComFamilia(blocoImgsDto, familia);
        produzirEventoDeColetavelAtual(0);
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
        montadorBlocoImg.montarBlocoImagemComFamilia(blocoImgsDto, familiaAtual);
        produzirEventoDeColetavelAtual(0);
    }

    ProdutorDeEvento<UiColetavelInfo> AcaoBlocoImgColetavelAtual.ProdutorEvento.getProdutorDeEvento()
    {
        return produtorDeEvento;
    }
}
