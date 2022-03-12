public class ContadorDeColetaveisInGame : Consumidor<Coletavel>
{
    public int qtd { get; private set; }

    public void consumir(Coletavel coletavel)
    {
        if(coletavel.isAtivo() && coletavel.isLayerNormal())
        {
            qtd++;
        }
    }    
}
