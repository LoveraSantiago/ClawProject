using UnityEngine;
//TODO quebrar a classe em responsabilidades menores
public abstract class MovimentacaoDaGarra 
{
    protected readonly float LIMITE_LATERAL_TELA = 2.25f;

    protected static PincaDaGarra pincas;
    protected static GarraDto garraDto;
    protected static InputGame inputGame;
    protected static AnimacaoGarra animacao;

    protected static Vector2 posInicial;

    public static ProdutorDeEvento<DirecaoDaGarra> produtorEventoDirecao { get; private set; }
    public static ProdutorDeEvento<string> produtorEventoGarraAcertou { get; private set; }
    public static ProdutorDeEvento<int> produtorDeEventoSubidaDaGarra { get; private set; }

    public virtual void preInicio() { }
    public virtual void update() { }
    public virtual void fixedUpdate() { }

    public virtual void garraColidiuCom(GameObject gameObject) { }

    protected void parar()
    {
        garraDto.RigidBody.velocity = Vector3.zero;
        garraDto.RigidBody.angularVelocity = 0;
    }

    private void moverParaCima()
    {
        garraDto.RigidBody.velocity = new Vector2(0, garraDto.VelocMovCima);        
    }

    private void moverParaBaixo()
    {
        garraDto.RigidBody.velocity = new Vector2(0, garraDto.VelocMovBaixo);                                        
    }

    private void moverHorizontalmente(float direcao)
    {
        garraDto.RigidBody.velocity = new Vector2(direcao * garraDto.VelocMovHorizontal, 0);        
    }

    protected void moverParaCimaFreeze()
    {
        fixarVerticalmente();
        moverParaCima();
    }

    protected void moverParaBaixoFreeze()
    {
        fixarVerticalmente();
        moverParaBaixo();
    }

    protected void moverHorizontalmenteFreeze(float direcao)
    {
        fixarHorizontalmente();
        moverHorizontalmente(direcao);
    }    

    protected void colocarNaAlturaInicial()
    {
        garraDto.RigidBody.transform.localPosition = new Vector2(garraDto.RigidBody.position.x, posInicial.y);
    }

    protected void colocarNaPosInicial()
    {
        garraDto.RigidBody.transform.localPosition = posInicial;
    }

    protected void colocarMassa(int massa)
    {
        garraDto.RigidBody.mass = massa;
    }

    private void fixarHorizontalmente()
    {
        garraDto.RigidBody.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
    }

    private void fixarVerticalmente()
    {
        garraDto.RigidBody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
    }

    protected void fixarVerticalEHorizontal()
    {
        garraDto.RigidBody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
    }

    protected void desafixar()
    {
        garraDto.RigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    protected bool isAcimaPosInicial()
    {
        return garraDto.RigidBody.transform.localPosition.y >= posInicial.y;
    }

    protected bool isParada()
    {
        return garraDto.RigidBody.velocity.x == 0 && garraDto.RigidBody.velocity.y == 0;
    }

    protected bool isMaiorPosHorizontal(float posHorizontal)
    {
        return garraDto.RigidBody.transform.localPosition.x > posHorizontal;
    }

    protected bool isMenorPosHorizontal(float posHorizontal)
    {
        return garraDto.RigidBody.transform.localPosition.x < posHorizontal;
    }

    protected void dispararEventoDirecao(int direcao)
    {
        if (direcao == 1)
        {
            produtorEventoDirecao.produziuEvento(DirecaoDaGarra.DIREITA);
        }
        else
        {
            produtorEventoDirecao.produziuEvento(DirecaoDaGarra.ESQUERDA);
        }
    }

    public static void configurarComponentesMovimentacao(
        GarraDto garraDtoArg,         
        InputGame inputGameArg)
    {
        garraDto = garraDtoArg;
        pincas = new PincaDaGarra(garraDto.PincaEsquerda, garraDto.PincaDireita);        
        inputGame = inputGameArg;

        produtorEventoDirecao = new ProdutorDeEvento<DirecaoDaGarra>();
        produtorEventoGarraAcertou = new ProdutorDeEvento<string>();
        produtorDeEventoSubidaDaGarra = new ProdutorDeEvento<int>();
        animacao = new AnimacaoGarra(garraDto.Animator);
    }
}
