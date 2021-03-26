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

    Vector3 posTemp = Vector3.zero;
    public override void update()
    {
        //TEMPORARIAMENTE AQUI ... PEGAR TOQUE NA TELA
        if (aceitarClique && Input.GetMouseButtonDown(0))
        {
            //Debug.Log("clicou");
            RaycastHit2D raycastHit;
            int layerMask = LayerMask.GetMask("Coletavel");

            Vector3 posicaoClicada = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            posicaoClicada.z = 0;
            posTemp = posicaoClicada;
            //Debug.Log("Pos clicado: " + posicaoClicada);

            raycastHit = Physics2D.Raycast(posicaoClicada, Vector3.up, 2, layerMask);
            if (raycastHit.collider != null)
            {
                //Debug.Log("Raycast acertou");
                posicaoDoToque = posicaoClicada.x;
                aceitarClique = false;
                moverLateralmente = true;
            }
        }
        //Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        //Debug.Log(posTemp);
        //Debug.DrawRay(new Vector3(-0.2f, 0.5f, -1), Vector3.back * 10, Color.blue);
        //Debug.DrawRay(new Vector3(-0.3f, 0.5f, -1), Vector3.forward * 2, Color.red);
        //Debug.DrawRay(posTemp, Vector3.up * 2, Color.red);
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
