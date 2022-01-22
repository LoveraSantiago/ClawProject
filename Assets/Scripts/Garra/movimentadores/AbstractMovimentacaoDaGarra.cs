using UnityEngine;

public abstract class AbstractMovimentacaoDaGarra : ComponentePincasDeMovimentacaoGarra, 
                                                    AcaoSincroniaComDirecaoDaGarra.ProdutorEvento
{
    protected readonly float LIMITE_LATERAL_TELA = 2.25f;

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
        configurarComponenteGarra(garraDto);        
    }   
}
