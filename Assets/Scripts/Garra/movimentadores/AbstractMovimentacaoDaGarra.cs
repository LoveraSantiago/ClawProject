using UnityEngine;

public abstract class AbstractMovimentacaoDaGarra : ComponenteRigidBodyDeMovimentacaoGarra, 
                                                    AcaoSincroniaComDirecaoDaGarra.ProdutorEvento
{
    private static int contadorDeSubidas;
    public static ProdutorDeEvento<InformacoesDaGarraDto> produtorEventoInfoGarra { get; private set; }

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

    protected void contabilizarSubida()
    {
        contadorDeSubidas++;
    }

    protected void produzirEventoInfoDaGarra(string nomeColidido)
    {
        produtorEventoInfoGarra.produziuEvento(new InformacoesDaGarraDto(nomeColidido));
    }

    public static void configurar(GarraDto garraDto)
    {
        configurarComponenteGarra(garraDto);
        contadorDeSubidas = 0;
        produtorEventoInfoGarra = new ProdutorDeEvento<InformacoesDaGarraDto>();
    }
}
