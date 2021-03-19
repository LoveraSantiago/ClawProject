using UnityEngine;

public class MovimentacaoAgarrando : MovimentacaoDaGarra
{   
    private float incremento;    
    
    private Quaternion anguloDesejadoEsquerda;
    private Quaternion anguloDesejadoDireita;

    public MovimentacaoAgarrando()
    {
        anguloDesejadoDireita  = Quaternion.Euler(0, 0,   compDaGarra.AnguloFechamentoGarra);
        anguloDesejadoEsquerda = Quaternion.Euler(0, 0, -compDaGarra.AnguloFechamentoGarra);        
    }

    public override void update()
    {
        //rigidBody2d.gravityScale = 0;
        if (Input.GetButtonDown("Jump"))
        {
            Vector2 posicaoInicial = compDaGarra.RigidBody.transform.localPosition;
            Debug.Log("Posicao inicial: " + posicaoInicial);
            communicatorComGarra.trocarParaAcaoSubindo();
        }
    }

    public override void fixedUpdate()
    {
        incremento = Time.deltaTime * compDaGarra.VelocidadeFechamentoGarra;
        compDaGarra.PincaEsquerda.rotation = Quaternion.RotateTowards(
            compDaGarra.PincaEsquerda.rotation, anguloDesejadoEsquerda, incremento);

        compDaGarra.PincaDireita.rotation = Quaternion.RotateTowards(
            compDaGarra.PincaDireita.rotation, anguloDesejadoDireita, incremento);
    }
}
