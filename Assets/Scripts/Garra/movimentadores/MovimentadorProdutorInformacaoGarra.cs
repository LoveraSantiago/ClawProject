public abstract class MovimentadorProdutorInformacaoGarra : MovimentacaoDaGarraNormal
{
    private static int contadorDeSubidas;
    public static ProdutorDeEvento<InformacoesDaGarraDto> produtorEventoInfoGarra { get; private set; }

    public static void configurar()
    {
        contadorDeSubidas = 0;
        produtorEventoInfoGarra = new ProdutorDeEvento<InformacoesDaGarraDto>();
    }

    protected void contabilizarSubida()
    {
        contadorDeSubidas++;
    }

    protected void produzirEventoInfoDaGarra(string nomeColidido)
    {
        produtorEventoInfoGarra.produziuEvento(new InformacoesDaGarraDto(contadorDeSubidas, nomeColidido));
    }
}
