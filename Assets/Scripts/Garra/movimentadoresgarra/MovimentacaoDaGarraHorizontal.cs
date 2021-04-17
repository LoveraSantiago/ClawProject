public class MovimentacaoDaGarraHorizontal : MovimentacaoDaGarra
{
    public static ProdutorDeEvento<DirecaoDaGarra> produtorEventoDirecao { get; private set; }

    static MovimentacaoDaGarraHorizontal()
    {
        produtorEventoDirecao = new ProdutorDeEvento<DirecaoDaGarra>();
    }

    protected void dispararEventoDirecao(int direcao)
    {
        if (direcao == 1)
        {
            produtorEventoDirecao.produziuEvento(DirecaoDaGarra.DIREITA);
        }
        else
        {
            produtorEventoDirecao.produziuEvento(DirecaoDaGarra.ESQUERDA);
        }
    }
}
