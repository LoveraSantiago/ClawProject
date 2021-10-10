public class ProcuradorColetavelMaisAlto : Consumidor<ColetavelTile>
{
    public ColetavelTile coletavelMaisAlto { get; private set; }

    public void consumir(ColetavelTile coletavelIt)
    {
        if (coletavelIt.isAtivo())
        {
            float alturaIt = coletavelIt.getPosicao().y;
            float alturaMaisAlta = getHalturaAtual();

            if(alturaIt > alturaMaisAlta)
            {
                coletavelMaisAlto = coletavelIt;
            }
        }        
    }    

    private float getHalturaAtual()
    {
        if(coletavelMaisAlto != null)
        {
            return coletavelMaisAlto.getPosicao().y;
        }
        return -1;
    }
}
