using System;
using UnityEngine;

public class MovimentacaoLateralZigTeleguiado : MovimentacaoDaGarraHorizontal
{
    private float direcao;
    private bool aceitarClique;

    private float posicaoDoToque;

    private Action actionFixedUpdate;
    private Action actionFixedUpdateZigZague;
    private Action actionFixedUpdateTeleguiado;

    public MovimentacaoLateralZigTeleguiado()
    {        
        direcao = 1;

        actionFixedUpdateTeleguiado = () => fixedUpdateTeleguiado();
        actionFixedUpdateZigZague = () => fixedUpdateZigZag();
    }

    public override void preInicio()
    {
        aceitarClique = true;        
        actionFixedUpdate = actionFixedUpdateZigZague;
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

                actionFixedUpdate = actionFixedUpdateTeleguiado;
            }
        }
    }

    public override void fixedUpdate()
    {
        actionFixedUpdate.Invoke();
    }

    public void fixedUpdateZigZag()
    {
        verificarSeMovimentacaoAtingiuLimites();

        compDaGarra.RigidBody.velocity = new Vector2(
            direcao * compDaGarra.VelocMovHorizontal * Time.fixedDeltaTime,
            compDaGarra.RigidBody.velocity.y);
    }

    //TODO duplicidade com MovimentacaoLateralTeleguiada
    public void fixedUpdateTeleguiado()
    {
        //if (moverLateralmente)
        //{
            if (posicaoDoToque >= 0)
            {
                if (compDaGarra.RigidBody.transform.localPosition.x < Mathf.Min(posicaoDoToque, LIMITE_LATERAL_TELA))//REFATORAR COMPLEXIDADE
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
        //}
    }

    //TODO duplicidade com MovimentacaoLateralZigZag
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
