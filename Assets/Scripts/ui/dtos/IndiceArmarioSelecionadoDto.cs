public class IndiceArmarioSelecionadoDto 
{
    public int indicePrateleira { get; private set; }
    public int indiceItem { get; private set; }
    public float posScrollArmario { get; private set; }
    public ItemPrateleiraDto itemSelecionado { get; private set; }    
    
    public IndiceArmarioSelecionadoDto addIndices(int indicePrateleira, int indiceItem)
    {
        this.indicePrateleira = indicePrateleira;
        this.indiceItem = indiceItem;
        return this;
    }

    public IndiceArmarioSelecionadoDto addScrollPosition(float posScrollArmario)
    {
        this.posScrollArmario = posScrollArmario;
        return this;
    }

    public IndiceArmarioSelecionadoDto addItemSelecionado(ItemPrateleiraDto itemSelecionado)
    {
        this.itemSelecionado = itemSelecionado;
        return this;
    }
}
