using UnityEngine;

public abstract class MovimentacaoDaGarra 
{
    protected readonly float LIMITE_LATERAL_TELA = 2.25f;

    protected static PincaDaGarra pincas;
    protected static GarraDto garraDto;
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
        garraDto.RigidBody.velocity = Vector3.zero;
        garraDto.RigidBody.angularVelocity = 0;
    }

    protected void moverGarraParaCimaFDT()//FDT FixedDeltaTime
    {
        garraDto.RigidBody.velocity = new Vector2(0, garraDto.VelocMovCima * Time.fixedDeltaTime);
    }

    protected void moverGarraHorizontalmenteFDT(int direcao)
    {
        garraDto.RigidBody.velocity = new Vector2(direcao * garraDto.VelocMovHorizontal * Time.fixedDeltaTime,garraDto.RigidBody.velocity.y);
    }

    protected void colocarGarraNaAlturaInicial()
    {
        garraDto.RigidBody.transform.localPosition = new Vector2(garraDto.RigidBody.position.x, posInicial.y);
    }

    protected void colocarGarraNaPosInicial()
    {
        garraDto.RigidBody.transform.localPosition = posInicial;
    }

    protected bool isGarraAcimaPosInicial()
    {
        return garraDto.RigidBody.transform.localPosition.y >= posInicial.y;
    }

    protected bool isGarraMaiorPosHorizontal(float posHorizontal)
    {
        return garraDto.RigidBody.transform.localPosition.x > posHorizontal;
    }

    protected bool isGarraMenorPosHorizontal(float posHorizontal)
    {
        return garraDto.RigidBody.transform.localPosition.x < posHorizontal;
    }

    public static void configurarComponentesMovimentacaoGarra(
        GarraDto componentesDaGarraDtoArg, 
        ComunicadorComGerMovimentacao comunicadorComGerMovimentacaoArg,
        InputGame inputGameArg)
    {
        garraDto = componentesDaGarraDtoArg;
        pincas = new PincaDaGarra(garraDto.PincaEsquerda, garraDto.PincaDireita);
        comunicadorComGerMovimentacao = comunicadorComGerMovimentacaoArg;
        inputGame = inputGameArg;
    }
}
