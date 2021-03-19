using UnityEngine;

public class MovimentacaoParaBaixo : MovimentacaoDaGarra
{
    private readonly float ANGULO_ROTACAO_ABERTO = 50f;
    private readonly float VELOCIDADE_ROTACAO = 75f;

    private float gravidade;
    private float incremento;    

    private Quaternion anguloDesejadoEsquerda;
    private Quaternion anguloDesejadoDireita;

    private Transform pincaDireita;
    private Transform pincaEsquerda;

    public MovimentacaoParaBaixo(float gravidade, 
        Transform pincaDireita, 
        Transform pincaEsquerda)
    {
        this.gravidade = gravidade;

        anguloDesejadoDireita  = Quaternion.Euler(0, 0, -ANGULO_ROTACAO_ABERTO);
        anguloDesejadoEsquerda = Quaternion.Euler(0, 0,  ANGULO_ROTACAO_ABERTO);

        this.pincaDireita  = pincaDireita;
        this.pincaEsquerda = pincaEsquerda;
    }

    public override void update()
    {
        incremento = Time.deltaTime * VELOCIDADE_ROTACAO;
        pincaEsquerda.rotation = Quaternion.RotateTowards(pincaEsquerda.rotation, anguloDesejadoEsquerda, incremento);
        pincaDireita.rotation =  Quaternion.RotateTowards(pincaDireita.rotation,  anguloDesejadoDireita , incremento);
    }

    public override void fixedUpdate()
    {
        compDaGarra.RigidBody.gravityScale = gravidade;        
    }
}
