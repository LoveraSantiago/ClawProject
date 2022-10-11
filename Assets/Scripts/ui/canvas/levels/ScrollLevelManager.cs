using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class ScrollLevelManager : ScrollMovimentador<LevelScroll>,
                            AcaoLevelFromScrollSelecao.ProdutorEvento  
{
    private int totalLevels;
    private List<int> levelsLiberados;

    private PropsCimaBaixoScrollManagerDto propsDto;   
    private LevelScroll levelScroll;

    private ProdutorDeEvento<LevelItemScrollSelecaoDto> produtorDeEvento;

    public ScrollLevelManager(LevelsScrollDto levelsScrollDto)
    {
        totalLevels = PlayerPrefsMapas.getIndiceLevelLiberado();
        propsDto = new PropsCimaBaixoScrollManagerDto();

        levelScroll = new LevelScroll(levelsScrollDto);
        produtorDeEvento = new ProdutorDeEvento<LevelItemScrollSelecaoDto>();

        calcularTamanhoScroll();
        carregarReferenciasPosicoes();
        carregarLevelsLiberados();
        popularItensLevels();
        bindarBtnsLinha(levelsScrollDto);

        propsDto.setItemLevelCima(levelScroll.getPrimeiroItemLevel());
        propsDto.setItemLevelBaixo(levelScroll.getUltimoItemLevel());
    }

    public override void movimentarParaBaixo(LevelScroll levelScrollVazio)
    {
        float posYItemLevel = propsDto.ItemLevelBaixo.getPosY();
        if (propsDto.ContadorBaixoLevel < totalLevels && posYItemLevel > propsDto.PosYReferenciaBaixo)
        {
            popularItemLevel(propsDto.ItemLevelCima, propsDto.ContadorBaixoLevel);
            reposicionarLevelItemParaUltimaPosicao(levelScroll);
            propsDto.incrementarContadorBaixo();
            propsDto.incrementarContadorCima();
            
            //Debug.Log("movimentarParaBaixo ACIONADO contadorcima " + contadorCimaLevel + " contadorbaixo " + contadorBaixoLevel);
        }
    }

    public override void movimentarParaCima(LevelScroll levelsScrollVazio)
    {
        float posYPrateleira = propsDto.ItemLevelCima.getPosY();
        if(propsDto.ContadorCimaLevel > 0 && posYPrateleira < propsDto.PosYReferenciaCima)
        {
            propsDto.decrementarContadorCima();
            popularItemLevel(propsDto.ItemLevelBaixo, propsDto.ContadorCimaLevel);
            reposicionarLevelItemParaPrimeiraPosicao(levelScroll);
            propsDto.decrementarContadorBaixo();
            //Debug.Log("movimentarParaCima ACIONADO contadorcima " + contadorCimaLevel + " contadorbaixo " + contadorBaixoLevel);
        }
    }

    private void calcularTamanhoScroll()
    {
        float qtdItens = totalLevels - levelScroll.getQtdItensVisiveis();
        float yAcrescimo = qtdItens * levelScroll.getItemLevel(0).getHaltura();
        levelScroll.posicionarOffset(new Vector2(0, -yAcrescimo));
    }

    private bool isTotalLevelsMenorQueScroll()
    {
        //Debug.Log("Total levels " + totalLevels + " Lenght " + levelsScrollDto.ItensLevelDto.Length);
        return totalLevels <= levelScroll.getQtdItens(); 
    }

    private void carregarReferenciasPosicoes()
    {
        propsDto.setPosYReferenciaBaixo(levelScroll.getPosYReferenciaBaixo());
        float posYZero = levelScroll.getItemLevel(0).getPosY();
        float posYHum  = levelScroll.getItemLevel(1).getPosY();
        float yDiferenca = posYZero - posYHum;
        propsDto.setPosYReferenciaCima(levelScroll.getPosYReferenciaCima() + yDiferenca);        
        //Debug.Log("posYReferenciaBaixo " + posYReferenciaBaixo + " posYReferenciaCima " + posYReferenciaCima);
    }

    private void reposicionarLevelItemParaUltimaPosicao(LevelScroll levelsScroll)
    {
        Vector2 posBaixo = propsDto.ItemLevelBaixo.getAnchoredPosition();
        float haltura = posBaixo.y - levelsScroll.getItemLevel(0).getHaltura();
        propsDto.ItemLevelCima.setAnchoredPosition(new Vector2(posBaixo.x, haltura));
        propsDto.ItemLevelCima.ligar();

        propsDto.setItemLevelBaixo(propsDto.ItemLevelCima);
        int indiceItem = (propsDto.ItemLevelCima.getNomeItemNumerico() + 1) % levelsScroll.getQtdItens();
        propsDto.setItemLevelCima(levelScroll.getItemLevel(indiceItem));
    }

    private void reposicionarLevelItemParaPrimeiraPosicao(LevelScroll levelScroll)
    {
        Vector2 posCima = propsDto.ItemLevelCima.getAnchoredPosition();
        float haltura = posCima.y + levelScroll.getItemLevel(0).getHaltura();
        propsDto.ItemLevelBaixo.setAnchoredPosition(new Vector2(posCima.x, haltura));        

        propsDto.setItemLevelCima(propsDto.ItemLevelBaixo);
        int indicePrateleira = ((propsDto.ItemLevelCima.getNomeItemNumerico() + levelScroll.getQtdItens()) - 1) % levelScroll.getQtdItens();
        propsDto.setItemLevelBaixo(this.levelScroll.getItemLevel(indicePrateleira));
    }

    private void popularItensLevels()
    {        
        for(int contadorItensLevels = 0; contadorItensLevels < levelScroll.getQtdItens(); contadorItensLevels++)
        {
            ItemLevelScroll itemLevelIt = levelScroll.getItemLevel(contadorItensLevels);
            popularItemLevel(contadorItensLevels, itemLevelIt, contadorItensLevels);
            propsDto.incrementarContadorBaixo();            

            int indiceLevel = contadorItensLevels + 1;
            if (isTotalLevelsMenorQueScroll() && (indiceLevel > totalLevels))
            {
                itemLevelIt.desligar();
            }          
        }
        //Debug.Log("Populado contadorcima " + contadorCimaLevel + " contadorbaixo " + contadorBaixoLevel);
    }

    private void bindarBtnsLinha(LevelsScrollDto levelsScrollDto)
    {
        for (int contadorItensLevels = 0; contadorItensLevels < levelsScrollDto.ItensLevelDto.Length; contadorItensLevels++)
        {
            ItemLevelDto itemLevelDtoIt = levelsScrollDto.ItensLevelDto[contadorItensLevels];
            itemLevelDtoIt.BtnLinha.onClick.AddListener(() => selecionado());
        }
    }

    private void popularItemLevel(ItemLevelScroll itemLevel, int indiceAtual)
    {
        popularItemLevel(itemLevel.getNomeItemNumerico(), itemLevel, indiceAtual);
    }

    private void popularItemLevel(int indiceMaterialMaquina, ItemLevelScroll itemLevel, int indiceAtual)
    {
        int indiceLevel = indiceAtual + 1;
        MapaEntidade mapaEntidade = HelperMapaEntidade.getMapaNormalByIndicesTotasDeLevels(indiceAtual);
        Debug.Log("Indice level " + indiceLevel);
        AbstractLevel level = mapaEntidade.getLevelByIndiceGeral(indiceLevel);
        string levelName = level.getLevelName();
        itemLevel.addLabels(indiceLevel, mapaEntidade.title, level);
        itemLevel.desligarExclamacao();
        itemLevel.colorirImgMaquina(level);

        if (levelsLiberados.BinarySearch(indiceLevel) >= 0)
        {
            itemLevel.ligarExclamacao();
        }

        //Debug.Log("level alias " + levelAlias + " level name " + levelName + " nome componente" + itemLevelDtoIt.LblLevel.transform.parent.name);
    }

    private void selecionado()
    {
        Debug.Log("Selecionado chamado");
        GameObject goSelecionado = EventSystem.current.currentSelectedGameObject;
        int indiceItem = int.Parse(goSelecionado.transform.parent.name);
        ItemLevelScroll itemLevel = levelScroll.getItemLevel(indiceItem);

        Vector3 posicaoItem = itemLevel.getPosicaoImgMaquina();

        if (itemLevel.isExclamacaoLigado)
        {
            itemLevel.desligarExclamacao();
            PlayerPrefsMapas.consumidoNovaLiberacaoLevelEspecifico(itemLevel.indiceLevel);
        }

        itemLevel.desligarImgMaquina();
        levelScroll.ligarUltimaImgMaquina();
        levelScroll.atualizarItemAtual(indiceItem);

        LevelItemScrollSelecaoDto levelItem = new LevelItemScrollSelecaoDto(posicaoItem, itemLevel.material);
        produtorDeEvento.produziuEvento(levelItem);
    }

    private void carregarLevelsLiberados()
    {
        int[] levels = PlayerPrefsMapas.getNovaLiberacaoLevelEspecifico();
        levelsLiberados = new List<int>(levels);        
    }

    ProdutorDeEvento<LevelItemScrollSelecaoDto> AcaoLevelFromScrollSelecao.ProdutorEvento.getProdutorDeEvento()
    {
        return produtorDeEvento;
    }
}
