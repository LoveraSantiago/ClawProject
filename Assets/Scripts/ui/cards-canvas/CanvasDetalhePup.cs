using System;

public class CanvasDetalhePup : AcaoCardPowerUpSelecionado.ConsumidorEvento
{
    public bool isAberto { get; private set; }

    private int indicePupSelecionado;
    private CanvasDetalheCardPupDto canvasDetalheDto;
    private ModalNoFicha modalNoFicha;//Temporariamente aqui

    public CanvasDetalhePup(CanvasDetalheCardPupDto canvasDetalheDto, ModalNoFichaDto modalNoFichaDto)
    {
        this.canvasDetalheDto = canvasDetalheDto;
        this.canvasDetalheDto.BtnPratica.onClick.AddListener(()=> gotoScenePupPratica());
        this.canvasDetalheDto.BtnCacaNiquelPupIndividual.onClick.AddListener(() => gotoScenePupCacaNiquelIndividual());
        this.canvasDetalheDto.BtnCacaNiquelPupGeral.onClick.AddListener(()=> gotoScenePupCacaNiquelGeral());
        isAberto = false;

        modalNoFicha = new ModalNoFicha(modalNoFichaDto);
    }

    public void dismiss()
    {
        isAberto = false;
    }

    private void gotoScenePupPratica()
    {
        PlayerPrefsLevel.salvarLevel(Level.PUP);
        abrirCenaOuModal(0);
    }

    private void gotoScenePupCacaNiquelIndividual()
    {
        PlayerPrefsLevel.salvarLevel(Level.CACANIQUEL_PUP_I);
        PowerUpEntidade pupEntidade = FactoryPowerUpEntidade.getPowerUpFromIndice(indicePupSelecionado);
        int precoFicha = int.Parse(pupEntidade.preco);
        abrirCenaOuModal(precoFicha);
    }

    private void gotoScenePupCacaNiquelGeral()
    {
        PlayerPrefsLevel.salvarLevel(Level.CACANIQUEL_PUP_G);
        abrirCenaOuModal(1);
    }

    private void abrirCenaOuModal(int precoFicha)
    {
        if (PlayerPrefsFichas.possueFichas(Ficha.BRONZE, precoFicha))
        {
            PlayerPrefsFichas.consumirFicha(Ficha.BRONZE, precoFicha);
            PlayerPrefsPowerUp.salvarIndicePup(indicePupSelecionado);
            CenaUtils.irParaCenaMainGame();
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
        canvasDetalheDto.ImgCorBtn1.color      = materialDetalhe.CorVariacao1;
        canvasDetalheDto.ImgCorBtn2.color      = materialDetalhe.CorVariacao2;
        canvasDetalheDto.ImgCorBtn3.color      = materialDetalhe.CorVariacao3;
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
}
