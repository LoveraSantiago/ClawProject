public class ProdutorDeEvento<T>
{
    private int contador;
    private ConsumidorDeEvento<T> consumidorDeEvento;

    public void produziuEvento(T evento)
    {
        consumidorDeEvento.consumirEvento(evento);
    }

    public void registrarConsumidorDeEvento(ConsumidorDeEvento<T> consumidorDeEvento)
    {
        this.consumidorDeEvento = consumidorDeEvento;
    }
}
