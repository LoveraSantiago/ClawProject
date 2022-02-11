using UnityEngine;

public abstract class AbstractMovimentacaoDaGarra : ComponenteRigidBodyDeMovimentacaoGarra, 
                                                    AcaoSincroniaComDirecaoDaGarra.ProdutorEvento
{
    protected readonly float LIMITE_LATERAL_TELA = 2.25f;

    public virtual void preInicio() { }
    public virtual void update(InputGame inputGame) { }
    public virtual void fixedUpdate() { }

    public virtual void garraColidiuCom(GameObject gameObject) { }       

    protected void moverParaCimaFreeze()
    {
        getGarra().efeito.ligarTrailPCima();//deveria estar aqui?
        fixarVerticalmente();
        moverParaCima();        
    }

    protected void moverParaBaixoFreeze()
    {
        getGarra().efeito.ligarTrailPBaixo();
        fixarVerticalmente();
        moverParaBaixo();
    }

    protected void moverHorizontalmenteFreeze(float direcao)
    {
        getGarra().efeito.desligarTrail();
        fixarHorizontalmente();
        moverParaHorizontal(direcao);
    }    

    protected void agarrando()
    {
        getGarra().efeito.desligarTrail();
    }

    protected void voltando()
    {
        getGarra().efeito.desligarTrail();
    }   

    protected bool isParada()//REMOVER
    {
        return false;
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

    public static void configurar(GarraDto garraDto)
    {
        configurarComponenteGarra(garraDto);        
    }   
}
