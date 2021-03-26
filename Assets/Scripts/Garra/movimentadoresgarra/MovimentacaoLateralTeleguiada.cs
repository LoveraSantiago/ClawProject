using UnityEngine;
//TODO dupla responsabilidade. ifs para 2 estados - RUIM
public class MovimentacaoLateralTeleguiada : MovimentacaoDaGarra
{
    private bool aceitarClique;
    private bool moverLateralmente;

    private float posicaoDoToque;
    private int direcao;

    public override void preInicio()
    {
        aceitarClique = true;
        moverLateralmente = false;
        desligarAtracaoNoObjeto();
    }
    
    public override void update()
    {
        //TEMPORARIAMENTE AQUI ... PEGAR TOQUE NA TELA
        if (aceitarClique && Input.GetMouseButtonDown(0))
        {
         
            RaycastHit2D raycastHit;
            int layerMask = LayerMask.GetMask("Coletavel");

            Vector3 posicaoClicada = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            posicaoClicada.z = 0;              

            raycastHit = Physics2D.Raycast(posicaoClicada, Vector3.up, 2, layerMask);
            if (raycastHit.collider != null)
            {
                posicaoDoToque = posicaoClicada.x;
                aceitarClique = false;
                moverLateralmente = true;
            }
        }       
    }

    public override void fixedUpdate()
    {
        if (moverLateralmente)
        {            
            if (posicaoDoToque >= 0)
            {
                if(compDaGarra.RigidBody.transform.localPosition.x < Mathf.Min(posicaoDoToque, LIMITE_LATERAL_TELA))//REFATORAR COMPLEXIDADE
                {
                    compDaGarra.RigidBody.velocity = new Vector2(
                        1 * compDaGarra.VelocMovHorizontal * Time.fixedDeltaTime,
                        compDaGarra.RigidBody.velocity.y);                
                }
                else
                {
                    Vector2 posicaoInicial = compDaGarra.RigidBody.transform.localPosition;
                    comunicadorComGerMovimentacao.trocarParaAcaoDescendo(posicaoInicial);
                }                    
            }
            else
            {
                if (compDaGarra.RigidBody.transform.localPosition.x > Mathf.Max(posicaoDoToque, -LIMITE_LATERAL_TELA))//REFATORAR COMPLEXIDADE
                {
                    compDaGarra.RigidBody.velocity = new Vector2(
                        -1 * compDaGarra.VelocMovHorizontal * Time.fixedDeltaTime,
                        compDaGarra.RigidBody.velocity.y);
                }
                else
                {
                    Vector2 posicaoInicial = compDaGarra.RigidBody.transform.localPosition;
                    comunicadorComGerMovimentacao.trocarParaAcaoDescendo(posicaoInicial);
                }
            }
        }
    }

    
    
}
