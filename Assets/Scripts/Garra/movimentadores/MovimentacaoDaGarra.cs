using UnityEngine;
//TODO quebrar a classe em responsabilidades menores
public abstract class MovimentacaoDaGarra 
{
    protected readonly float LIMITE_LATERAL_TELA = 2.25f;

    private static float alturaLocalEfeitoTrail;
    private static Vector2 posInicial;

    protected static PincaDaGarra pincas;
    protected static AnimacaoGarra animacao;
    protected static GarraDto garraDto;

    public static ProdutorDeEvento<DirecaoDaGarra> produtorEventoDirecao { get; private set; }            

    public virtual void preInicio() { }
    public virtual void update(InputGame inputGame) { }
    public virtual void fixedUpdate() { }

    public virtual void garraColidiuCom(GameObject gameObject) { }

    public void comemorar()
    {
        animacao.comemorar();
    }

    public bool isComemorando()
    {
        return animacao.isComemorando();
    }

    protected void parar()
    {
        garraDto.RigidBody.velocity = Vector3.zero;
        garraDto.RigidBody.angularVelocity = 0;
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

    protected void agarrando()
    {
        desligarTrail();
    }

    protected void voltando()
    {
        desligarTrail();
    }

    protected void colocarNaAlturaInicial()
    {
        garraDto.RigidBody.transform.localPosition = new Vector2(garraDto.RigidBody.position.x, posInicial.y);
    }

    protected void colocarNaPosInicial()
    {
        garraDto.RigidBody.transform.localPosition = posInicial;
    }

    protected void colocarNaPosHorizontal(float posHorizontal)
    {
        garraDto.RigidBody.transform.localPosition = new Vector3(posHorizontal, posInicial.y, 0);
    }

    protected void colocarMassa(int massa)
    {
        garraDto.RigidBody.mass = massa;
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

    private void moverParaCima()
    {
        ligarEfeitoTrailAngulo(-0.4f, 180);
        garraDto.RigidBody.velocity = new Vector2(0, garraDto.Velocidades.MovCima);        
    }

    private void moverParaBaixo()
    {
        ligarEfeitoTrailAngulo(0.8f, 0);
        garraDto.RigidBody.velocity = new Vector2(0, garraDto.Velocidades.MovBaixo);
    }

    private void moverHorizontalmente(float direcao)
    {
        garraDto.EfeitoTrail.Stop();
        //Debug.Log(direcao * garraDto.VelocMovHorizontal);
        garraDto.RigidBody.velocity = new Vector2(direcao * garraDto.Velocidades.MovHorizontal, 0);        
    }

    private void fixarHorizontalmente()
    {
        garraDto.RigidBody.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
    }

    private void fixarVerticalmente()
    {
        garraDto.RigidBody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
    }

    private void ligarEfeitoTrailAngulo(float incremento, float angulo)
    {
        garraDto.EfeitoTrail.Play();
        garraDto.EfeitoTrail.transform.rotation = Quaternion.Euler(0, 0, angulo);

        Vector3 localPos = garraDto.EfeitoTrail.transform.localPosition;
        garraDto.EfeitoTrail.transform.localPosition = new Vector3(localPos.x, alturaLocalEfeitoTrail + incremento, localPos.z);
    }

    private void desligarTrail()
    {
        garraDto.EfeitoTrail.Stop();
    }

    public static void configurarComponentesMovimentacao(GarraDto garraDtoArg)
    {
        garraDto   = garraDtoArg;
        posInicial = garraDto.RigidBody.transform.localPosition;
        alturaLocalEfeitoTrail = garraDto.EfeitoTrail.transform.localPosition.y;

        pincas   = new PincaDaGarra(garraDto.PincaEsquerda, garraDto.PincaDireita);                
        animacao = new AnimacaoGarra(garraDto.Animator);
        produtorEventoDirecao = new ProdutorDeEvento<DirecaoDaGarra>();                
    }
}
