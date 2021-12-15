using UnityEngine;

public class BlocoImgColetaveis : AcaoBlocoImgColetavelAtual.ProdutorEvento,
                                  AcaoBBarItemEscolhido<int>.ConsumidorEvento
{
    private BlocoImgColetaveisDto blocoImgsDto;
    private MontadorBlocoImgFamilia montadorBlocoImg;
    private ImgSelecionadaEvento imgSelecionadaEvento;
    private NavegacaoDeArray<ColetavelEntidade.FAMILIA> controleFamilia;

    public BlocoImgColetaveis(BlocoImgColetaveisDto blocoImgsDto)
    {
        this.blocoImgsDto = blocoImgsDto;

        imgSelecionadaEvento = new ImgSelecionadaEvento();        

        ColetavelEntidade.FAMILIA[] familias = ColetavelEntidade.getFamiliasDeColetaveis();
        int indiceInicial = PlayerPrefsColetaveis.recuperarEApagarIndiceFamilia();
        controleFamilia = new NavegacaoDeArray<ColetavelEntidade.FAMILIA>(familias, indiceInicial);
        blocoImgsDto.BtnDireita.onClick.AddListener(()=> irParaDireita());
        blocoImgsDto.BtnEsquerda.onClick.AddListener(()=> irParaEsquerda());

        ColetavelEntidade.FAMILIA familia = controleFamilia.getItemIndiceAtual();

        montadorBlocoImg = new MontadorBlocoImgFamilia();
        montadorBlocoImg.montarBlocoImagemComFamilia(blocoImgsDto, familia);
    }

    public void startLaizy()
    {
        imgSelecionadaEvento.selecionadoDefault(blocoImgsDto.GrupoImgColetaveis);        
    }

    public void clicouNaImg(GameObject goClicado)
    {
        string nomeGo = goClicado.name;
        if (nomeGo.StartsWith("img-coletavel"))
        {
            string subStringIndice = nomeGo.Replace("img-coletavel", "");
            int indice = int.Parse(subStringIndice) - 1;
            imgSelecionadaEvento.selecionadoImg(indice, blocoImgsDto.GrupoImgColetaveis);            
        }
    }

    private void irParaDireita()
    {
        ColetavelEntidade.FAMILIA familia = controleFamilia.getItemAnterior();
        montadorBlocoImg.montarBlocoImagemComFamilia(blocoImgsDto, familia);
        imgSelecionadaEvento.selecionadoImg(0, blocoImgsDto.GrupoImgColetaveis);        
    }

    private void irParaEsquerda()
    {
        ColetavelEntidade.FAMILIA familia = controleFamilia.getItemProximo();
        montadorBlocoImg.montarBlocoImagemComFamilia(blocoImgsDto, familia);
        imgSelecionadaEvento.selecionadoImg(0, blocoImgsDto.GrupoImgColetaveis);
    }

    void AcaoBBarItemEscolhido<int>.ConsumidorEvento.consumirEvento(int evento)
    {
        controleFamilia.setIndiceAtual(evento);
        ColetavelEntidade.FAMILIA familiaAtual = controleFamilia.getItemIndiceAtual();
        montadorBlocoImg.montarBlocoImagemComFamilia(blocoImgsDto, familiaAtual);
        imgSelecionadaEvento.selecionadoImg(0, blocoImgsDto.GrupoImgColetaveis);
    }

    ProdutorDeEvento<UiColetavelInfo> AcaoBlocoImgColetavelAtual.ProdutorEvento.getProdutorDeEvento()
    {
        return ((AcaoBlocoImgColetavelAtual.ProdutorEvento)imgSelecionadaEvento).getProdutorDeEvento();
    }
}
