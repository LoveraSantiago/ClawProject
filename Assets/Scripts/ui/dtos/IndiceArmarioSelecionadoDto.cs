public class IndiceArmarioSelecionadoDto 
{
    public int indicePrateleira { get; private set; }
    public int indiceItem { get; private set; }
    public float posScrollArmario { get; private set; }    

    public IndiceArmarioSelecionadoDto(int indicePrateleira, int indiceItem, float posScrollArmario)        
    {        
        this.indicePrateleira = indicePrateleira;
        this.indiceItem = indiceItem;
        this.posScrollArmario = posScrollArmario;
    }    
}
