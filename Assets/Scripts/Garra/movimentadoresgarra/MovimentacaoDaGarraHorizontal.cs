public class MovimentacaoDaGarraHorizontal : MovimentacaoDaGarra
{
    protected static ProdutorDeEvento<DirecaoDaGarra> produtorEventoDirecao = new ProdutorDeEvento<DirecaoDaGarra>();

    public ProdutorDeEvento<DirecaoDaGarra> getProdutorDeEventoDeDirecao()
    {
        return produtorEventoDirecao;
    }
}
