using UnityEngine;

public class MovimentacaoLateral : MovimentacaoDaGarra
{
    private readonly float LIMITE_LATERAL_TELA = 2.16f;

    private float movimentoLateral;        
    private float direcao;

    private Quaternion anguloDesejadoEsquerda;
    private Quaternion anguloDesejadoDireita;    

    public MovimentacaoLateral()
    {        
        direcao = 1;
        anguloDesejadoDireita  = Quaternion.Euler(0, 0, 0);
        anguloDesejadoEsquerda = Quaternion.Euler(0, 0, 0);
    }

    public override void preInicio()
    {
        desligarAtracaoNoObjeto();
    }

    public override void update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Vector2 posicaoInicial = compDaGarra.RigidBody.transform.localPosition;            
            communicatorComGarra.trocarParaAcaoDescendo(posicaoInicial);
        }
    }
    
    public override void fixedUpdate()
    {
        definirDirecaoDaMovimentacao();
        
        compDaGarra.RigidBody.velocity = new Vector2(
            direcao * compDaGarra.VelocMovHorizontal * Time.fixedDeltaTime,
            compDaGarra.RigidBody.velocity.y);
    }

    private void definirDirecaoDaMovimentacao()
    {
        if (compDaGarra.RigidBody.transform.localPosition.x > LIMITE_LATERAL_TELA)
        {
            direcao = -1;

            diminuirInerciaDaGarra();
        }
        else if (compDaGarra.RigidBody.transform.localPosition.x < -LIMITE_LATERAL_TELA)
        {
            direcao = 1;
            diminuirInerciaDaGarra();
        }
    }
}
