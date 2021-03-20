using UnityEngine;

public class MovimentacaoParaBaixo : MovimentacaoDaGarra
{
    private float incremento;    

    private Quaternion anguloDesejadoEsquerda;
    private Quaternion anguloDesejadoDireita;    

    private ProdutorDeEvento<GameObject> produtorDeEventoAtingiuColetavel;

    public MovimentacaoParaBaixo(ProdutorDeEvento<GameObject> produtorDeEventoAtingiuColetavel)
    {
        this.produtorDeEventoAtingiuColetavel = produtorDeEventoAtingiuColetavel;

        anguloDesejadoDireita  = Quaternion.Euler(0, 0, -compDaGarra.AnguloAberturaGarra);
        anguloDesejadoEsquerda = Quaternion.Euler(0, 0,  compDaGarra.AnguloAberturaGarra);
    }

    public override void preInicio()
    {
    }

    public override void update()
    {
    }

    public override void fixedUpdate()
    {
        incremento = Time.deltaTime * compDaGarra.VelocidadeAberturaGarra;
        compDaGarra.PincaEsquerda.rotation = Quaternion.RotateTowards(
            compDaGarra.PincaEsquerda.rotation, anguloDesejadoEsquerda, incremento);

        compDaGarra.PincaDireita.rotation =  Quaternion.RotateTowards(
            compDaGarra.PincaDireita.rotation,  anguloDesejadoDireita , incremento);

        compDaGarra.RigidBody.velocity = new Vector2(compDaGarra.RigidBody.velocity.x,           
           1 * compDaGarra.VelocMovBaixo * Time.fixedDeltaTime);
    }

    public override void garraColidiuCom(GameObject gameObject)
    {
        Debug.Log("Atingiu: " + gameObject.name);
        if (Utils.isColetavel(gameObject))
        {
            gameObject.layer = LayerMask.NameToLayer("Atracao");
            communicatorComGarra.trocarParaAgarrada();
            produtorDeEventoAtingiuColetavel.produziuEvento(gameObject);
        }
    }
}
