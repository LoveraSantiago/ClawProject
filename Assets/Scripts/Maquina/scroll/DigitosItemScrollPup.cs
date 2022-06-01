using UnityEngine;

public class DigitosItemScrollPup 
{
    private Material7Digitos matDigito1;
    private Material7Digitos matDigito2;

    public DigitosItemScrollPup(ItemScrollDto itemScrollDto)
    {
        matDigito1 = new Material7Digitos(itemScrollDto.SprRendererDigito1);
        matDigito2 = new Material7Digitos(itemScrollDto.SprRendererDigito2);
    }

    public DigitosItemScrollPup(Material material, ItemScrollDto itemScrollDto)
    {
        matDigito1 = new Material7Digitos(material);
        matDigito2 = new Material7Digitos(material);

        itemScrollDto.SprRendererDigito1.sharedMaterial = matDigito1.material;
        itemScrollDto.SprRendererDigito2.sharedMaterial = matDigito2.material;
    }

    public void addQuantidade(int qtd)
    {
        int digito1 = qtd / 10;
        int digito2 = qtd % 10;

        matDigito1.addDigito(digito1);
        matDigito2.addDigito(digito2);
    }

    public void addCor(Color cor)
    {
        matDigito1.addCorDesligado(cor);
        matDigito2.addCorDesligado(cor);
    }
}
