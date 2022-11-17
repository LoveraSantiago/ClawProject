using System;

public class CanvasDetalhePup : AcaoBotaoPowerUpEscolhido.ProdutorEvento,
                                AcaoCardPowerUpSelecionado.ConsumidorEvento
{
    public bool isAberto { get; private set; }
    private int indicePupSelecionado;

    private CanvasDetalheCardPupDto canvasDetalheDto;
    private ModalNoFicha modalNoFicha;//Temporariamente aqui    
    private ProdutorDeEvento<int> produtorEventoBtnEscohido;

    public CanvasDetalhePup(CanvasDetalheCardPupDto canvasDetalheDto, ModalNoFichaDto modalNoFichaDto, Loading loading)
    {
        this.canvasDetalheDto = canvasDetalheDto;
        this.canvasDetalheDto.BtnPratica.onClick.AddListener(()=> gotoScenePupPratica(loading));
        this.canvasDetalheDto.BtnCacaNiquelPupIndividual.onClick.AddListener(() => gotoScenePupCacaNiquelIndividual(loading));
        this.canvasDetalheDto.BtnCacaNiquelPupGeral.onClick.AddListener(()=> gotoScenePupCacaNiquelGeral(loading));
        isAberto = false;

        modalNoFicha = new ModalNoFicha(modalNoFichaDto);
        produtorEventoBtnEscohido = new ProdutorDeEvento<int>();
    }

    public void dismiss()
    {
        isAberto = false;
    }

    private void gotoScenePupPratica(Loading loading)
    {
        MapaEntidade mapaEntidade = HelperMapaEntidade.getMapaEntidadeByMapaEnum(MapaEnum.POWERUP);
        AbstractLevel level = mapaEntidade.getLevelByIndiceDezena(1);
        ContextoEstaticoUtils.configMapaLevelAtual(mapaEntidade, level);

        abrirCenaOuModal(0, 0, loading);
    }

    private void gotoScenePupCacaNiquelIndividual(Loading loading)
    {
        MapaEntidade mapaEntidade = HelperMapaEntidade.getMapaEntidadeByMapaEnum(MapaEnum.CACANIQUEL);
        AbstractLevel level = mapaEntidade.getLevelByIndiceDezena(2);
        ContextoEstaticoUtils.configMapaLevelAtual(mapaEntidade, level);

        PowerUpEntidade pupEntidade = FactoryPowerUpEntidade.getPowerUpFromIndice(indicePupSelecionado);
        int precoFicha = int.Parse(pupEntidade.preco);
        abrirCenaOuModal(1, precoFicha, loading);
    }

    private void gotoScenePupCacaNiquelGeral(Loading loading)
    {
        MapaEntidade mapaEntidade = HelperMapaEntidade.getMapaEntidadeByMapaEnum(MapaEnum.CACANIQUEL);
        AbstractLevel level = mapaEntidade.getLevelByIndiceDezena(1);
        ContextoEstaticoUtils.configMapaLevelAtual(mapaEntidade, level);
        
        abrirCenaOuModal(2, 1, loading);
    }

    private void abrirCenaOuModal(int indiceBtn, int precoFicha, Loading loading)
    {
        if (PlayerPrefsFichas.possueFichas(Ficha.BRONZE, precoFicha))
        {
            PlayerPrefsFichas.consumirFicha(Ficha.BRONZE, precoFicha);            
            PlayerPrefsPowerUp.salvarIndicePup(indicePupSelecionado);
            produtorEventoBtnEscohido.produziuEvento(indiceBtn);
            loading.irParaGameCena();            
        }
        else
        {
            modalNoFicha.ligar(Ficha.BRONZE);
        }
    }

    private void popularCanvasDetalhe(PowerUpEntidade pupEntidade)
    {
        isAberto = true;
        indicePupSelecionado = pupEntidade.indice;

        MaterialTipoPowerUpDto materialDetalhe = pupEntidade.getMaterial();
        canvasDetalheDto.ImgBackground.color   = materialDetalhe.CorPrincipal;
        canvasDetalheDto.ImgCirculo.color      = materialDetalhe.CorCirculo;
        canvasDetalheDto.ImgExplicacao.color   = materialDetalhe.CorEscura;
        canvasDetalheDto.ImgPup.sprite         = pupEntidade.sprPersonagemPup;
        canvasDetalheDto.ImgBtn.sprite         = pupEntidade.sprIconPowerUp;
        canvasDetalheDto.ImgsCorBtns[0].color  = materialDetalhe.CorVariacao1;
        canvasDetalheDto.ImgsCorBtns[1].color  = materialDetalhe.CorVariacao2;
        canvasDetalheDto.ImgsCorBtns[2].color  = materialDetalhe.CorVariacao3;
        canvasDetalheDto.LblPreco.text         = pupEntidade.preco;
        canvasDetalheDto.LblExplicacao.text    = pupEntidade.descCurta + Environment.NewLine + pupEntidade.descDetalhada;
        canvasDetalheDto.LblQtd.text           = pupEntidade.getQtd().ToString();
        canvasDetalheDto.LblNome.text          = pupEntidade.nome;
        canvasDetalheDto.LblTipo.text          = pupEntidade.familia;
    }

    void AcaoCardPowerUpSelecionado.ConsumidorEvento.consumirEvento(CardPupSelecionadoDto evento)
    {
        popularCanvasDetalhe(evento.powerUpEntidade);
    }

    ProdutorDeEvento<int> AcaoBotaoPowerUpEscolhido.ProdutorEvento.getProdutorDeEvento()
    {
        return produtorEventoBtnEscohido;
    }
}
