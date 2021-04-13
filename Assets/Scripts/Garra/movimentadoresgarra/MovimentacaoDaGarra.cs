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

    protected void subirGarraFDT()//FDT FixedDeltaTime
    {
        compDaGarra.RigidBody.velocity = new Vector2(0, compDaGarra.VelocMovCima * Time.fixedDeltaTime);
    }

    protected void colocarGarraNaAlturaInicial()
    {
        compDaGarra.RigidBody.transform.localPosition = new Vector2(compDaGarra.RigidBody.position.x, posInicial.y);
    }

    protected bool isGarraAcimaPosInicial()
    {
        return compDaGarra.RigidBody.transform.localPosition.y > posInicial.y;
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
