using UnityEngine;

public class MovimentacaoParaBaixo : MovimentacaoDaGarra
{
    private Quaternion anguloDesejadoEsquerda;
    private Quaternion anguloDesejadoDireita;   
    
    private ContadorDeTempo contadorDeTempoTravamento;
    public ProdutorDeEvento<string> produtorEventoGarraAcertou { get; private set; }

    public MovimentacaoParaBaixo()
    {
        anguloDesejadoDireita  = Quaternion.Euler(0, 0, -compDaGarra.AnguloAbertura);
        anguloDesejadoEsquerda = Quaternion.Euler(0, 0,  compDaGarra.AnguloAbertura);

        contadorDeTempoTravamento = new ContadorDeTempo(1.5f, () => comunicadorComGerMovimentacao.trocarParaAgarrada());
        produtorEventoGarraAcertou = new ProdutorDeEvento<string>();
    }

    public override void preInicio()
    {        
        compDaGarra.RigidBody.mass = 2;
        contadorDeTempoTravamento.resetContador();
        diminuirInerciaDaGarra();        
    }

    public override void update()
    {
        contadorDeTempoTravamento.contarTempo();
    }

    public override void fixedUpdate()
    {
        pincas.fixUpdateRotacionamento(compDaGarra.VelocidadeAnguloAbertura,
            anguloDesejadoEsquerda, anguloDesejadoDireita);

        compDaGarra.RigidBody.velocity = new Vector2(0,           
           1 * compDaGarra.VelocMovBaixo * Time.fixedDeltaTime);
    }

    public override void garraColidiuCom(GameObject gameObject)
    {
        //Debug.Log("Atingiu: " + gameObject.name);
        if (Utils.isColetavel(gameObject))
        {
            produtorEventoGarraAcertou.produziuEvento(gameObject.name);
            comunicadorComGerMovimentacao.trocarParaAgarrada();
        }
    }    
}
