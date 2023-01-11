using UnityEngine;

public class ScrollPupsManager : Draggavel,                                 
                                 AcaoPowerUpAcionado.ConsumidorEvento
{   
    private bool isLevelPup;
    private bool isPupsToLevel;
    private bool toqueAreaDraggavelValida;

    private int indiceBtnDesocupado;

    private ScrollPups scrollPups;
    public ScrollSelecao scrollSelecao { get; private set; }
    private PowerUpsParaLevel pupsToLevel;
    private IntervaloDeTempo intervaloTempo;

    public ScrollPupsManager(ScrollPupsDto scrollPupsDto)
    {
        scrollPups     = new ScrollPups(scrollPupsDto);
        scrollSelecao  = new ScrollSelecao();
        intervaloTempo = new IntervaloDeTempo(0);
    }

    public void configuradoPeloLevel(ScrollPupsDto scrollPupsDto, Materiais7SegmentosDto mat7Segmentos)
    {   
        if (LevelUtils.isPupLevel())
        {
            isLevelPup = true;
        }
        else if (ContextoEstaticoUtils.level.hasPupToLevel())
        {
            pupsToLevel = ContextoEstaticoUtils.level.getPupsToLevel();
            isPupsToLevel = true;
        }
        new ColoridorScrollPups().colorir(scrollPupsDto);
        scrollPups.configuradoPeloLevel(mat7Segmentos);
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

    public void update(InputGame inputGame, SomMaquina somMaquina)
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
                int qtdPup = PowerUpHelper.recuperarQtdPup(pupEntidade);
                if(qtdPup > 0)
                {
                    qtdPup = subtrairPowerUp(pupEntidade.nome);
                    DigitosItemScrollPup digitos = new DigitosItemScrollPup(itemSelecionado);
                    digitos.addQuantidade(qtdPup);
                    scrollSelecao.selecionouPup(indiceBtnDesocupado, pupEntidade.tipo);
                    somMaquina.playSomCliqueScroll();
                }
                else
                {
                    somMaquina.playSomCliqueScrollCancel();
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

    private int subtrairPowerUp(string nome)
    {
        if (LevelUtils.isTutorialLevel())
        {
            return 1;
        }
        return PlayerPrefsPowerUp.subtrairPup(nome); 
    }

    void AcaoPowerUpAcionado.ConsumidorEvento.consumirEvento(PowerUpInfoDto evento)
    {
        if (evento.isEstadoFinalizar)
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
}
