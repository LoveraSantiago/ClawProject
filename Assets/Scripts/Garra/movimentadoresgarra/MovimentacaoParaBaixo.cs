using UnityEngine;

public class MovimentacaoParaBaixo : MovimentacaoDaGarra
{
    private float incremento;    

    private Quaternion anguloDesejadoEsquerda;
    private Quaternion anguloDesejadoDireita;

    private readonly int layerMask = LayerMask.GetMask("Coletavel");//TODO agrupar em uma classe estatica de constantes
    private RaycastHit2D rayCastHit;

    public MovimentacaoParaBaixo()
    {
        anguloDesejadoDireita  = Quaternion.Euler(0, 0, -compDaGarra.AnguloAberturaGarra);
        anguloDesejadoEsquerda = Quaternion.Euler(0, 0,  compDaGarra.AnguloAberturaGarra);
    }

    public override void preInicio()
    {
        acertarRayCast();         
    }

    public override void update()
    {
        Debug.DrawRay(compDaGarra.CentroDaPinca.position, Vector2.down * 10, Color.red);
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

    private void acertarRayCast()
    {
        rayCastHit = Physics2D.Raycast(compDaGarra.CentroDaPinca.position, Vector2.down, 10, layerMask);
        if(rayCastHit.collider != null)
        {
            Debug.Log("Raycast Acertou: " + rayCastHit.collider.gameObject.name);
        }
        else
        {
            Debug.Log("NADA!");
        }
        
    }
}
