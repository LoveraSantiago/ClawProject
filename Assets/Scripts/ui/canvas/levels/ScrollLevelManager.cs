using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class ScrollLevelManager : ScrollMovimentador<LevelsScrollDto>,
                            AcaoLevelFromScrollSelecao.ProdutorEvento  
{
    private int totalLevels;
    private Material[] materialMaquinas;
    private List<int> levelsLiberados;

    private PropsCimaBaixoScrollManager props;   
    private LevelsScrollDto levelsScrollDto;

    private GameObject goImgMaquina;
    private ProdutorDeEvento<LevelItemDto> produtorDeEvento;

    public ScrollLevelManager(LevelsScrollDto levelsScrollDto)
    {
        totalLevels = PlayerPrefsMapas.getIndiceLevelLiberado();
        props = new PropsCimaBaixoScrollManager();

        this.levelsScrollDto = levelsScrollDto;
        produtorDeEvento = new ProdutorDeEvento<LevelItemDto>();

        carregarMateriais();
        calcularTamanhoScroll();
        carregarReferenciasPosicoes();
        carregarLevelsLiberados();
        popularItensLevels();
        bindarBtnsLinha();

        props.setItemLevelCima(levelsScrollDto.ItensLevelDto[0]);
        props.setItemLevelBaixo(levelsScrollDto.ItensLevelDto[levelsScrollDto.ItensLevelDto.Length - 1]);
    }
   
    public override void movimentarParaBaixo(LevelsScrollDto levelsScrollDto)
    {
        float posYItemLevel = props.ItemLevelBaixo.RItem.transform.position.y;
        if (props.ContadorBaixoLevel < totalLevels && posYItemLevel > props.PosYReferenciaBaixo)
        {
            popularItemLevel(props.ItemLevelCima, props.ContadorBaixoLevel);
            reposicionarLevelItemParaUltimaPosicao(levelsScrollDto);
            props.incrementarContadorBaixo();
            props.incrementarContadorCima();
            
            //Debug.Log("movimentarParaBaixo ACIONADO contadorcima " + contadorCimaLevel + " contadorbaixo " + contadorBaixoLevel);
        }
    }

    public override void movimentarParaCima(LevelsScrollDto levelsScrollDto)
    {
        float posYPrateleira = props.ItemLevelCima.RItem.transform.position.y;
        if(props.ContadorCimaLevel > 0 && posYPrateleira < props.PosYReferenciaCima)
        {
            props.decrementarContadorCima();
            popularItemLevel(props.ItemLevelBaixo, props.ContadorCimaLevel);
            reposicionarLevelItemParaPrimeiraPosicao(levelsScrollDto);
            props.decrementarContadorBaixo();
            //Debug.Log("movimentarParaCima ACIONADO contadorcima " + contadorCimaLevel + " contadorbaixo " + contadorBaixoLevel);
        }
    }

    private void carregarMateriais()
    {
        int qtdItens = levelsScrollDto.ItensLevelDto.Length;
        materialMaquinas = new Material[qtdItens];
        for(int contador = 0; contador < qtdItens; contador++)
        {
            materialMaquinas[contador] = MaterialMiniMaquina.getNewMaterial();
        }
    }

    private void calcularTamanhoScroll()
    {
        float qtdItens = totalLevels - levelsScrollDto.QtdItensVisiveis;
        float yAcrescimo = qtdItens * levelsScrollDto.ItensLevelDto[0].RItem.rect.height;
        levelsScrollDto.RTransformScroll.offsetMin += new Vector2(0, -yAcrescimo);
    }

    private bool isTotalLevelsMenorQueScroll()
    {
        Debug.Log("Total levels " + totalLevels + " Lenght " + levelsScrollDto.ItensLevelDto.Length);
        return totalLevels <= levelsScrollDto.ItensLevelDto.Length;
    }

    private void carregarReferenciasPosicoes()
    {
        props.setPosYReferenciaBaixo(levelsScrollDto.RTransformRefBaixo.position.y);        
        float yDiferenca = (levelsScrollDto.ItensLevelDto[0].RItem.position.y - levelsScrollDto.ItensLevelDto[1].RItem.position.y);
        props.setPosYReferenciaCima(levelsScrollDto.RTransformRefCima.position.y + yDiferenca);        
        //Debug.Log("posYReferenciaBaixo " + posYReferenciaBaixo + " posYReferenciaCima " + posYReferenciaCima);
    }

    private void reposicionarLevelItemParaUltimaPosicao(LevelsScrollDto levelsScrollDto)
    {
        Vector2 posBaixo = props.ItemLevelBaixo.RItem.anchoredPosition;
        float haltura = posBaixo.y - levelsScrollDto.ItensLevelDto[0].RItem.rect.height;
        props.ItemLevelCima.RItem.anchoredPosition = new Vector2(posBaixo.x, haltura);
        props.ItemLevelCima.RItem.gameObject.SetActive(true);

        props.setItemLevelBaixo(props.ItemLevelCima);
        int indiceItem = (int.Parse(props.ItemLevelCima.RItem.name) + 1) % levelsScrollDto.ItensLevelDto.Length;
        props.setItemLevelCima(levelsScrollDto.ItensLevelDto[indiceItem]);
    }

    private void reposicionarLevelItemParaPrimeiraPosicao(LevelsScrollDto levelsScrollDto)
    {
        Vector2 posCima = props.ItemLevelCima.RItem.anchoredPosition;
        float haltura = posCima.y + levelsScrollDto.ItensLevelDto[0].RItem.rect.height;
        props.ItemLevelBaixo.RItem.anchoredPosition = new Vector2(posCima.x, haltura);        

        props.setItemLevelCima(props.ItemLevelBaixo);
        int indicePrateleira = ((int.Parse(props.ItemLevelBaixo.RItem.name) + levelsScrollDto.ItensLevelDto.Length) - 1) % levelsScrollDto.ItensLevelDto.Length;
        props.setItemLevelBaixo(levelsScrollDto.ItensLevelDto[indicePrateleira]);
    }

    private void popularItensLevels()
    {        
        for(int contadorItensLevels = 0; contadorItensLevels < levelsScrollDto.ItensLevelDto.Length; contadorItensLevels++)
        {
            ItemLevelDto itemLevelDtoIt = levelsScrollDto.ItensLevelDto[contadorItensLevels];            
            itemLevelDtoIt.ImgMaquina.material = materialMaquinas[contadorItensLevels];
            popularItemLevel(contadorItensLevels, itemLevelDtoIt, contadorItensLevels);
            props.incrementarContadorBaixo();
            itemLevelDtoIt.Exclamacao.SetActive(false);

            int indiceItemLevels = contadorItensLevels + 1;
            if (isTotalLevelsMenorQueScroll() && (indiceItemLevels > totalLevels))
            {
                itemLevelDtoIt.RItem.gameObject.SetActive(false);
            }

            if (levelsLiberados.Contains(indiceItemLevels))
            {
                itemLevelDtoIt.Exclamacao.SetActive(true);
            }
        }
        //Debug.Log("Populado contadorcima " + contadorCimaLevel + " contadorbaixo " + contadorBaixoLevel);
    }

    private void bindarBtnsLinha()
    {
        for (int contadorItensLevels = 0; contadorItensLevels < levelsScrollDto.ItensLevelDto.Length; contadorItensLevels++)
        {
            ItemLevelDto itemLevelDtoIt = levelsScrollDto.ItensLevelDto[contadorItensLevels];
            itemLevelDtoIt.BtnLinha.onClick.AddListener(() => selecionado());
        }
    }

    private void popularItemLevel(ItemLevelDto itemLevelDtoIt, int indiceAtual)
    {
        popularItemLevel(int.Parse(itemLevelDtoIt.RItem.name), itemLevelDtoIt, indiceAtual);
    }

    private void popularItemLevel(int indiceMaterialMaquina, ItemLevelDto itemLevelDtoIt, int indiceAtual)
    {
        MapaEntidade mapaEntidade = LevelHelper.getMapaNormalByIndicesTotasDeLevels(indiceAtual);
        AbstractLevel level = LevelHelper.getLevelNormalByIndicesTotaisDeLevels(indiceAtual);
        string levelName               = level.getLevelName();
        itemLevelDtoIt.LblLevel.text   = levelName;
        itemLevelDtoIt.LblMap.text     = mapaEntidade.title;
        itemLevelDtoIt.LblMaquina.text = level.getMaquinaNome();

        MaterialMiniMaquina.addCores(materialMaquinas[indiceMaterialMaquina], level.getDicionarioDeCores());
        //Debug.Log("level alias " + levelAlias + " level name " + levelName + " nome componente" + itemLevelDtoIt.LblLevel.transform.parent.name);
    }

    private void selecionado()
    {
        //Debug.Log("Selecionado chamado");
        GameObject goSelecionado = EventSystem.current.currentSelectedGameObject;
        int indiceItem = int.Parse(goSelecionado.transform.parent.name);
        ItemLevelDto itemLevelDto = levelsScrollDto.ItensLevelDto[indiceItem];

        Vector3 posicaoItem = itemLevelDto.ImgMaquina.transform.position;
        Material materialCor = materialMaquinas[indiceItem];

        itemLevelDto.ImgMaquina.gameObject.SetActive(false);

        if(goImgMaquina != null)
        {
            goImgMaquina.SetActive(true);
        }
        goImgMaquina = itemLevelDto.ImgMaquina.gameObject;

        LevelItemDto levelItem = new LevelItemDto(posicaoItem, materialCor);
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
