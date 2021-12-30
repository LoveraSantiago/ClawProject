public class TrincaColetaveisTiles 
{
    private Coletavel[] arrayColetados;

    public TrincaColetaveisTiles(Coletavel[] arrayColetados)
    {
        this.arrayColetados = arrayColetados;
        //logarTrinca();
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

    public bool isColetavelNaTrinca(Coletavel coletavel)
    {
        for (int contador = 0; contador < arrayColetados.Length; contador++)
        {
            Coletavel coletavelIt = arrayColetados[contador];
            if (coletavelIt.nome.Equals(coletavel.nome))
            {
                return true;
            }
        }
        return false;
    }

    public bool isColetaveisNaTrinca(Coletavel[] coletaveis)
    {
        for(int contador = 0; contador < coletaveis.Length; contador++)
        {
            bool resultIt = isColetavelNaTrinca(coletaveis[contador]);
            if (!resultIt)
            {
                return false;
            }
        }
        return true;
    }

    public int getIndiceNaTrinca(Coletavel coletavel)
    {
        for (int contador = 0; contador < arrayColetados.Length; contador++)
        {
            Coletavel coletavelIt = arrayColetados[contador];
            if (coletavelIt.nome.Equals(coletavel.nome))
            {
                return contador;
            }
        }
        return -1;
    }

    public void trocarIndice(int indice, Coletavel coletavel)
    {
        arrayColetados[indice] = coletavel;
        //logarTrinca();
    }

    public Coletavel[] resetarColetados()
    {
        arrayColetados[0] = null;
        arrayColetados[1] = null;
        arrayColetados[2] = null;
        return arrayColetados;
    }

    //public void logarTrinca()
    //{
    //    string naLista = "";
    //    for (int contador = 0; contador < arrayColetados.Length; contador++)
    //    {
    //        ColetavelTile coletavelIt = arrayColetados[contador];
    //        naLista = naLista + coletavelIt.nome + " - ";
    //    }
    //    Debug.Log(naLista);
    //}
}
