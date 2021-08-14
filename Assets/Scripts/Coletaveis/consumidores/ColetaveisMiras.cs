public class ColetaveisMiras
{
    public ColetaveisMiras()
    {
    }

    public void ligar()
    {
        ColetavelQuery coletavelQuery = new ColetavelQuery();
        coletavelQuery.executeNoPoolDeColetaveis(new LigadorDeMiras());
    }

    public void desligar()
    {
        ColetavelQuery coletavelQuery = new ColetavelQuery();
        coletavelQuery.executeNoPoolDeColetaveis(new DesligadorDeMiras());
    }   
}