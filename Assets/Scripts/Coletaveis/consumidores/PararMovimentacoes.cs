public class PararMovimentacoes : Consumidor<ColetavelTile>
{
    public void consumir(ColetavelTile coletavel)
    {
        if (coletavel.isAtivo())
        {
            coletavel.fixarEixoXY();
            coletavel.parar();
        }
    }
}

public class PararMovimentacoes2 : Consumidor<ColetavelTile>
{
    public void consumir(ColetavelTile coletavel)
    {
        if (coletavel.isAtivo())
        {
            coletavel.desafixarVerticalmente();
            coletavel.parar();
        }
    }
}
