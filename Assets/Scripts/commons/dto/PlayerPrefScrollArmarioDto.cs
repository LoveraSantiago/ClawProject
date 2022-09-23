public class PlayerPrefScrollArmarioDto 
{
    public float posicaoScroll { get; private set; }
    public int indicePrateleira { get; private set; }
    public int indiceItem { get; private set; }

    public PlayerPrefScrollArmarioDto(float posicao, int indicePrateleira, int indiceItem)
    {
        this.posicaoScroll = posicao;
        this.indicePrateleira = indicePrateleira;
        this.indiceItem = indiceItem;
    }
}
