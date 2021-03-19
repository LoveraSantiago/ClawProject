public abstract class MovimentacaoDaGarra 
{
    protected static ComponentesDaGarraDto compDaGarra;

    public virtual void update() { }
    public virtual void fixedUpdate() { }

    public static void configurarComponentesDaGarraDto(ComponentesDaGarraDto componentesDaGarraDtoArg)
    {
        compDaGarra = componentesDaGarraDtoArg;
    }
}
