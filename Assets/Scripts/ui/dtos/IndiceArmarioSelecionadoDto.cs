public class IndiceArmarioSelecionadoDto 
{
    public int indicePrateleira { get; private set; }
    public int indiceItem { get; private set; }
    public float posScrollArmario { get; private set; }

    public IndiceArmarioSelecionadoDto(int indicePrateleira, int indiceItem)
    {
        this.indicePrateleira = indicePrateleira;
        this.indiceItem = indiceItem;
        posScrollArmario = 0;
    }

    public IndiceArmarioSelecionadoDto(int indicePrateleira, int indiceItem, float posScrollArmario)
        :this(indicePrateleira, indiceItem)
    {        
        this.posScrollArmario = posScrollArmario;
    }

    public IndiceArmarioSelecionadoDto(IndiceArmarioSelecionadoDto indiceDto, float posScrollArmario)
        : this(indiceDto.indicePrateleira, indiceDto.indiceItem, posScrollArmario){}
}
