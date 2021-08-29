using System.Collections.Generic;

public class ProdutorConsumidoresDeEvento<T> : Consumidor<T>
{    
    private ConsumidorEvento consumidorAtual;
    private List<ConsumidorEvento> listaDeConsumidoresDeEvento;

    public ProdutorConsumidoresDeEvento()
    {
        listaDeConsumidoresDeEvento = new List<ConsumidorEvento>();
    }

    public ProdutorConsumidoresDeEvento<T> configurarProdutor(ProdutorEvento produtor)
    {
        produtor.getProdutorDeEvento()
                .registrarConsumidorDeEvento(this);
        
        return this;
    }

    public ProdutorConsumidoresDeEvento<T> adicionarConsumidor(ConsumidorEvento consumidor)
    {
        listaDeConsumidoresDeEvento.Add(consumidor);
        return this;
    }   

    public void consumir(T evento)
    {
        for (int contador = 0; contador < listaDeConsumidoresDeEvento.Count; contador++)
        {
            consumidorAtual = listaDeConsumidoresDeEvento[contador];
            consumidorAtual.consumirEvento(evento);
        }
    }

    public interface ProdutorEvento
    {
        ProdutorDeEvento<T> getProdutorDeEvento();
    }

    public interface ConsumidorEvento
    {
        void consumirEvento(T evento);
    }
}
