public class MovimentacaoDaGarraHorizontal : MovimentacaoDaGarra
{
    public static ProdutorDeEvento<DirecaoDaGarra> produtorEventoDirecao { get; private set; }

    static MovimentacaoDaGarraHorizontal()
    {
        produtorEventoDirecao = new ProdutorDeEvento<DirecaoDaGarra>();
    }    
}
