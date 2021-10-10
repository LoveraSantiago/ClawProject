using UnityEngine;
//TODO quebrar a classe em responsabilidades menores
public abstract class MovimentacaoDaGarra 
{
    protected readonly float LIMITE_LATERAL_TELA = 2.25f;   
    private static MovimentacaoDaGarraContextoEstatico contexto;

    public virtual void preInicio() { }
    public virtual void update(InputGame inputGame) { }
    public virtual void fixedUpdate() { }

    public virtual void garraColidiuCom(GameObject gameObject) { }

    public void comemorar()
    {
        contexto.animacao.comemorar();
    }

    public bool isComemorando()
    {
        return contexto.animacao.isComemorando();
    }

    protected void parar()
    {
        contexto.pararGarraRigidBody();
    }

    protected void moverParaCimaFreeze()
    {
        contexto.fixarGarraRigidBodyVerticalmente();
        contexto.moverParaCima();        
    }

    protected void moverParaBaixoFreeze()
    {
        contexto.fixarGarraRigidBodyVerticalmente();
        contexto.moverParaBaixo();
    }

    protected void moverHorizontalmenteFreeze(float direcao)
    {
        contexto.fixarGarraRigidBodyHorizontalmente();
        contexto.moverHorizontalmente(direcao);        
    }    

    protected void agarrando()
    {
        contexto.desligarTrail();
    }

    protected void voltando()
    {
        contexto.desligarTrail();
    }

    protected void colocarNaAlturaInicial()
    {
        contexto.colocarGarraRigidBodyAlturaInicial();
    }

    protected void colocarNaPosInicial()//REMOVER
    {
        contexto.colocarGarraRigidBodyPosInicial();
    }

    protected void colocarNaPosHorizontal(float posHorizontal)
    {
        contexto.colocarGarraRigidBodyPosHorizontal(posHorizontal);        
    }

    protected void colocarMassa(int massa)
    {
        contexto.colocarMassaNaGarraRigidyBody(massa);        
    }

    protected void fixarVerticalEHorizontal()
    {
        contexto.fixarGarraRigidyBodyVerticalEHorizontal();
    }

    protected void desafixar()
    {
        contexto.desafixarGarraRigidBody();
    }

    protected bool isAcimaPosInicial()
    {
        return contexto.isGarraRigidyBodyAcimaPosInicial();        
    }

    protected bool isParada()//REMOVER
    {
        return false;
    }

    protected bool isMaiorPosHorizontal(float posHorizontal)
    {
        return contexto.isGarraRigidBodyMaiorPosHorizontal(posHorizontal);
    }

    protected bool isMenorPosHorizontal(float posHorizontal)
    {
        return contexto.isGarraRigidBodyMenorPosHorizontal(posHorizontal);
    }

    protected void dispararEventoDirecao(int direcao)
    {
        contexto.dispararEventoDirecao(direcao);        
    }     
    
    protected void acionarColliderDasPincas()
    {
        contexto.pincas.acionarCollider();
    }

    public static void configurarComponentesMovimentacao(GarraDto garraDtoArg)
    {
        contexto = new MovimentacaoDaGarraContextoEstatico(garraDtoArg);               
    }
}
