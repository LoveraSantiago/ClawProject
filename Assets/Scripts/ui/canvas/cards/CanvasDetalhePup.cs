using System;

public class CanvasDetalhePup : AcaoBotaoPowerUpEscolhido.ProdutorEvento,
                                AcaoCardPowerUpSelecionado.ConsumidorEvento
{
    public bool isAberto { get; private set; }
    private int indicePupSelecionado;

    private CanvasDetalheCardPupDto canvasDetalheDto;
    private ModalNoFicha modalNoFicha;//Temporariamente aqui    
    private SomManagerPup somManager;
    private ProdutorDeEvento<int> produtorEventoBtnEscohido;

    public CanvasDetalhePup(MainPupDto mainPupDto, OperacaoFicha operacaoFichaBronze, SomManagerPup somManager)
    {
        this.canvasDetalheDto = mainPupDto.CanvasDetalheDto;
        this.somManager       = somManager;
        this.canvasDetalheDto.BtnPratica.onClick.AddListener(()=> gotoScenePupPratica(operacaoFichaBronze));
        this.canvasDetalheDto.BtnCacaNiquelPupIndividual.onClick.AddListener(() => gotoScenePupCacaNiquelIndividual(operacaoFichaBronze));
        this.canvasDetalheDto.BtnCacaNiquelPupGeral.onClick.AddListener(()=> gotoScenePupCacaNiquelGeral(operacaoFichaBronze));
        isAberto = false;

        modalNoFicha = new ModalNoFicha(mainPupDto.ModalNoFichaDto, somManager);
        produtorEventoBtnEscohido = new ProdutorDeEvento<int>();
    }

    public void dismiss()
    {
        isAberto = false;
    }

    private void gotoScenePupPratica(OperacaoFicha operacaoFichaBronze)
    {        
        MapaEntidade mapaEntidade = HelperMapaEntidade.getMapaEntidadeByMapaEnum(MapaEnum.POWERUP);

        PowerUpEntidade pupEntidade = FactoryPowerUpEntidade.getPowerUpFromIndice(indicePupSelecionado);
        AbstractLevel level = mapaEntidade.getLevelByIndiceDezena((int)pupEntidade.tipo);
        ContextoEstaticoUtils.configMapaLevelAtual(mapaEntidade, level);

        abrirCenaOuModal(0, 0, operacaoFichaBronze);
    }

    private void gotoScenePupCacaNiquelIndividual(OperacaoFicha operacaoFichaBronze)
    {
     
        MapaEntidade mapaEntidade = HelperMapaEntidade.getMapaEntidadeByMapaEnum(MapaEnum.CACANIQUEL);
        AbstractLevel level = mapaEntidade.getLevelByIndiceDezena(2);
        ContextoEstaticoUtils.configMapaLevelAtual(mapaEntidade, level);

        PowerUpEntidade pupEntidade = FactoryPowerUpEntidade.getPowerUpFromIndice(indicePupSelecionado);
        int precoFicha = int.Parse(pupEntidade.preco);
        abrirCenaOuModal(1, precoFicha, operacaoFichaBronze);
    }

    private void gotoScenePupCacaNiquelGeral(OperacaoFicha operacaoFichaBronze)
    {     
        MapaEntidade mapaEntidade = HelperMapaEntidade.getMapaEntidadeByMapaEnum(MapaEnum.CACANIQUEL);
        AbstractLevel level = mapaEntidade.getLevelByIndiceDezena(1);
        ContextoEstaticoUtils.configMapaLevelAtual(mapaEntidade, level);
        
        abrirCenaOuModal(2, 1, operacaoFichaBronze);
    }

    private void abrirCenaOuModal(int indiceBtn, int precoFicha, OperacaoFicha operacaoFichaBronze)
    {
        if (UtilsFicha.possuiFichasDeBronze(precoFicha))
        {
            somManager.playSomCliqueIrParaLevel();
            operacaoFichaBronze.consumirFicha(precoFicha);            
            PlayerPrefsPowerUp.salvarIndicePup(indicePupSelecionado);
            produtorEventoBtnEscohido.produziuEvento(indiceBtn);
            ContextoEstaticoUtils.loading.irParaGameCena();            
        }
        else
        {
            modalNoFicha.ligar(Ficha.BRONZE, somManager);
        }
    }

    private void popularCanvasDetalhe(PowerUpEntidade pupEntidade)
    {
        isAberto = true;
        indicePupSelecionado = pupEntidade.indice;

        MaterialTipoPowerUpDto materialDetalhe  = pupEntidade.getMaterial();
        canvasDetalheDto.ImgBackground.color    = materialDetalhe.CorPrincipal;
        canvasDetalheDto.ImgCirculo.color       = materialDetalhe.CorCirculo;
        canvasDetalheDto.ImgExplicacao.color    = materialDetalhe.CorEscura;
        canvasDetalheDto.ImgPup.sprite          = pupEntidade.sprPersonagemPup;        
        canvasDetalheDto.ImgCorBtnPrin[0].color = materialDetalhe.CorVariacao1;
        canvasDetalheDto.ImgCorBtnPrin[1].color = materialDetalhe.CorVariacao2;
        canvasDetalheDto.ImgCorBtnPrin[2].color = materialDetalhe.CorVariacao3;
        canvasDetalheDto.ImgCorBtnSec[0].color  = materialDetalhe.CorCirculo;
        canvasDetalheDto.ImgCorBtnSec[1].color  = materialDetalhe.CorCirculo;
        canvasDetalheDto.ImgCorBtnSec[2].color  = materialDetalhe.CorCirculo;
        canvasDetalheDto.ImgBtns[0].color       = materialDetalhe.CorEscura;
        canvasDetalheDto.ImgBtns[1].color       = materialDetalhe.CorEscura;
        canvasDetalheDto.ImgBtns[2].color       = materialDetalhe.CorEscura;
        canvasDetalheDto.LblPreco.text          = pupEntidade.preco;
        canvasDetalheDto.LblExplicacao.text     = pupEntidade.descCurta + Environment.NewLine + pupEntidade.descDetalhada;
        canvasDetalheDto.LblQtd.text            = pupEntidade.getQtd().ToString();
        canvasDetalheDto.LblNome.text           = pupEntidade.nome;
        canvasDetalheDto.LblTipo.text           = pupEntidade.familia;
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
