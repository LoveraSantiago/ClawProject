public abstract class ComponenteGarraDeMovimentacaoGarra : AcaoSincroniaComDirecaoDaGarra.ProdutorEvento
{
    private static Garra garra;
    private static AngulosPropriedades angulosProps;

    public static void configurarComponenteGarra(GarraDto garraDto)
    {
        garra = new Garra(garraDto);
        angulosProps = new AngulosPropriedades(garraDto.Angulos);
    }

    public Garra getGarra()
    {
        return garra;
    }

    public AngulosPropriedades getAngulosProps()
    {
        return angulosProps;
    }

    ProdutorDeEvento<DirecaoDaGarra> AcaoSincroniaComDirecaoDaGarra.ProdutorEvento.getProdutorDeEvento()
    {
        return ((AcaoSincroniaComDirecaoDaGarra.ProdutorEvento)garra).getProdutorDeEvento();
    }
}
