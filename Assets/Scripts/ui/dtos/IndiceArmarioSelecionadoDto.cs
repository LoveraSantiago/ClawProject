public class IndiceArmarioSelecionadoDto 
{
    public int indicePrateleira { get; private set; }
    public int indiceItem { get; private set; }

    public IndiceArmarioSelecionadoDto(int indicePrateleira, int indiceItem)
    {
        this.indicePrateleira = indicePrateleira;
        this.indiceItem = indiceItem;
    }
}
