using UnityEngine;

public abstract class MovimentacaoDaGarra : AcaoSincroniaComDirecaoDaGarra.ProdutorEvento
{
    protected readonly float LIMITE_LATERAL_TELA = 2.25f;
    private static Garra garra;
    protected static AngulosTemporarios angulosTemp;

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
        garra.efeito.ligarTrailPCima();
        garra.rigidBody.fixarVerticalmente();
        garra.rigidBody.moverPCima();
    }

    protected void moverParaBaixoFreeze()
    {
        garra.efeito.ligarTrailPBaixo();
        garra.rigidBody.fixarVerticalmente();
        garra.rigidBody.moverPBaixo();        
    }

    protected void moverHorizontalmenteFreeze(float direcao)
    {
        garra.efeito.desligarTrail();
        garra.rigidBody.fixarHorizontalmente();
        garra.rigidBody.moverPHorizontal(direcao);          
    }    

    protected void agarrando()
    {
        garra.efeito.desligarTrail();
    }

    protected void voltando()
    {
        garra.efeito.desligarTrail();
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

    protected Vector3 getPosicaoCentroGarra()
    {
        return garra.getPosicaoCentroGarra();
    }

    protected float getPosicaoCacaNiquel()
    {
        return garra.garraDto.PosCacaNiquel;
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

    protected void rotacionarPincaVelocidadeFechamentoFDT(Quaternion angEsquerda, Quaternion angDireita)
    {
        garra.pincas.rotacionarFDT(garra.garraDto.Velocidades.MovAnguloFechamento, angEsquerda, angDireita);
    }

    protected void rotacionarPincaFDT(float velocidade, Quaternion angEsquerda, Quaternion angDireita)
    {
        garra.pincas.rotacionarFDT(velocidade, angEsquerda, angDireita);
    }

    protected void produziuEventoDeDirecao(int direcao)
    {
        garra.dispararEventoDirecao(direcao);        
    }     

    public void produziuEventoDeDirecao(DirecaoDaGarra direcao)
    {
        garra.dispararEventoDirecao(direcao);        
    }

    public static void configurar(GarraDto garraDto)
    {
        garra = new Garra(garraDto);
        angulosTemp = new AngulosTemporarios(garraDto.Angulos);
    }

    ProdutorDeEvento<DirecaoDaGarra> AcaoSincroniaComDirecaoDaGarra.ProdutorEvento.getProdutorDeEvento()
    {
        return ((AcaoSincroniaComDirecaoDaGarra.ProdutorEvento)garra).getProdutorDeEvento();
    }
}
