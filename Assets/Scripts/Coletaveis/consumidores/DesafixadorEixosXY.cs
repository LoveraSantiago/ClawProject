public class DesafixadorEixosXY : Consumidor<Coletavel>
{
    public void consumir(Coletavel coletavel)
    {
        if (coletavel.isAtivo())
        {
            coletavel.desafixarVerticalmente();
            coletavel.colocarNoLayerNormal();
        }
    }
}
