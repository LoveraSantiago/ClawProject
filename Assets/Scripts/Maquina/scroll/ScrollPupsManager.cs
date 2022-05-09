using UnityEngine;

public class ScrollPupsManager : Draggavel,
                                 AcaoBBarItemEscolhido<PowerUpBtnInfo>.ProdutorEvento,
                                 AcaoPowerUpAcionado.ConsumidorEvento
{
    private bool isLevelPup;
    private bool isPupsToLevel;
    private bool toqueAreaDraggavelValida;

    private PowerUpsParaLevel pupsToLevel;
    private ScrollPups scrollPups;
    private ScrollSelecao scrollSelecao;

    public ScrollPupsManager(ScrollPupsDto scrollPupsDto)
    {
        scrollPups = new ScrollPups(scrollPupsDto);
        scrollSelecao = new ScrollSelecao();
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
        if (inputGame.aconteceuTapNaAreaInferior())
        {
            Debug.Log("PRESSIONADO");
        }
        else if (inputGame.aconteceuTapNaAreaSuperior())
        {
            scrollSelecao.cancelouSelecao();
        }
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
        scrollPups.prepararBarraDeRolagem(posicao);
    }

    public void onDrag(Vector2 delta, MaquinaDto maquinaDto)
    {
        scrollPups.dragBarraDeRolagem(delta);     
    }

    public void onEndDrag(MaquinaDto maquinaDto)
    {
        toqueAreaDraggavelValida = false;
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

    ProdutorDeEvento<PowerUpBtnInfo> AcaoBBarItemEscolhido<PowerUpBtnInfo>.ProdutorEvento.getProdutorDeEvento()
    {
        return ((AcaoBBarItemEscolhido<PowerUpBtnInfo>.ProdutorEvento)scrollSelecao).getProdutorDeEvento();
    }
}
