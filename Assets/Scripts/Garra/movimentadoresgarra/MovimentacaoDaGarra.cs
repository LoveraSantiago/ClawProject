public abstract class MovimentacaoDaGarra 
{
    protected static ComponentesDaGarraDto componentesDaGarraDto;

    public virtual void update() { }
    public virtual void fixedUpdate() { }

    public static void configurarComponentesDaGarraDto(ComponentesDaGarraDto componentesDaGarraDtoArg)
    {
        componentesDaGarraDto = componentesDaGarraDtoArg;
    }
}
