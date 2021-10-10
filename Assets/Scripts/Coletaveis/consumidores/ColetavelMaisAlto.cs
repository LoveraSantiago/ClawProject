public class ColetavelMaisAlto : Consumidor<ColetavelTile>
{
    public ColetavelTile coletavelMaisAlto { get; private set; }

    public void consumir(ColetavelTile coletavelIt)
    {
        if (coletavelIt.isAtivo())
        {
            float alturaIt = coletavelIt.getPosicao().y;
            float alturaMaisAlta = coletavelMaisAlto.getPosicao().y;

            if(alturaIt > alturaMaisAlta)
            {
                coletavelMaisAlto = coletavelIt;
            }
        }        
    }    
}
