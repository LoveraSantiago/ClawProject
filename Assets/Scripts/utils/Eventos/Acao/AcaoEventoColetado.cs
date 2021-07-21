public class AcaoEventoColetado : ProdutorConsumidoresDeEvento<InformacoesColetado>
{
    public ProdutorConsumidoresDeEvento<InformacoesColetado> configurarProdutor(ProdutorDeColetado produtor)
    {
        configurarProdutor(produtor.getProdutorDeEventoColetado());
        return this;
    }

    public ProdutorConsumidoresDeEvento<InformacoesColetado> adicionarConsumidor(ConsumidorDeColetado consumidor)
    {
        adicionarConsumidor(consumidor);
        return this;
    }

    public interface ProdutorDeColetado 
    {
        ProdutorDeEvento<InformacoesColetado> getProdutorDeEventoColetado();
    }

    public interface ConsumidorDeColetado : Consumidor<InformacoesColetado>
    {        
    }
}
