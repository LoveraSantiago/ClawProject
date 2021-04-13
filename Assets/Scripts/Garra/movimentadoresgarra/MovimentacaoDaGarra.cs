using UnityEngine;

public abstract class MovimentacaoDaGarra 
{
    protected readonly float LIMITE_LATERAL_TELA = 2.25f;

    protected static PincaDaGarra pincas;
    protected static ComponentesDaGarraDto compDaGarra;
    protected static InputGame inputGame;
    protected static ComunicadorComGerMovimentacao comunicadorComGerMovimentacao;

    protected static Vector2 posInicial;

    private static GameObject objetoAtraido;
    private static int layerAnterior;

    public virtual void preInicio() { }
    public virtual void update() { }
    public virtual void fixedUpdate() { }

    public virtual void garraColidiuCom(GameObject gameObject) { }

    protected void diminuirInerciaDaGarra()
    {
        compDaGarra.RigidBody.velocity = Vector3.zero;
        compDaGarra.RigidBody.angularVelocity = 0;
    }

    public static void configurarComponentesMovimentacaoGarra(
        ComponentesDaGarraDto componentesDaGarraDtoArg, 
        ComunicadorComGerMovimentacao comunicadorComGerMovimentacaoArg,
        InputGame inputGameArg)
    {
        compDaGarra = componentesDaGarraDtoArg;
        pincas = new PincaDaGarra(compDaGarra.PincaEsquerda, compDaGarra.PincaDireita);
        comunicadorComGerMovimentacao = comunicadorComGerMovimentacaoArg;
        inputGame = inputGameArg;
    }
}
