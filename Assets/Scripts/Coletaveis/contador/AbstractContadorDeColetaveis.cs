public abstract class AbstractContadorDeColetaveis 
{
    public abstract void iniciar(int totalColetaveis);

    public virtual void configuradoPeloLevel(AbstractLevel level) {}

    public abstract int contarColetado(ColetavelTile coletavelTile);

    public abstract bool getResultCombinacao();

    public virtual int getIndiceOrdem()
    {
        return 0;
    }

    public abstract bool isFinished();

    public virtual bool isErroOrdem()
    {
        return false;
    }    
}
