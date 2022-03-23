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
        ligarEfeitoTrailParaCima();
        fixarVerticalmente();
        moverParaCima();        
    }

    protected void moverParaBaixoFreeze()
    {
        ligarEfeitoTrailParaBaixo();
        fixarVerticalmente();
        moverParaBaixo();
    }

    protected void moverHorizontalmenteFreeze(float direcao)
    {
        desligarEfeitoTrail();
        fixarHorizontalmente();
        moverParaHorizontal(direcao);
    }    

    protected void agarrando()
    {
        desligarEfeitoTrail();
    }

    protected void voltando()
    {
        desligarEfeitoTrail();
    }          

    public static void configurar(GarraDto garraDto)
    {
        configurarComponenteGarra(garraDto);        
    }   
}
