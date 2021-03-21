using UnityEngine;

public class MovimentacaoParaBaixo : MovimentacaoDaGarra
{
    private float incremento;    

    private Quaternion anguloDesejadoEsquerda;
    private Quaternion anguloDesejadoDireita;    

    private ProdutorDeEvento<GameObject> produtorDeEventoAtingiuColetavel;
    private ContadorDeTempo contadorDeTempoTravamento;

    public MovimentacaoParaBaixo(ProdutorDeEvento<GameObject> produtorDeEventoAtingiuColetavel)
    {
        this.produtorDeEventoAtingiuColetavel = produtorDeEventoAtingiuColetavel;

        anguloDesejadoDireita  = Quaternion.Euler(0, 0, -compDaGarra.AnguloAberturaGarra);
        anguloDesejadoEsquerda = Quaternion.Euler(0, 0,  compDaGarra.AnguloAberturaGarra);

        contadorDeTempoTravamento = new ContadorDeTempo(2, () => communicatorComGarra.trocarParaAgarrada());
    }

    public override void preInicio()
    {
        contadorDeTempoTravamento.resetContador();
        compDaGarra.RigidBody.velocity = Vector2.zero;
        compDaGarra.RigidBody.angularVelocity = 0;
    }

    public override void update()
    {
        contadorDeTempoTravamento.contarTempo();
    }

    public override void fixedUpdate()
    {
        incremento = Time.deltaTime * compDaGarra.VelocidadeAberturaGarra;

        compDaGarra.PincaEsquerda.rotation = Quaternion.RotateTowards(
            compDaGarra.PincaEsquerda.rotation, anguloDesejadoEsquerda, incremento);

        compDaGarra.PincaDireita.rotation =  Quaternion.RotateTowards(
            compDaGarra.PincaDireita.rotation,  anguloDesejadoDireita , incremento);

        compDaGarra.RigidBody.velocity = new Vector2(0,           
           1 * compDaGarra.VelocMovBaixo * Time.fixedDeltaTime);
    }

    public override void garraColidiuCom(GameObject gameObject)
    {
        Debug.Log("Atingiu: " + gameObject.name);
        if (Utils.isColetavel(gameObject))
        {
            
            ligarAtracaoNoObjeto(gameObject);
            communicatorComGarra.trocarParaAgarrada();
            //produtorDeEventoAtingiuColetavel.produziuEvento(gameObject);
        }
    }
}
