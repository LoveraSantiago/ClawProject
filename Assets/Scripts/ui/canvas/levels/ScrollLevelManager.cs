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
    //private LevelsScrollDto levelsScrollDto;
    private LevelScroll levelScroll;

    //private GameObject goImgMaquina;
    private ProdutorDeEvento<LevelItemDto> produtorDeEvento;

    public ScrollLevelManager(LevelsScrollDto levelsScrollDto)
    {
        totalLevels = PlayerPrefsMapas.getIndiceLevelLiberado();
        props = new PropsCimaBaixoScrollManager();

        levelScroll = new LevelScroll(levelsScrollDto);
        //this.levelsScrollDto = levelsScrollDto;
        produtorDeEvento = new ProdutorDeEvento<LevelItemDto>();

        carregarMateriais();
        calcularTamanhoScroll();
        carregarReferenciasPosicoes();
        carregarLevelsLiberados();
        popularItensLevels();
        bindarBtnsLinha(levelsScrollDto);

        //props.setItemLevelCima(levelsScrollDto.ItensLevelDto[0]);
        props.setItemLevelCima(levelScroll.getPrimeiroItemLevel());
        //props.setItemLevelBaixo(levelsScrollDto.ItensLevelDto[levelsScrollDto.ItensLevelDto.Length - 1]);
        props.setItemLevelBaixo(levelScroll.getUltimoItemLevel());
    }
   
    public override void movimentarParaBaixo(LevelScroll levelScrollVazio)
    {
        //float posYItemLevel = props.ItemLevelBaixo.RItem.transform.position.y;
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
        //float posYPrateleira = props.ItemLevelCima.RItem.transform.position.y;
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
        //int qtdItens = levelsScrollDto.ItensLevelDto.Length;
        int qtdItens = levelScroll.getQtdItens();
        materialMaquinas = new Material[qtdItens];
        for(int contador = 0; contador < qtdItens; contador++)
        {
            materialMaquinas[contador] = MaterialMiniMaquina.getNewMaterial();
        }
    }

    private void calcularTamanhoScroll()
    {
        //float qtdItens = totalLevels - levelsScrollDto.QtdItensVisiveis;
        float qtdItens = totalLevels - levelScroll.getQtdItensVisiveis();
        //float yAcrescimo = qtdItens * levelsScrollDto.ItensLevelDto[0].RItem.rect.height;
        float yAcrescimo = qtdItens * levelScroll.getItemLevel(0).getHaltura();
        //levelsScrollDto.RTransformScroll.offsetMin += new Vector2(0, -yAcrescimo);
        levelScroll.posicionarOffset(new Vector2(0, -yAcrescimo));
    }

    private bool isTotalLevelsMenorQueScroll()
    {
        //Debug.Log("Total levels " + totalLevels + " Lenght " + levelsScrollDto.ItensLevelDto.Length);
        //return totalLevels <= levelsScrollDto.ItensLevelDto.Length;
        return totalLevels <= levelScroll.getQtdItens(); 
    }

    private void carregarReferenciasPosicoes()
    {
        //props.setPosYReferenciaBaixo(levelsScrollDto.RTransformRefBaixo.position.y);        
        props.setPosYReferenciaBaixo(levelScroll.getPosYReferenciaBaixo());
        //float yDiferenca = (levelsScrollDto.ItensLevelDto[0].RItem.position.y - levelsScrollDto.ItensLevelDto[1].RItem.position.y);
        float posYZero = levelScroll.getItemLevel(0).getPosY();
        float posYHum  = levelScroll.getItemLevel(1).getPosY();
        float yDiferenca = posYZero - posYHum;
        //props.setPosYReferenciaCima(levelsScrollDto.RTransformRefCima.position.y + yDiferenca);        
        props.setPosYReferenciaCima(levelScroll.getPosYReferenciaCima() + yDiferenca);        
        //Debug.Log("posYReferenciaBaixo " + posYReferenciaBaixo + " posYReferenciaCima " + posYReferenciaCima);
    }

    private void reposicionarLevelItemParaUltimaPosicao(LevelScroll levelsScroll)
    {
        //Vector2 posBaixo = props.ItemLevelBaixo.RItem.anchoredPosition;
        Vector2 posBaixo = props.ItemLevelBaixo.getAnchoredPosition();
        //float haltura = posBaixo.y - levelsScroll.ItensLevelDto[0].RItem.rect.height;
        float haltura = posBaixo.y - levelsScroll.getItemLevel(0).getHaltura();
        //props.ItemLevelCima.RItem.anchoredPosition = new Vector2(posBaixo.x, haltura);
        props.ItemLevelCima.setAnchoredPosition(new Vector2(posBaixo.x, haltura));
        //props.ItemLevelCima.RItem.gameObject.SetActive(true);
        props.ItemLevelCima.ligar();

        props.setItemLevelBaixo(props.ItemLevelCima);
        //int indiceItem = (int.Parse(props.ItemLevelCima.RItem.name) + 1) % levelsScrollDto.ItensLevelDto.Length;
        int indiceItem = (props.ItemLevelCima.getNomeItemNumerico() + 1) % levelsScroll.getQtdItens();
        //props.setItemLevelCima(levelsScrollDto.ItensLevelDto[indiceItem]);
        props.setItemLevelCima(levelScroll.getItemLevel(indiceItem));
    }

    private void reposicionarLevelItemParaPrimeiraPosicao(LevelScroll levelScroll)
    {
        //Vector2 posCima = props.ItemLevelCima.RItem.anchoredPosition;
        Vector2 posCima = props.ItemLevelCima.getAnchoredPosition();
        //float haltura = posCima.y + levelScroll.ItensLevelDto[0].RItem.rect.height;
        float haltura = posCima.y + levelScroll.getItemLevel(0).getHaltura();
        //props.ItemLevelBaixo.RItem.anchoredPosition = new Vector2(posCima.x, haltura);        
        props.ItemLevelBaixo.setAnchoredPosition(new Vector2(posCima.x, haltura));        

        props.setItemLevelCima(props.ItemLevelBaixo);
        //int indicePrateleira = ((int.Parse(props.ItemLevelBaixo.RItem.name) + levelsScrollDto.ItensLevelDto.Length) - 1) % levelsScrollDto.ItensLevelDto.Length;
        int indicePrateleira = ((props.ItemLevelCima.getNomeItemNumerico() + levelScroll.getQtdItens()) - 1) % levelScroll.getQtdItens();
        //props.setItemLevelBaixo(levelsScrollDto.ItensLevelDto[indicePrateleira]);
        props.setItemLevelBaixo(this.levelScroll.getItemLevel(indicePrateleira));
    }

    private void popularItensLevels()
    {        
        //for(int contadorItensLevels = 0; contadorItensLevels < levelsScrollDto.ItensLevelDto.Length; contadorItensLevels++)
        for(int contadorItensLevels = 0; contadorItensLevels < levelScroll.getQtdItens(); contadorItensLevels++)
        {
            //ItemLevelDto itemLevelDtoIt = levelsScrollDto.ItensLevelDto[contadorItensLevels];            
            ItemLevelScroll itemLevelIt = levelScroll.getItemLevel(contadorItensLevels);
            //itemLevelDtoIt.ImgMaquina.material = materialMaquinas[contadorItensLevels];
            itemLevelIt.setMaterial(materialMaquinas[contadorItensLevels]);
            //popularItemLevel(contadorItensLevels, itemLevelDtoIt, contadorItensLevels);
            popularItemLevel(contadorItensLevels, itemLevelIt, contadorItensLevels);
            props.incrementarContadorBaixo();
            //itemLevelDtoIt.Exclamacao.SetActive(false);
            itemLevelIt.desligarExclamacao();

            int indiceItemLevels = contadorItensLevels + 1;
            if (isTotalLevelsMenorQueScroll() && (indiceItemLevels > totalLevels))
            {
                //itemLevelDtoIt.RItem.gameObject.SetActive(false);
                itemLevelIt.desligar();
            }

            if (levelsLiberados.Contains(indiceItemLevels))
            {
                //itemLevelDtoIt.Exclamacao.SetActive(true);
                itemLevelIt.ligarExclamacao();
            }
        }
        //Debug.Log("Populado contadorcima " + contadorCimaLevel + " contadorbaixo " + contadorBaixoLevel);
    }

    private void bindarBtnsLinha(LevelsScrollDto levelsScrollDto)
    {
        //for (int contadorItensLevels = 0; contadorItensLevels < levelsScrollDto.ItensLevelDto.Length; contadorItensLevels++)
        for (int contadorItensLevels = 0; contadorItensLevels < levelsScrollDto.ItensLevelDto.Length; contadorItensLevels++)
        {
            ItemLevelDto itemLevelDtoIt = levelsScrollDto.ItensLevelDto[contadorItensLevels];
            itemLevelDtoIt.BtnLinha.onClick.AddListener(() => selecionado());
        }
    }

    //private void popularItemLevel(ItemLevelDto itemLevelDtoIt, int indiceAtual)
    //{
    //    popularItemLevel(int.Parse(itemLevelDtoIt.RItem.name), itemLevelDtoIt, indiceAtual);
    //}

    private void popularItemLevel(ItemLevelScroll itemLevel, int indiceAtual)
    {
        popularItemLevel(itemLevel.getNomeItemNumerico(), itemLevel, indiceAtual);
    }

    //private void popularItemLevel(int indiceMaterialMaquina, ItemLevelDto itemLevelDtoIt, int indiceAtual)
    //{
    //    MapaEntidade mapaEntidade = LevelHelper.getMapaNormalByIndicesTotasDeLevels(indiceAtual);
    //    AbstractLevel level = LevelHelper.getLevelNormalByIndicesTotaisDeLevels(indiceAtual);
    //    string levelName               = level.getLevelName();
    //    itemLevelDtoIt.LblLevel.text   = levelName;
    //    itemLevelDtoIt.LblMap.text     = mapaEntidade.title;
    //    itemLevelDtoIt.LblMaquina.text = level.getMaquinaNome();

    //    MaterialMiniMaquina.addCores(materialMaquinas[indiceMaterialMaquina], level.getDicionarioDeCores());
    //    //Debug.Log("level alias " + levelAlias + " level name " + levelName + " nome componente" + itemLevelDtoIt.LblLevel.transform.parent.name);
    //}

    private void popularItemLevel(int indiceMaterialMaquina, ItemLevelScroll itemLevel, int indiceAtual)
    {
        MapaEntidade mapaEntidade = LevelHelper.getMapaNormalByIndicesTotasDeLevels(indiceAtual);
        AbstractLevel level = LevelHelper.getLevelNormalByIndicesTotaisDeLevels(indiceAtual);
        string levelName = level.getLevelName();
        itemLevel.addLabels(levelName, mapaEntidade.title, level.getMaquinaNome());       

        MaterialMiniMaquina.addCores(materialMaquinas[indiceMaterialMaquina], level.getDicionarioDeCores());
        //Debug.Log("level alias " + levelAlias + " level name " + levelName + " nome componente" + itemLevelDtoIt.LblLevel.transform.parent.name);
    }

    private void selecionado()
    {
        Debug.Log("Selecionado chamado");
        GameObject goSelecionado = EventSystem.current.currentSelectedGameObject;
        int indiceItem = int.Parse(goSelecionado.transform.parent.name);
        //ItemLevelDto itemLevelDto = levelsScrollDto.ItensLevelDto[indiceItem];
        ItemLevelScroll itemLevel = levelScroll.getItemLevel(indiceItem);

        //Vector3 posicaoItem = itemLevelDto.ImgMaquina.transform.position;
        Vector3 posicaoItem = itemLevel.getPosicaoImgMaquina();
        Material materialCor = materialMaquinas[indiceItem];

        //itemLevelDto.ImgMaquina.gameObject.SetActive(false);
        itemLevel.desligarImgMaquina();

        //if(goImgMaquina != null)
        //{
        //    goImgMaquina.SetActive(true);
        //}
        //goImgMaquina = itemLevelDto.ImgMaquina.gameObject;

        levelScroll.ligarUltimaImgMaquina();
        levelScroll.atualizarItemAtual(indiceItem);

        LevelItemDto levelItem = new LevelItemDto(posicaoItem, materialCor);//Rename de classe
        produtorDeEvento.produziuEvento(levelItem);
    }

    private void carregarLevelsLiberados()
    {
        int[] levels = PlayerPrefsMapas.getNovaLiberacaoLevelEspecifico();
        levelsLiberados = new List<int>(levels);        
    }

    ProdutorDeEvento<LevelItemDto> AcaoLevelFromScrollSelecao.ProdutorEvento.getProdutorDeEvento()
    {
        return produtorDeEvento;
    }
}
