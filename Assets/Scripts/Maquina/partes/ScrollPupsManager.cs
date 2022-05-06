using UnityEngine;

public class ScrollPupsManager : Draggavel,
                                 AcaoBBarItemEscolhido<PowerUpBtnInfo>.ProdutorEvento,
                                 AcaoPowerUpAcionado.ConsumidorEvento
{
    private bool isLevelPup;
    private bool isPupsToLevel;

    private PowerUpsParaLevel pupsToLevel;
    public ScrollPups scrollPups { get; private set; }

    private Vector2 posicaoInicialDrag;

    public ScrollPupsManager()
    {
        scrollPups = new ScrollPups();
    }

    public void configuradoPeloLevel(ScrollPupsDto scrollPupsDto, AbstractLevel level)
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
    }

    public void iniciar()
    {
        if (isLevelPup)
        {
            int indicePup = PlayerPrefsPowerUp.recuperarIndicePup();
            for (int contador = 0; contador < 2; contador++)
            {
                scrollPups.simularCliqueBoxAcionado(contador, indicePup);
            }
        }
        else if (isPupsToLevel)
        {
            for (int contador = 0; contador < pupsToLevel.getQtdBotoes(); contador++)
            {
                scrollPups.simularCliqueBoxAcionado(contador, pupsToLevel.getPupEntidade(contador));
            }
        }
    }    

    public bool isDragAcionavel(Vector2 posicaoDrag)
    {
        return true;
    }

    public bool foiDragAcionado()
    {
        return true;
    }

    public void onBeginDrag(Vector3 posicao)
    {
        posicaoInicialDrag = posicao;
    }

    public void onDrag(Vector2 delta, MaquinaDto maquinaDto)
    {
        Debug.Log("Drag Scroll chamado");
        Vector2 diferenca = delta - posicaoInicialDrag;
        posicaoInicialDrag = delta;
        PosicaoTransform posicao = new PosicaoTransform(maquinaDto.ScrollPupsDto.TransfBarraRolagem);
        posicao.adicionarNaPosicaoHorizontal(diferenca);
    }

    public void onEndDrag(MaquinaDto maquinaDto)
    {
        
    }

    void AcaoPowerUpAcionado.ConsumidorEvento.consumirEvento(PowerUpInfo evento)
    {
        if (evento.isFinalizar)
        {
            if (isLevelPup)
            {
                int indicePup = PlayerPrefsPowerUp.recuperarIndicePup();
                scrollPups.simularCliqueBoxAcionado(evento.indiceBtn, indicePup);
            }
            else if (isPupsToLevel)
            {
                scrollPups.simularCliqueBoxAcionado(evento.indiceBtn, pupsToLevel.getPupEntidade(evento.indiceBtn));
            }
        }
    }

    ProdutorDeEvento<PowerUpBtnInfo> AcaoBBarItemEscolhido<PowerUpBtnInfo>.ProdutorEvento.getProdutorDeEvento()
    {
        return ((AcaoBBarItemEscolhido<PowerUpBtnInfo>.ProdutorEvento)scrollPups).getProdutorDeEvento();
    }

}
