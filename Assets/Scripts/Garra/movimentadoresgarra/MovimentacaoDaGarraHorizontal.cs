public class MovimentacaoDaGarraHorizontal : MovimentacaoDaGarra
{
    protected static ProdutorDeEvento<Direcao> produtorEventoDirecao = new ProdutorDeEvento<Direcao>();

    public ProdutorDeEvento<Direcao> getProdutorDeEventoDeDirecao()
    {
        return produtorEventoDirecao;
    }
}
