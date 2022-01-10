public abstract class ComponenteGarraDeMovimentacaoGarra : AcaoSincroniaComDirecaoDaGarra.ProdutorEvento
{
    private static Garra garra;

    public static void configurarGarraDto(GarraDto garraDto)
    {
        garra = new Garra(garraDto);        
    }

    public Garra getGarra()
    {
        return garra;
    }

    ProdutorDeEvento<DirecaoDaGarra> AcaoSincroniaComDirecaoDaGarra.ProdutorEvento.getProdutorDeEvento()
    {
        return ((AcaoSincroniaComDirecaoDaGarra.ProdutorEvento)garra).getProdutorDeEvento();
    }
}
