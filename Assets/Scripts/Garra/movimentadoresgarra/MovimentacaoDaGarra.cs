using UnityEngine;

public abstract class MovimentacaoDaGarra 
{
    protected readonly float LIMITE_LATERAL_TELA = 2.25f;

    protected static ComponentesDaGarraDto compDaGarra;
    protected static ComunicadorComGerMovimentacao comunicadorComGerMovimentacao;
    protected static PincaDaGarra pincas;

    private static GameObject objetoAtraido;
    private static int layerAnterior;

    public virtual void preInicio() { }
    public virtual void update() { }
    public virtual void fixedUpdate() { }

    public virtual void garraColidiuCom(GameObject gameObject) { }

    public static void configurarComponentesDaGarraDto(ComponentesDaGarraDto componentesDaGarraDtoArg)
    {
        compDaGarra = componentesDaGarraDtoArg;
        pincas = new PincaDaGarra(compDaGarra.PincaEsquerda, compDaGarra.PincaDireita);
    }

    public static void configurarCommunicatorComGarra(ComunicadorComGerMovimentacao comunicadorComGerMovimentacaoArg)
    {
        comunicadorComGerMovimentacao = comunicadorComGerMovimentacaoArg;
    }

    protected void diminuirInerciaDaGarra()
    {
        compDaGarra.RigidBody.velocity = Vector3.zero;
        compDaGarra.RigidBody.angularVelocity = 0;
    }
}
