using UnityEngine;
//TODO dupla responsabilidade. ifs para 2 estados - RUIM
public class MovimentacaoLateralTeleguiada : MovimentacaoDaGarraNormal
{
    private bool aceitarClique;
    private bool moverLateralmente;

    private float posicaoDoToque;
    private int direcao;

    public MovimentacaoLateralTeleguiada()
    {
        posInicial = garraDto.RigidBody.transform.localPosition;
    }

    public override void preInicio() {
        aceitarClique = true;
        moverLateralmente = false;        
    }

    public override void update() {
        //TEMPORARIAMENTE AQUI ... PEGAR TOQUE NA TELA
        if (aceitarClique && inputGame.aconteceuTapNaAreaSuperior()) {

            RaycastHit2D raycastHit;
            int layerMask = LayerMask.GetMask("Coletavel");

            Vector3 posicaoClicada = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            posicaoClicada.z = 0;

            raycastHit = Physics2D.Raycast(posicaoClicada, Vector3.up, 2, layerMask);
            if (raycastHit.collider != null) {
                AudioController.current.PlayAudioGarra();
                posicaoDoToque = posicaoClicada.x;
                aceitarClique = false;
                moverLateralmente = true;
            }
        }
    }

    //TODO SE FOR USAR CLASSE REVER A FORMA DE MOVIMENTACAO DA GARRA DEPRECIADA ABAIXO
    public override void fixedUpdate() {
        if (moverLateralmente) {
            if (posicaoDoToque >= 0) {
                if (garraDto.RigidBody.transform.localPosition.x < Mathf.Min(posicaoDoToque, LIMITE_LATERAL_TELA))//REFATORAR COMPLEXIDADE
                {
                    garraDto.RigidBody.velocity = new Vector2(
                        1 * garraDto.VelocMovHorizontal * Time.fixedDeltaTime,
                        garraDto.RigidBody.velocity.y);
                } else {                    
                    comunicadorComGerMovimentacao.trocarParaAcaoDescendo();
                }
            } else {
                if (garraDto.RigidBody.transform.localPosition.x > Mathf.Max(posicaoDoToque, -LIMITE_LATERAL_TELA))//REFATORAR COMPLEXIDADE
                {
                    garraDto.RigidBody.velocity = new Vector2(
                        -1 * garraDto.VelocMovHorizontal * Time.fixedDeltaTime,
                        garraDto.RigidBody.velocity.y);
                } else {                    
                    comunicadorComGerMovimentacao.trocarParaAcaoDescendo();
                }
            }
        }
    }



}
