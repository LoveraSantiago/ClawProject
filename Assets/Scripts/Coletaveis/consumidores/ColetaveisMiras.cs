public class ColetaveisMiras
{
    public ColetaveisMiras()
    {
    }

    public void ligar()
    {        
        ColetavelQuery.poolDeColetaveis.executeEmTodosColetaveis(new LigadorDeMiras());
    }

    public void desligar()
    {        
        ColetavelQuery.poolDeColetaveis.executeEmTodosColetaveis(new DesligadorDeMiras());
    }   
}