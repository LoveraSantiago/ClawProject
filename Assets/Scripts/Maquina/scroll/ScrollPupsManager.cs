using UnityEngine;

public class ScrollPupsManager : Draggavel,
                                 AcaoItemEscolhido<PowerUpBtnInfo>.ProdutorEvento,
                                 AcaoPowerUpAcionado.ConsumidorEvento
{   
    private bool isLevelPup;
    private bool isPupsToLevel;
    private bool toqueAreaDraggavelValida;

    private int indiceBtnDesocupado;

    private ScrollPups scrollPups;
    private ScrollSelecao scrollSelecao;
    private PowerUpsParaLevel pupsToLevel;
    private IntervaloDeTempo intervaloTempo;

    public ScrollPupsManager(ScrollPupsDto scrollPupsDto)
    {
        scrollPups = new ScrollPups(scrollPupsDto);
        scrollSelecao = new ScrollSelecao();
        intervaloTempo = new IntervaloDeTempo(0);
    }

    public void configuradoPeloLevel(ScrollPupsDto scrollPupsDto, Materiais7SegmentosDto mat7Segmentos, AbstractLevel level)
    {   
        if (LevelUtils.isPupLevel(level))
        {
            isLevelPup = true;
        }
        else if (level.hasPupToLevel())
        {
            pupsToLevel = level.getPupsToLevel();
            isPupsToLevel = true;
        }
        new ColoridorScrollPups().colorir(scrollPupsDto, level.getDicionarioDeCores());
        scrollPups.configuradoPeloLevel(mat7Segmentos, level);
    }

    public void iniciar()
    {
        if (isLevelPup)
        {
            int indicePup = PlayerPrefsPowerUp.recuperarIndicePup();
            for (int contador = 0; contador < 2; contador++)
            {
                scrollSelecao.selecionouIndicePup(contador, indicePup);
            }
        }
        else if (isPupsToLevel)
        {
            for (int contador = 0; contador < pupsToLevel.getQtdBotoes(); contador++)
            {
                scrollSelecao.selecionouPup(contador, pupsToLevel.getPupEntidade(contador));
            }
        }
        scrollPups.iniciar();
    }    

    public void update(InputGame inputGame)
    {
        if (desconsiderarTap())
        {
            return;
        }
        else if (inputGame.aconteceuTapNaAreaInferior())
        {
            Vector3 posicaoTap = inputGame.getPosicaoTap();
            if (scrollPups.isToqueDentroPlacaInterna(posicaoTap))
            {
                ItemScrollDto itemSelecionado = scrollPups.getSpritePupTocado(posicaoTap);
                Sprite sprPup = itemSelecionado.SprRendererImgPup.sprite;
                PowerUpEntidade pupEntidade = PowerUpHelper.getTipoPupBySprite(sprPup);
                int qtdPup = PlayerPrefsPowerUp.recuperarQtdPup(pupEntidade.nome);
                if(qtdPup > 0)
                {
                    qtdPup = PlayerPrefsPowerUp.subtrairPup(pupEntidade.nome);
                    DigitosItemScrollPup digitos = new DigitosItemScrollPup(itemSelecionado);
                    digitos.addQuantidade(qtdPup);
                    scrollSelecao.selecionouPup(indiceBtnDesocupado, pupEntidade.tipo);
                }
                else
                {
                    scrollSelecao.cancelouSelecao();
                }
            }
            inputGame.consumirTap();
        }
        else if (inputGame.aconteceuTapNaAreaSuperior())
        {
            //Debug.Log("TAP SUPERIOR SCROLL");
            inputGame.consumirTap();
            scrollSelecao.cancelouSelecao();
        }
    }

    public void setIndiceBotaoVazioAtual(int indice)
    {
        indiceBtnDesocupado = indice;
    }

    public bool isDragAcionavel(Vector2 posicaoDrag)
    {
        toqueAreaDraggavelValida = scrollPups.isToqueDentroPlacaInterna(posicaoDrag);
        return toqueAreaDraggavelValida;        
    }

    public bool foiDragAcionado()
    {
        return toqueAreaDraggavelValida;
    }

    public void onBeginDrag(Vector3 posicao)
    {
        intervaloTempo.addTempoLongo();
        scrollPups.prepararBarraDeRolagem(posicao);
    }

    public void onDrag(Vector2 delta, MaquinaDto maquinaDto)
    {
        scrollPups.dragBarraDeRolagem(delta);     
    }

    public void onEndDrag(MaquinaDto maquinaDto)
    {
        intervaloTempo.configTempoParaAcao(0.1f);
        toqueAreaDraggavelValida = false;
    }

    private bool considerarTap()
    {
        return intervaloTempo.contarTempoUnescaled();
    }

    private bool desconsiderarTap()
    {
        return !considerarTap();
    }

    void AcaoPowerUpAcionado.ConsumidorEvento.consumirEvento(PowerUpInfo evento)
    {
        if (evento.isFinalizar)
        {
            if (isLevelPup)
            {
                int indicePup = PlayerPrefsPowerUp.recuperarIndicePup();
                scrollSelecao.selecionouIndicePup(evento.indiceBtn, indicePup);
            }
            else if (isPupsToLevel)
            {
                scrollSelecao.selecionouPup(evento.indiceBtn, pupsToLevel.getPupEntidade(evento.indiceBtn));
            }
        }
    }

    ProdutorDeEvento<PowerUpBtnInfo> AcaoItemEscolhido<PowerUpBtnInfo>.ProdutorEvento.getProdutorDeEvento()
    {
        return ((AcaoItemEscolhido<PowerUpBtnInfo>.ProdutorEvento)scrollSelecao).getProdutorDeEvento();
    }
}
