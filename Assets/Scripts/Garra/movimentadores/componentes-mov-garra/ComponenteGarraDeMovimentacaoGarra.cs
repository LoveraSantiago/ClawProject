public abstract class ComponenteGarraDeMovimentacaoGarra : AcaoSincroniaComDirecaoDaGarra.ProdutorEvento
{
    private static Garra garra;
    private static AngulosPropriedades angulosProps;

    public static void configurarComponenteGarra(GarraDto garraDto, SomGarra somGarra)
    {
        garra = new Garra(garraDto, somGarra);
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

    ProdutorDeEvento<Direcao> AcaoSincroniaComDirecaoDaGarra.ProdutorEvento.getProdutorDeEvento()
    {
        return ((AcaoSincroniaComDirecaoDaGarra.ProdutorEvento)garra).getProdutorDeEvento();
    }
}
