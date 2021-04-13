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

        contadorDeTempoTravamento = new ContadorDeTempo(1.5f, () => comunicadorComGerMovimentacao.trocarParaAcaoAgarrada());
        produtorEventoGarraAcertou = new ProdutorDeEvento<string>();
    }

    public override void preInicio()
    {        
        garraDto.RigidBody.mass = 2;
        contadorDeTempoTravamento.resetContador();
        diminuirInerciaDaGarra();        
    }

    public override void update()
    {
        contadorDeTempoTravamento.contarTempo();
    }

    public override void fixedUpdate()
    {
        pincas.rotacionarFDT(garraDto.VelocidadeAnguloAbertura,
            anguloDesejadoEsquerda, anguloDesejadoDireita);

        garraDto.RigidBody.velocity = new Vector2(0,           
           1 * garraDto.VelocMovBaixo * Time.fixedDeltaTime);
    }

    public override void garraColidiuCom(GameObject gameObject)
    {
        //Debug.Log("Atingiu: " + gameObject.name);
        if (Utils.isColetavel(gameObject))
        {
            produtorEventoGarraAcertou.produziuEvento(gameObject.name);
            comunicadorComGerMovimentacao.trocarParaAcaoAgarrada();
        }
    }    
}
