using UnityEngine;

public class MovimentacaoParaBaixo : MovimentacaoDaGarra
{
    private Quaternion anguloDesejadoEsquerda;
    private Quaternion anguloDesejadoDireita;   
    
    private ContadorDeTempo contadorDeTempoTravamento;
    public ProdutorDeEvento<string> produtorEventoGarraAcertou { get; private set; }

    public MovimentacaoParaBaixo()
    {
        anguloDesejadoDireita  = Quaternion.Euler(0, 0, -garraDto.AnguloAbertura);
        anguloDesejadoEsquerda = Quaternion.Euler(0, 0,  garraDto.AnguloAbertura);

        contadorDeTempoTravamento  = new ContadorDeTempo(1.0f);
        produtorEventoGarraAcertou = new ProdutorDeEvento<string>();
    }

    public override void preInicio()
    {   
        colocarMassaNaGarra(2);
        contadorDeTempoTravamento.resetContador();
        diminuirInerciaDaGarra();

        moverGarraParaBaixo();
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
