using System;
using UnityEngine;

public class CanvasDetalhePup : AcaoBotaoPowerUpEscolhido.ProdutorEvento,
                                AcaoCardPowerUpSelecionado.ConsumidorEvento
{
    public bool isAberto { get; private set; }
    private int indicePupSelecionado;

    private CanvasDetalheCardPupDto canvasDetalheDto;
    private ModalNoFicha modalNoFicha;//Temporariamente aqui    
    private ProdutorDeEvento<int> produtorEventoBtnEscohido;

    public CanvasDetalhePup(CanvasDetalheCardPupDto canvasDetalheDto, ModalNoFichaDto modalNoFichaDto)
    {
        this.canvasDetalheDto = canvasDetalheDto;
        this.canvasDetalheDto.BtnPratica.onClick.AddListener(()=> gotoScenePupPratica());
        this.canvasDetalheDto.BtnCacaNiquelPupIndividual.onClick.AddListener(() => gotoScenePupCacaNiquelIndividual());
        this.canvasDetalheDto.BtnCacaNiquelPupGeral.onClick.AddListener(()=> gotoScenePupCacaNiquelGeral());
        isAberto = false;

        modalNoFicha = new ModalNoFicha(modalNoFichaDto);
        produtorEventoBtnEscohido = new ProdutorDeEvento<int>();
    }

    public void dismiss()
    {
        isAberto = false;
    }

    private void gotoScenePupPratica()
    {
        MapaEntidade mapaEntidade = HelperMapaEntidade.getMapaEntidadeByMapaEnum(MapaEnum.POWERUP, false);
        AbstractLevel level = mapaEntidade.getLevelByIndiceDezena(1);
        ContextoEstaticoUtils.configMapaLevelAtual(mapaEntidade, level);

        abrirCenaOuModal(0, 0);
    }

    private void gotoScenePupCacaNiquelIndividual()
    {
        MapaEntidade mapaEntidade = HelperMapaEntidade.getMapaEntidadeByMapaEnum(MapaEnum.CACANIQUEL, false);
        AbstractLevel level = mapaEntidade.getLevelByIndiceDezena(2);
        ContextoEstaticoUtils.configMapaLevelAtual(mapaEntidade, level);

        PowerUpEntidade pupEntidade = FactoryPowerUpEntidade.getPowerUpFromIndice(indicePupSelecionado);
        int precoFicha = int.Parse(pupEntidade.preco);
        abrirCenaOuModal(1, precoFicha);
    }

    private void gotoScenePupCacaNiquelGeral()
    {
        MapaEntidade mapaEntidade = HelperMapaEntidade.getMapaEntidadeByMapaEnum(MapaEnum.CACANIQUEL, false);
        AbstractLevel level = mapaEntidade.getLevelByIndiceDezena(1);
        ContextoEstaticoUtils.configMapaLevelAtual(mapaEntidade, level);
        
        abrirCenaOuModal(2, 1);
    }

    private void abrirCenaOuModal(int indiceBtn, int precoFicha)
    {
        if (PlayerPrefsFichas.possueFichas(Ficha.BRONZE, precoFicha))
        {
            PlayerPrefsFichas.consumirFicha(Ficha.BRONZE, precoFicha);
            PlayerPrefsPowerUp.salvarIndicePup(indicePupSelecionado);
            produtorEventoBtnEscohido.produziuEvento(indiceBtn);            
            CenaUtils.irParaCenaMainGame(0.9f);            
        }
        else
        {
            modalNoFicha.ligar();
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
