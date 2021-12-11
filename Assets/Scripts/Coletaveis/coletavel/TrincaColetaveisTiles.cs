public class TrincaColetaveisTiles 
{
    private ColetavelTile[] arrayColetados;

    public TrincaColetaveisTiles(ColetavelTile[] arrayColetados)
    {
        this.arrayColetados = arrayColetados;
    }

    public bool isCombinacaoValida()
    {
        return arrayColetados[0].hasEqualsSprite(arrayColetados[1]) &&
               arrayColetados[0].hasEqualsSprite(arrayColetados[2]);
    }

    public int getPrimeiroIndiceVazio()
    {
        if (arrayColetados[0] == null) return 0;
        if (arrayColetados[1] == null) return 1;
        return 2;
    }

    public bool isTodasPosicoesOcupadas()
    {
        return arrayColetados[0] != null && arrayColetados[1] != null && arrayColetados[2] != null;
    }

    public bool isColetavelNaTrinca(ColetavelTile coletavelTile)
    {
        for (int contador = 0; contador < arrayColetados.Length; contador++)
        {
            ColetavelTile coletavelIt = arrayColetados[contador];
            if (coletavelIt.nome.Equals(coletavelTile.nome))
            {
                return true;
            }
        }
        return false;
    }

    public ColetavelTile[] resetarColetados()
    {
        arrayColetados[0] = null;
        arrayColetados[1] = null;
        arrayColetados[2] = null;
        return arrayColetados;
    }
}
