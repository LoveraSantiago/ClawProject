using System.Collections.Generic;

public class ProdutorConsumidoresDeEvento<T> : Consumidor<T>
{    
    private Consumidor<T> consumidorAtual;
    private List<Consumidor<T>> listaDeConsumidoresDeEvento;

    public ProdutorConsumidoresDeEvento()
    {
        listaDeConsumidoresDeEvento = new List<Consumidor<T>>();
    }

    public ProdutorConsumidoresDeEvento<T> configurarProdutor(ProdutorDeEvento<T> produtor)
    {
        produtor.registrarConsumidorDeEvento(this);
        return this;
    }

    public ProdutorConsumidoresDeEvento<T> adicionarConsumidor(Consumidor<T> consumidorDeEvento)
    {
        listaDeConsumidoresDeEvento.Add(consumidorDeEvento);
        return this;
    }

    public void consumir(T evento)
    {
        for (int contador = 0; contador < listaDeConsumidoresDeEvento.Count; contador++)
        {
            consumidorAtual = listaDeConsumidoresDeEvento[contador];
            consumidorAtual.consumir(evento);
        }
    }
}
