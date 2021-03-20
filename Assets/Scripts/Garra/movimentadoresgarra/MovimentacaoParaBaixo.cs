using UnityEngine;

public class MovimentacaoParaBaixo : MovimentacaoDaGarra
{
    private float incremento;    

    private Quaternion anguloDesejadoEsquerda;
    private Quaternion anguloDesejadoDireita;    

    public MovimentacaoParaBaixo()
    {
        anguloDesejadoDireita  = Quaternion.Euler(0, 0, -compDaGarra.AnguloAberturaGarra);
        anguloDesejadoEsquerda = Quaternion.Euler(0, 0,  compDaGarra.AnguloAberturaGarra);
    }

    public override void update()
    {
        incremento = Time.deltaTime * compDaGarra.VelocidadeAberturaGarra;
        compDaGarra.PincaEsquerda.rotation = Quaternion.RotateTowards(
            compDaGarra.PincaEsquerda.rotation, anguloDesejadoEsquerda, incremento);

        compDaGarra.PincaDireita.rotation =  Quaternion.RotateTowards(
            compDaGarra.PincaDireita.rotation,  anguloDesejadoDireita , incremento);
    }

    public override void fixedUpdate()
    {
        compDaGarra.RigidBody.velocity = new Vector2(compDaGarra.RigidBody.velocity.x,           
           1 * compDaGarra.VelocMovBaixo * Time.fixedDeltaTime);
    }
}
