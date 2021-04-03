using System.Collections.Generic;
//TODO ELIMINAR SEM USO ATE O MOMENTO
//public class ProdutorConsumidoresDeEvento<T> : ConsumidorDeEvento<T>
//{
//    private int contador;
//    private ConsumidorDeEvento<T> consumidorAtual;
//    private List<ConsumidorDeEvento<T>> listaDeConsumidoresDeEvento;

//    public ProdutorConsumidoresDeEvento()
//    {
//        listaDeConsumidoresDeEvento = new List<ConsumidorDeEvento<T>>();
//    }

//    public ProdutorConsumidoresDeEvento<T> configurarProdutor(ProdutorDeEvento<T> produtor)
//    {
//        produtor.registrarConsumidorDeEvento(this);
//        return this;
//    }

//    public ProdutorConsumidoresDeEvento<T> adicionarConsumidor(ConsumidorDeEvento<T> consumidorDeEvento)
//    {
//        listaDeConsumidoresDeEvento.Add(consumidorDeEvento);
//        return this;
//    }       

//    public void consumirEvento(T evento)
//    {
//        for(contador = 0; contador < listaDeConsumidoresDeEvento.Count; contador++)
//        {
//            consumidorAtual = listaDeConsumidoresDeEvento[contador];
//            consumidorAtual.consumirEvento(evento);
//        }
//    }
//}
