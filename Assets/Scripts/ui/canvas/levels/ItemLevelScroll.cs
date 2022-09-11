using UnityEngine;

public class ItemLevelScroll 
{
    private ItemLevelDto itemLevelDto;

    public ItemLevelScroll(ItemLevelDto itemLevelDto)
    {
        this.itemLevelDto = itemLevelDto;
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

    public void setMaterial(Material material)
    {
        itemLevelDto.ImgMaquina.material = material;
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
        itemLevelDto.Exclamacao.SetActive(false);
    }

    public void ligarExclamacao()
    {
        itemLevelDto.Exclamacao.SetActive(true);
    }

    public void desligarImgMaquina()
    {
        Debug.Log("Desgligar img maquina chamado");
        //itemLevelDto.ImgMaquina.gameObject.SetActive(false);
    }

    public void ligarImgMaquina()
    {
        itemLevelDto.ImgMaquina.gameObject.SetActive(true);
    }

    public void addLabels(string nomeLevel, string titulo, string nomeMaquina)
    {
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
}
