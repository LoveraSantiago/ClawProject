using UnityEngine;

public class ItemScrollPup 
{
    public int indice { get; private set; }
    public ItemScrollDto itemScrollDto { get; private set; }

    public void addItemInfo(int indice, ItemScrollDto itemScrollDto)
    {
        this.indice = indice;
        this.itemScrollDto = itemScrollDto;
    }

    public void updateItemInfo(float posX, Sprite spritePup, int qtdPup)
    {
        Vector3 posDivisoria = getPosicaoDivisoria();
        Vector3 novaPos = new Vector3(posX, posDivisoria.y, posDivisoria.z);
        itemScrollDto.SprRendererDivisoria.transform.position = novaPos;
        itemScrollDto.SprRendererImgPup.sprite = spritePup;

        int digito1 = qtdPup / 10;
        int digito2 = qtdPup % 10;

        Material7Digitos matDigito1 = new Material7Digitos(itemScrollDto.SprRendererDigito1);
        matDigito1.addDigito(digito1);

        Material7Digitos matDigito2 = new Material7Digitos(itemScrollDto.SprRendererDigito2);
        matDigito2.addDigito(digito2);
    }

    public float getPosEsquerda()
    {   
        return getBoundsDivisoria().min.x;
    }

    public float getPosDireita()
    {
        return getBoundsDivisoria().max.x;
    }

    public float getPosicaoDeslocadaAEsquerda()
    {
        return getPosicaoDivisoria().x - 1;
    }

    public float getPosicaoDeslocadaADireita()
    {
        return getPosicaoDivisoria().x + 1;
    }

    private Vector3 getPosicaoDivisoria()
    {
        return itemScrollDto.SprRendererDivisoria.transform.position;
    } 

    private Bounds getBoundsDivisoria()
    {
        return itemScrollDto.SprRendererDivisoria.bounds;
    }
}
