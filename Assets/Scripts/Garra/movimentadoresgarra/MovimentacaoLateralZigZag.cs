using UnityEngine;

public class MovimentacaoLateralZigZag : MovimentacaoDaGarra
{    

    private float movimentoLateral;        
    private float direcao;

    private Quaternion anguloDesejadoEsquerda;
    private Quaternion anguloDesejadoDireita;    

    public MovimentacaoLateralZigZag()
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
            comunicadorComGerMovimentacao.trocarParaAcaoDescendo(posicaoInicial);
        }
    }
    
    public override void fixedUpdate()
    {        
        verificarSeMovimentacaoAtingiuLimites();
        
        compDaGarra.RigidBody.velocity = new Vector2(
            direcao * compDaGarra.VelocMovHorizontal * Time.fixedDeltaTime,
            compDaGarra.RigidBody.velocity.y);
    }

    private void verificarSeMovimentacaoAtingiuLimites()
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
        else
        {
            //nada
        }
    }
}
