using System;

public class ProdutorConsumidoresDeEvento<T> 
{
    private Action<T> consumers;

    public ProdutorConsumidoresDeEvento<T> configurarProdutor(ProdutorDeEvento<T> produtor)
    {
        produtor.registrarConsumidorDeEvento(evento => produziuEvento(evento));
        return this;
    }

    public ProdutorConsumidoresDeEvento<T> adicionarConsumidorDeEvento(Action<T> actionConsumidora)
    {
        consumers += actionConsumidora;
        return this;
    }

    public ProdutorConsumidoresDeEvento<T> adicionarConsumidorDeEvento(Action<T>[] arrayDeActionsConsumidores)
    {
        for (int contador = 0; contador < arrayDeActionsConsumidores.Length; contador++)
        {
            adicionarConsumidorDeEvento(arrayDeActionsConsumidores[contador]);
        }
        return this;
    }

    private void produziuEvento(T evento)
    {
        consumers.Invoke(evento);
    }
}
