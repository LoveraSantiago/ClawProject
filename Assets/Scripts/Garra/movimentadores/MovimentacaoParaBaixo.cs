using UnityEngine;

public class MovimentacaoParaBaixo : MovimentacaoDaGarraNormal
{
    private Quaternion anguloDesejadoEsquerda;
    private Quaternion anguloDesejadoDireita;   
    
    private ContadorDeTempo contadorDeTempoTravamento;    

    public MovimentacaoParaBaixo()
    {
        anguloDesejadoDireita  = Quaternion.Euler(0, 0, -garraDto.AnguloAbertura);
        anguloDesejadoEsquerda = Quaternion.Euler(0, 0,  garraDto.AnguloAbertura);

        contadorDeTempoTravamento  = new ContadorDeTempo(1.0f);        
    }

    public override void preInicio()
    {   
        colocarMassa(2);
        contadorDeTempoTravamento.resetContador();
        animacao.irParaBaixo();
    }

    public override void update()
    {
        if (contadorDeTempoTravamento.contarTempoDT())
        {
            comunicadorComGerMovimentacao.trocarParaAcaoAgarrada();
        }
    }

    public override void fixedUpdate()
    {
        pincas.rotacionarFDT(garraDto.VelocidadeAnguloAbertura,
            anguloDesejadoEsquerda, anguloDesejadoDireita);

        moverParaBaixoFreeze();
    }

    public override void garraColidiuCom(GameObject gameObject)
    {        
        if (Utils.isColetavel(gameObject))
        {
            produtorEventoGarraAcertou.produziuEvento(gameObject.name);
            comunicadorComGerMovimentacao.trocarParaAcaoAgarrada();
        }
    }    
}
