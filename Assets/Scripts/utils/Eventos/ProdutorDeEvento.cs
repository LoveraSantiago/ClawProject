public class ProdutorDeEvento<T>
{
    private int contador;
    private Consumidor<T> consumidorDeEvento;

    public void produziuEvento(T evento)
    {
        consumidorDeEvento.consumir(evento);
    }

    public void registrarConsumidorDeEvento(Consumidor<T> consumidorDeEvento)
    {
        this.consumidorDeEvento = consumidorDeEvento;
    }
}
