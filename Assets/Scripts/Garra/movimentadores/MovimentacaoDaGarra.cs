using UnityEngine;
//TODO quebrar a classe em responsabilidades menores
public abstract class MovimentacaoDaGarra 
{
    protected readonly float LIMITE_LATERAL_TELA = 2.25f;   
    public static Garra garra { get; private set; }//FECHAR VAZAMENTO DE CONTEXTO PARA MOVIMENTADORES

    public virtual void preInicio() { }
    public virtual void update(InputGame inputGame) { }
    public virtual void fixedUpdate() { }

    public virtual void garraColidiuCom(GameObject gameObject) { }

    public void playAnimcaoComemorar()
    {
        garra.animacao.comemorar();
    }

    public void playAnimacaoPiscar()
    {
        garra.animacao.piscar();
    }

    public void playAnimacaoIrPDireita()
    {
        garra.animacao.irParaDireita();
    }

    public void playAnimacaoIrPEsquerda()
    {
        garra.animacao.irParaEsquerda();
    }

    public void playAnimacaoIrPCima()
    {
        garra.animacao.irParaCima();
    }

    public void playAnimacaoIrPBaixo()
    {
        garra.animacao.irParaBaixo();
    }

    public bool isPlayAnimacaoComemorando()
    {
        return garra.animacao.isComemorando();
    }

    public bool isNotPlayAnimacaoComemorando()
    {
        return !isPlayAnimacaoComemorando();
    }

    protected void parar()
    {
        garra.rigidBody.parar();
    }

    protected void moverParaCimaFreeze()
    {
        garra.rigidBody.fixarVerticalmente();
        garra.moverParaCima();        
    }

    protected void moverParaBaixoFreeze()
    {
        garra.rigidBody.fixarVerticalmente();
        garra.moverParaBaixo();
    }

    protected void moverHorizontalmenteFreeze(float direcao)
    {
        garra.rigidBody.fixarHorizontalmente();
        garra.moverHorizontalmente(direcao);        
    }    

    protected void agarrando()
    {
        garra.desligarTrail();
    }

    protected void voltando()
    {
        garra.desligarTrail();
    }

    protected void colocarNaAlturaInicial()
    {
        garra.rigidBody.colocarNaHalturaInicial();
    }

    protected void colocarNaPosInicial()//REMOVER
    {
        garra.rigidBody.colocarNaPosicaoInicial();
    }

    protected void colocarNaPosHorizontal(float posHorizontal)
    {
        garra.rigidBody.colocarNaPosicaoHorizontal(posHorizontal);        
    }

    protected void colocarMassa(int massa)
    {
        garra.rigidBody.colocarMassa(massa);        
    }

    protected void fixarVerticalEHorizontal()
    {
        garra.rigidBody.fixarVerticalEHorizontal();
    }

    protected void desafixar()
    {
        garra.rigidBody.desafixar();
    }

    protected bool isAcimaPosInicial()
    {
        return garra.rigidBody.isAcimaPosInicial();
    }

    protected bool isParada()//REMOVER
    {
        return false;
    }

    protected bool isMaiorPosHorizontal(float posHorizontal)
    {
        return garra.rigidBody.isMaiorPosHorizontal(posHorizontal);
    }

    protected bool isMenorPosHorizontal(float posHorizontal)
    {
        return garra.rigidBody.isMenorPosHorizontal(posHorizontal);
    }

    protected void dispararEventoDirecao(int direcao)
    {
        garra.dispararEventoDirecao(direcao);        
    }     
    
    protected void acionarColliderDasPincas()
    {
        garra.pincas.acionarCollider();
    }

    protected void acionarTriggerDasPincas()
    {
        garra.pincas.acionarTrigger();
    }

    protected bool isPincaDireitaNoAngulo(Quaternion anguloDesejado)
    {
        return garra.pincas.isDireitaNoAngulo(anguloDesejado);
    }

    protected void rotacionarPincaFDT(float velocidade, Quaternion angEsquerda, Quaternion angDireita)
    {
        garra.pincas.rotacionarFDT(velocidade, angEsquerda, angDireita);
    }

    protected void produziuEventoDeDirecao(DirecaoDaGarra direcao)
    {
        Garra.produtorEventoDirecao.produziuEvento(direcao);
    }

    public static void configurarComponentesMovimentacao(GarraDto garraDtoArg)
    {
        garra = new Garra(garraDtoArg);               
    }
}
