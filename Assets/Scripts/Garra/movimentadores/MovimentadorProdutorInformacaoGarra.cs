public abstract class MovimentadorProdutorInformacaoGarra : MovimentacaoDaGarraNormal
{
    public static ProdutorDeEvento<InformacoesDaGarraDto> produtorEventoInfoGarra { get; private set; }

    public static void configurar()
    {
        produtorEventoInfoGarra = new ProdutorDeEvento<InformacoesDaGarraDto>();
    }
}
