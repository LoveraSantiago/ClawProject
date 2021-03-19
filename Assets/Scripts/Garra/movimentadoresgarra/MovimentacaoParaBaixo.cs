using UnityEngine;

public class MovimentacaoParaBaixo : MovimentacaoDaGarra
{
    private readonly float ANGULO_ROTACAO_ABERTO = 50f;
    private readonly float VELOCIDADE_ROTACAO = 75f;

    private float incremento;    

    private Quaternion anguloDesejadoEsquerda;
    private Quaternion anguloDesejadoDireita;    

    public MovimentacaoParaBaixo()
    {
        anguloDesejadoDireita  = Quaternion.Euler(0, 0, -ANGULO_ROTACAO_ABERTO);
        anguloDesejadoEsquerda = Quaternion.Euler(0, 0,  ANGULO_ROTACAO_ABERTO);
    }

    public override void update()
    {
        incremento = Time.deltaTime * VELOCIDADE_ROTACAO;
        compDaGarra.PincaEsquerda.rotation = Quaternion.RotateTowards(
            compDaGarra.PincaEsquerda.rotation, anguloDesejadoEsquerda, incremento);

        compDaGarra.PincaDireita.rotation =  Quaternion.RotateTowards(
            compDaGarra.PincaDireita.rotation,  anguloDesejadoDireita , incremento);
    }

    public override void fixedUpdate()
    {
        compDaGarra.RigidBody.gravityScale = compDaGarra.GravidadePos;        
    }
}
