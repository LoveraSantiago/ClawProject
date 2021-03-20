using UnityEngine;

public abstract class MovimentacaoDaGarra 
{
    protected static ComponentesDaGarraDto compDaGarra;
    protected static CommunicatorComGarra communicatorComGarra;

    public virtual void preInicio() { }
    public virtual void update() { }
    public virtual void fixedUpdate() { }

    public virtual void garraColidiuCom(GameObject gameObject) { }

    public static void configurarComponentesDaGarraDto(ComponentesDaGarraDto componentesDaGarraDtoArg)
    {
        compDaGarra = componentesDaGarraDtoArg;
    }

    public static void configurarCommunicatorComGarra(CommunicatorComGarra communicatorComGarraArg)
    {
        communicatorComGarra = communicatorComGarraArg;
    }
}
