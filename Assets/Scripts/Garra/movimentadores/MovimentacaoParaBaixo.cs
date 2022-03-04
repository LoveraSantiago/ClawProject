using UnityEngine;

public class MovimentacaoParaBaixo : MovimentadorProdutorInformacaoGarra
{   
    private IntervaloDeTempo intervaloTempoDeTravamento;    

    public MovimentacaoParaBaixo()
    {
        intervaloTempoDeTravamento = new IntervaloDeTempo(1.0f);        
    }

    public override void preInicio()
    {   
        colocarMassa(2);
        intervaloTempoDeTravamento.resetContador();
        playAnimacaoIrPBaixo();
    }

    public override void update(InputGame inputGame)
    {
        if (intervaloTempoDeTravamento.contarTempo())
        {
            comunicadorComGerMovimentacao.trocarParaAcaoAgarrada();
        }
    }

    public override void fixedUpdate()
    {
        Quaternion angAberturaEsquerda = getAnguloAberturaEsquerda();
        Quaternion angAberturaDireita  = getAnguloAberturaDireita();

        rotacionarPincaVelocidadeAberturaFDT(angAberturaEsquerda, angAberturaDireita);        
        moverParaBaixoFreeze();
    }

    public override void garraColidiuCom(GameObject gameObject)
    {        
        if (TagUtils.isColetavel(gameObject))
        {
            produzirEventoInfoDaGarra(gameObject.name);            
            comunicadorComGerMovimentacao.trocarParaAcaoAgarrada();
        }
    }   
}
