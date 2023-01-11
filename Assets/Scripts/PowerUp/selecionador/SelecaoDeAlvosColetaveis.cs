public abstract class SelecaoDeAlvosColetaveis<T> : SelecaoDeAlvos<T>,
                                                    Transformador<InputGame, Coletavel>
{
    protected bool filtrarGaiolas;

    protected SelecaoDeAlvosColetaveis(bool filtrarGaiolas)
    {
        this.filtrarGaiolas = filtrarGaiolas;
    }

    public Coletavel transformar(InputGame entrada)
    {
        Coletavel coletavel = ColetavelInputHit.hit(entrada);
        if (!filtrarGaiolas)
        {
            return coletavel;
        }
        else if(coletavel.isLivre())
        {
            return coletavel;
        }
        else
        {
            return null;
        }
    }
}
