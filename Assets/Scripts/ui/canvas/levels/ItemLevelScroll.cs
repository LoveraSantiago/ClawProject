using UnityEngine;
using System.Collections.Generic;

public class ItemLevelScroll 
{
    private static Sprite estrelaBranca;
    private static Sprite estrelaColorida;

    public int indiceLevel { get; private set; }
    public bool isExclamacaoLigado { get; private set; }
    public Material material { get; private set; }

    private ItemLevelDto itemLevelDto;

    public ItemLevelScroll(ItemLevelDto itemLevelDto)
    {
        this.itemLevelDto = itemLevelDto;
        material = MaterialMiniMaquina.getNewMaterial();
        setMaterial(material);
    }

    public string getNomeItem()
    {
        return itemLevelDto.RItem.name;
    }

    public int getNomeItemNumerico()
    {
        return int.Parse(getNomeItem());
    }

    public float getHaltura()
    {
        return itemLevelDto.RItem.rect.height;
    }

    public float getPosY()
    {
        return itemLevelDto.RItem.position.y;
    }

    public Vector3 getPosicaoImgMaquina()
    {
        return itemLevelDto.ImgMaquina.transform.position;
    }

    private void setMaterial(Material material)
    {
        itemLevelDto.ImgMaquina.material = material;
    }

    public void colorirImgMaquina(int numeroEstrelas, Dictionary<string, string> cores)
    {
        MaterialMiniMaquina.addCores(numeroEstrelas, material, cores);
        itemLevelDto.ImgEstrela1.sprite = numeroEstrelas >= 1 ? estrelaColorida : estrelaBranca;
        itemLevelDto.ImgEstrela2.sprite = numeroEstrelas >= 2 ? estrelaColorida : estrelaBranca;
        itemLevelDto.ImgEstrela3.sprite = numeroEstrelas >= 3 ? estrelaColorida : estrelaBranca;
    }

    public void desligar()
    {
        itemLevelDto.RItem.gameObject.SetActive(false);
    }

    public void ligar()
    {
        itemLevelDto.RItem.gameObject.SetActive(true);
    }

    public void desligarExclamacao()
    {
        isExclamacaoLigado = false;
        itemLevelDto.Exclamacao.SetActive(false);
    }

    public void ligarExclamacao()
    {
        itemLevelDto.Exclamacao.SetActive(true);
        isExclamacaoLigado = true;
    }

    public void desligarImgMaquina()
    {
        Debug.Log("Desgligar img maquina chamado");
        itemLevelDto.ImgMaquina.gameObject.SetActive(false);
    }

    public void ligarImgMaquina()
    {
        itemLevelDto.ImgMaquina.gameObject.SetActive(true);
    }

    public void addLabels(int indiceLevel, string nomeLevel, string titulo, string nomeMaquina)
    {
        this.indiceLevel = indiceLevel;
        itemLevelDto.LblLevel.text = nomeLevel;
        itemLevelDto.LblMap.text = titulo;
        itemLevelDto.LblMaquina.text = nomeMaquina;
    }

    public Vector2 getAnchoredPosition()
    {
        return itemLevelDto.RItem.anchoredPosition;
    }

    public void setAnchoredPosition(Vector2 posicao)
    {
        itemLevelDto.RItem.anchoredPosition = posicao;
    }

    public static void configurarSpritesEstrelas(Sprite estralaBrancaArg, Sprite estrelaColoridaArg)
    {
        estrelaBranca = estralaBrancaArg;
        estrelaColorida = estrelaColoridaArg;
    }
}
