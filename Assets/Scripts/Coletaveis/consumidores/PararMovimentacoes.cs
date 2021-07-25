public class PararMovimentacoes : Consumidor<ColetavelTile>
{
    public void consumir(ColetavelTile coletavel)
    {
        if (coletavel.isAtivo())
        {
            coletavel.fixarEixoXY();            
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
        }
    }
}
