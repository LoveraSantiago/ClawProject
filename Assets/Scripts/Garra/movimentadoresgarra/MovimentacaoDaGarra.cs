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

    protected void pararGarra()
    {
        garraDto.RigidBody.velocity = Vector3.zero;
        garraDto.RigidBody.angularVelocity = 0;
    }

    private void moverGarraParaCima()
    {
        garraDto.RigidBody.velocity = new Vector2(0, garraDto.VelocMovCima);        
    }

    private void moverGarraParaBaixo()
    {
        garraDto.RigidBody.velocity = new Vector2(0, garraDto.VelocMovBaixo);                                        
    }

    private void moverGarraHorizontalmente(float direcao)
    {
        garraDto.RigidBody.velocity = new Vector2(direcao * garraDto.VelocMovHorizontal, 0);                
    }

    protected void moverGarraParaCimaFreeze()
    {
        fixarGarraVerticalmente();
        moverGarraParaCima();
    }

    protected void moverGarraParaBaixoFreeze()
    {
        fixarGarraVerticalmente();
        moverGarraParaBaixo();
    }

    protected void moverGarraHorizontalmenteFreeze(float direcao)
    {
        fixarGarraHorizontalmente();
        moverGarraHorizontalmente(direcao);
    }

    protected void colocarGarraNaAlturaInicial()
    {
        garraDto.RigidBody.transform.localPosition = new Vector2(garraDto.RigidBody.position.x, posInicial.y);
    }

    protected void colocarGarraNaPosInicial()
    {
        garraDto.RigidBody.transform.localPosition = posInicial;
    }

    protected void colocarMassaNaGarra(int massa)
    {
        garraDto.RigidBody.mass = massa;
    }

    private void fixarGarraHorizontalmente()
    {
        garraDto.RigidBody.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
    }

    private void fixarGarraVerticalmente()
    {
        garraDto.RigidBody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
    }

    protected void desafixarGarraHorizontalmente()
    {
        garraDto.RigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
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
