using UnityEngine;

public class MovimentacaoLateralZigZag : MovimentacaoDaGarra
{    

    private float movimentoLateral;        
    private float direcao;    

    public MovimentacaoLateralZigZag()
    {        
        direcao = 1;        
    }

    public override void preInicio()
    {
        desligarAtracaoNoObjeto();
    }

    public override void update()
    {
        if (Input.GetMouseButtonDown(0))
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
