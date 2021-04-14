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

        posInicial = garraDto.RigidBody.transform.localPosition;
    }

    public override void preInicio()
    {
        aceitarClique = true;        
        actionFixedUpdate = actionFixedUpdateZigZague;
    }

    public override void update()
    {
        //TEMPORARIAMENTE AQUI ... PEGAR TOQUE NA TELA
        if (aceitarClique && inputGame.aconteceuTapNaAreaSuperior())
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

        garraDto.RigidBody.velocity = new Vector2(
            direcao * garraDto.VelocMovHorizontal * Time.fixedDeltaTime,
            garraDto.RigidBody.velocity.y);
    }

    //TODO SE FOR USAR CLASSE REVER A FORMA DE MOVIMENTACAO DA GARRA DEPRECIADA ABAIXO
    //TODO duplicidade com MovimentacaoLateralTeleguiada
    public void fixedUpdateTeleguiado()
    {
        //if (moverLateralmente)
        //{
            if (posicaoDoToque >= 0)
            {
                if (garraDto.RigidBody.transform.localPosition.x < Mathf.Min(posicaoDoToque, LIMITE_LATERAL_TELA))//REFATORAR COMPLEXIDADE
                {
                    garraDto.RigidBody.velocity = new Vector2(
                        1 * garraDto.VelocMovHorizontal * Time.fixedDeltaTime,
                        garraDto.RigidBody.velocity.y);
                }
                else
                {   
                    comunicadorComGerMovimentacao.trocarParaAcaoDescendo();
                }
            }
            else
            {
                if (garraDto.RigidBody.transform.localPosition.x > Mathf.Max(posicaoDoToque, -LIMITE_LATERAL_TELA))//REFATORAR COMPLEXIDADE
                {
                    garraDto.RigidBody.velocity = new Vector2(
                        -1 * garraDto.VelocMovHorizontal * Time.fixedDeltaTime,
                        garraDto.RigidBody.velocity.y);
                }
                else
                {                    
                    comunicadorComGerMovimentacao.trocarParaAcaoDescendo();
                }
            }
        //}
    }

    //TODO duplicidade com MovimentacaoLateralZigZag
    private void verificarSeMovimentacaoAtingiuLimites()
    {
        if (garraDto.RigidBody.transform.localPosition.x > LIMITE_LATERAL_TELA)
        {
            direcao = -1;
            diminuirInerciaDaGarra();
        }
        else if (garraDto.RigidBody.transform.localPosition.x < -LIMITE_LATERAL_TELA)
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
