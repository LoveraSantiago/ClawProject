using UnityEngine;

public abstract class AbstractMovimentacaoDaGarra : ComponenteAnimacaoDeMovimentacaoGarra, 
                                            AcaoSincroniaComDirecaoDaGarra.ProdutorEvento
{
    protected readonly float LIMITE_LATERAL_TELA = 2.25f;
    
    private static AngulosPropriedades angulosProps;

    public virtual void preInicio() { }
    public virtual void update(InputGame inputGame) { }
    public virtual void fixedUpdate() { }

    public virtual void garraColidiuCom(GameObject gameObject) { }    

    protected void parar()
    {
        getGarra().rigidBody.parar();
    }

    protected void moverParaCimaFreeze()
    {
        getGarra().efeito.ligarTrailPCima();
        getGarra().rigidBody.fixarVerticalmente();
        getGarra().rigidBody.moverPCima();
    }

    protected void moverParaBaixoFreeze()
    {
        getGarra().efeito.ligarTrailPBaixo();
        getGarra().rigidBody.fixarVerticalmente();
        getGarra().rigidBody.moverPBaixo();        
    }

    protected void moverHorizontalmenteFreeze(float direcao)
    {
        getGarra().efeito.desligarTrail();
        getGarra().rigidBody.fixarHorizontalmente();
        getGarra().rigidBody.moverPHorizontal(direcao);          
    }    

    protected void agarrando()
    {
        getGarra().efeito.desligarTrail();
    }

    protected void voltando()
    {
        getGarra().efeito.desligarTrail();
    }

    protected void colocarNaAlturaInicial()
    {
        getGarra().rigidBody.colocarNaHalturaInicial();
    }

    protected void colocarNaPosInicial()//REMOVER
    {
        getGarra().rigidBody.colocarNaPosicaoInicial();
    }

    protected void colocarNaPosHorizontal(float posHorizontal)
    {
        getGarra().rigidBody.colocarNaPosicaoHorizontal(posHorizontal);        
    }

    protected void colocarMassa(int massa)
    {
        getGarra().rigidBody.colocarMassa(massa);        
    }

    protected void fixarVerticalEHorizontal()
    {
        getGarra().rigidBody.fixarVerticalEHorizontal();
    }

    protected void desafixar()
    {
        getGarra().rigidBody.desafixar();
    }

    protected bool isAcimaPosInicial()
    {
        return getGarra().rigidBody.isAcimaPosInicial();
    }

    protected bool isParada()//REMOVER
    {
        return false;
    }

    protected bool isMaiorPosHorizontal(float posHorizontal)
    {
        return getGarra().rigidBody.isMaiorPosHorizontal(posHorizontal);
    }

    protected bool isMenorPosHorizontal(float posHorizontal)
    {
        return getGarra().rigidBody.isMenorPosHorizontal(posHorizontal);
    }

    protected Vector3 getPosicaoCentroGarra()
    {
        return getGarra().getPosicaoCentroGarra();
    }

    protected float getPosicaoHorizontalMeio()
    {
        return 0;
    }

    protected float getPosicaoCacaNiquel()
    {
        return getGarra().garraDto.PosCacaNiquel;
    }

    protected void acionarColliderDasPincas()
    {
        getGarra().pincas.acionarCollider();
    }

    protected void acionarTriggerDasPincas()
    {
        getGarra().pincas.acionarTrigger();
    }

    protected bool isPincaDireitaNoAngulo(Quaternion anguloDesejado)
    {
        return getGarra().pincas.isDireitaNoAngulo(anguloDesejado);
    }

    protected bool isPincaDireitaNoAnguloDeFechamento()
    {
        return isPincaDireitaNoAngulo(angulosProps.angFechamentoDireita);
    }

    protected void rotacionarPincaVelocidadeAberturaFDT(Quaternion angEsquerda, Quaternion angDireita)
    {
        rotacionarPincaFDT(getGarra().garraDto.Velocidades.MovAnguloAbertura, angEsquerda, angDireita);
    }

    protected void rotacionarPincaVelocidadeFechamentoFDT()
    {
        rotacionarPincaVelocidadeFechamentoFDT(angulosProps.angFechamentoEsquerda, angulosProps.angFechamentoDireita);
    }

    protected void rotacionarPincaVelocidadeFechamentoFDT(Quaternion angEsquerda, Quaternion angDireita)
    {
        rotacionarPincaFDT(getGarra().garraDto.Velocidades.MovAnguloFechamento, angEsquerda, angDireita);
    }

    protected void rotacionarPincaVelocidadeIdleFDT(Quaternion angEsquerda, Quaternion angDireita)
    {
        rotacionarPincaFDT(getGarra().garraDto.Velocidades.MovAnguloIdle, angEsquerda, angDireita);
    }

    protected void rotacionarPincaFDT(float velocidade, Quaternion angEsquerda, Quaternion angDireita)
    {
        getGarra().pincas.rotacionarFDT(velocidade, angEsquerda, angDireita);
    }

    protected Quaternion getAnguloIdleMaxDireita()
    {
        return angulosProps.angIdleMaxDireita;
    }

    protected Quaternion getAnguloIdleMaxEsquerda()
    {
        return angulosProps.angIdleMaxEsquerda;
    }

    protected Quaternion getAnguloIdleMinDireita()
    {
        return angulosProps.angIdleMinDireita;
    }

    protected Quaternion getAnguloIdleMinEsquerda()
    {
        return angulosProps.angIdleMinEsquerda;
    }

    protected Quaternion getAnguloAberturaEsquerda()
    {
        return angulosProps.angAberturaEsquerda;
    }

    protected Quaternion getAnguloAberturaDireita()
    {
        return angulosProps.angAberturaDireita;
    }

    protected void produziuEventoDeDirecao(int direcao)
    {
        getGarra().dispararEventoDirecao(direcao);        
    }     

    public void produziuEventoDeDirecao(DirecaoDaGarra direcao)
    {
        getGarra().dispararEventoDirecao(direcao);        
    }

    public static void configurar(GarraDto garraDto)
    {
        configurarGarraDto(garraDto);
        angulosProps = new AngulosPropriedades(garraDto.Angulos);
    }   
}
