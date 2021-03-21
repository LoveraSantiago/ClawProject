using UnityEngine;

public abstract class MovimentacaoDaGarra 
{
    protected static ComponentesDaGarraDto compDaGarra;
    protected static CommunicatorComGarra communicatorComGarra;

    private static GameObject objetoAtraido;
    private static int layerAnterior;

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

    protected void ligarAtracaoNoObjeto(GameObject gameObject)
    {
        layerAnterior = gameObject.layer;
        gameObject.layer = LayerMask.NameToLayer("Atracao");
        objetoAtraido = gameObject;
    }

    protected void desligarAtracaoNoObjeto()
    {
        if(objetoAtraido != null)
        {
            objetoAtraido.layer = layerAnterior;
        }
    }

    protected void diminuirInerciaDaGarra()
    {
        compDaGarra.RigidBody.velocity = Vector3.zero;
        compDaGarra.RigidBody.angularVelocity = 0;
    }
}
