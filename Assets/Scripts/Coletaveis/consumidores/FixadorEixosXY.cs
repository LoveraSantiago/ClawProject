public class FixadorEixosXY : Consumidor<Coletavel>
{
    public void consumir(Coletavel coletavel)
    {
        if (coletavel.isAtivo())
        {
            coletavel.fixarEixoXY();            
        }
    }
}