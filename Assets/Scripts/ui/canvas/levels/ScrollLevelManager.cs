using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class ScrollLevelManager : ScrollMovimentador<LevelScroll>,
                            AcaoLevelFromScrollSelecao.ProdutorEvento  
{
    private int totalLevels;
    private Material[] materialMaquinas;
    private List<int> levelsLiberados;

    private PropsCimaBaixoScrollManager props;   
    private LevelScroll levelScroll;

    private ProdutorDeEvento<LevelItemScrollSelecaoDto> produtorDeEvento;

    public ScrollLevelManager(LevelsScrollDto levelsScrollDto)
    {
        totalLevels = PlayerPrefsMapas.getIndiceLevelLiberado();
        props = new PropsCimaBaixoScrollManager();

        levelScroll = new LevelScroll(levelsScrollDto);
        produtorDeEvento = new ProdutorDeEvento<LevelItemScrollSelecaoDto>();

        carregarMateriais();
        calcularTamanhoScroll();
        carregarReferenciasPosicoes();
        carregarLevelsLiberados();
        popularItensLevels();
        bindarBtnsLinha(levelsScrollDto);

        props.setItemLevelCima(levelScroll.getPrimeiroItemLevel());
        props.setItemLevelBaixo(levelScroll.getUltimoItemLevel());
    }

    public override void movimentarParaBaixo(LevelScroll levelScrollVazio)
    {
        float posYItemLevel = props.ItemLevelBaixo.getPosY();
        if (props.ContadorBaixoLevel < totalLevels && posYItemLevel > props.PosYReferenciaBaixo)
        {
            popularItemLevel(props.ItemLevelCima, props.ContadorBaixoLevel);
            reposicionarLevelItemParaUltimaPosicao(levelScroll);
            props.incrementarContadorBaixo();
            props.incrementarContadorCima();
            
            //Debug.Log("movimentarParaBaixo ACIONADO contadorcima " + contadorCimaLevel + " contadorbaixo " + contadorBaixoLevel);
        }
    }

    public override void movimentarParaCima(LevelScroll levelsScrollVazio)
    {
        float posYPrateleira = props.ItemLevelCima.getPosY();
        if(props.ContadorCimaLevel > 0 && posYPrateleira < props.PosYReferenciaCima)
        {
            props.decrementarContadorCima();
            popularItemLevel(props.ItemLevelBaixo, props.ContadorCimaLevel);
            reposicionarLevelItemParaPrimeiraPosicao(levelScroll);
            props.decrementarContadorBaixo();
            //Debug.Log("movimentarParaCima ACIONADO contadorcima " + contadorCimaLevel + " contadorbaixo " + contadorBaixoLevel);
        }
    }

    private void carregarMateriais()
    {
        int qtdItens = levelScroll.getQtdItens();
        materialMaquinas = new Material[qtdItens];
        for(int contador = 0; contador < qtdItens; contador++)
        {
            materialMaquinas[contador] = MaterialMiniMaquina.getNewMaterial();
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
        props.setPosYReferenciaBaixo(levelScroll.getPosYReferenciaBaixo());
        float posYZero = levelScroll.getItemLevel(0).getPosY();
        float posYHum  = levelScroll.getItemLevel(1).getPosY();
        float yDiferenca = posYZero - posYHum;
        props.setPosYReferenciaCima(levelScroll.getPosYReferenciaCima() + yDiferenca);        
        //Debug.Log("posYReferenciaBaixo " + posYReferenciaBaixo + " posYReferenciaCima " + posYReferenciaCima);
    }

    private void reposicionarLevelItemParaUltimaPosicao(LevelScroll levelsScroll)
    {
        Vector2 posBaixo = props.ItemLevelBaixo.getAnchoredPosition();
        float haltura = posBaixo.y - levelsScroll.getItemLevel(0).getHaltura();
        props.ItemLevelCima.setAnchoredPosition(new Vector2(posBaixo.x, haltura));
        props.ItemLevelCima.ligar();

        props.setItemLevelBaixo(props.ItemLevelCima);
        int indiceItem = (props.ItemLevelCima.getNomeItemNumerico() + 1) % levelsScroll.getQtdItens();
        props.setItemLevelCima(levelScroll.getItemLevel(indiceItem));
    }

    private void reposicionarLevelItemParaPrimeiraPosicao(LevelScroll levelScroll)
    {
        Vector2 posCima = props.ItemLevelCima.getAnchoredPosition();
        float haltura = posCima.y + levelScroll.getItemLevel(0).getHaltura();
        props.ItemLevelBaixo.setAnchoredPosition(new Vector2(posCima.x, haltura));        

        props.setItemLevelCima(props.ItemLevelBaixo);
        int indicePrateleira = ((props.ItemLevelCima.getNomeItemNumerico() + levelScroll.getQtdItens()) - 1) % levelScroll.getQtdItens();
        props.setItemLevelBaixo(this.levelScroll.getItemLevel(indicePrateleira));
    }

    private void popularItensLevels()
    {        
        for(int contadorItensLevels = 0; contadorItensLevels < levelScroll.getQtdItens(); contadorItensLevels++)
        {
            ItemLevelScroll itemLevelIt = levelScroll.getItemLevel(contadorItensLevels);
            itemLevelIt.setMaterial(materialMaquinas[contadorItensLevels]);
            popularItemLevel(contadorItensLevels, itemLevelIt, contadorItensLevels);
            props.incrementarContadorBaixo();            

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
        MapaEntidade mapaEntidade = LevelHelper.getMapaNormalByIndicesTotasDeLevels(indiceAtual);
        AbstractLevel level = LevelHelper.getLevelNormalByIndicesTotaisDeLevels(indiceAtual);
        string levelName = level.getLevelName();
        itemLevel.addLabels(indiceLevel, levelName, mapaEntidade.title, level.getMaquinaNome());
        itemLevel.desligarExclamacao();

        if (levelsLiberados.BinarySearch(indiceLevel) >= 0)
        {
            itemLevel.ligarExclamacao();
        }

        MaterialMiniMaquina.addCores(3, materialMaquinas[indiceMaterialMaquina], level.getDicionarioDeCores());
        //Debug.Log("level alias " + levelAlias + " level name " + levelName + " nome componente" + itemLevelDtoIt.LblLevel.transform.parent.name);
    }

    private void selecionado()
    {
        Debug.Log("Selecionado chamado");
        GameObject goSelecionado = EventSystem.current.currentSelectedGameObject;
        int indiceItem = int.Parse(goSelecionado.transform.parent.name);
        ItemLevelScroll itemLevel = levelScroll.getItemLevel(indiceItem);

        Vector3 posicaoItem = itemLevel.getPosicaoImgMaquina();
        Material materialCor = materialMaquinas[indiceItem];

        if (itemLevel.isExclamacaoLigado)
        {
            itemLevel.desligarExclamacao();
            PlayerPrefsMapas.consumidoNovaLiberacaoLevelEspecifico(itemLevel.indiceLevel);
        }

        itemLevel.desligarImgMaquina();
        levelScroll.ligarUltimaImgMaquina();
        levelScroll.atualizarItemAtual(indiceItem);

        LevelItemScrollSelecaoDto levelItem = new LevelItemScrollSelecaoDto(posicaoItem, materialCor);
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
