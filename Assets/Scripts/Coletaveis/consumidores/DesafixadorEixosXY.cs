public class DesafixadorEixosXY : Consumidor<ColetavelTile>
{
    public void consumir(ColetavelTile coletavel)
    {
        if (coletavel.isAtivo())
        {
            coletavel.desafixarVerticalmente();
            coletavel.colocarNoLayerNormal();
        }
    }
}
