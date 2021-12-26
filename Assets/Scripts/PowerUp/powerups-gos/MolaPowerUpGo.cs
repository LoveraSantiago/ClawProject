using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MolaPowerUpGo : PowerUpNaoInteracaoComGarra
{
    private static readonly int IDLE = Animator.StringToHash("idle");
    private static readonly int JUMP = Animator.StringToHash("mola-jump");

    private static Vector3 posInicial;

    private Animator animator;
    private BoxCollider2D boxCollider2d;

    public MolaPowerUpGo() 
        : base(powerUpDto.MolaDto.MolaGo, "mola"){}

    public override void iniciarNaPosicao(Vector3 posicao)
    {
        posInicial = posicao;
    }

    public override void configurarPup()
    {
        Transform transformImg = goColetavel.transform.Find("imagem");
        animator = transformImg.GetComponent<Animator>();
        boxCollider2d = transformImg.GetComponent<BoxCollider2D>();
    }

    public override void iniciarPup()
    {
        ligar();
        posInicial.y = powerUpDto.HalturaPupDraggavel;
        base.colocarNaPosicao(posInicial);
        Utils.MonoBehaviour.StartCoroutine(jumpar());
    }

    public override void resetPup()
    {
        desligar();
        animator.Play(IDLE);
        powerUpFinalizacao.preFinalizar();
    }

    private IEnumerator jumpar()
    {
        yield return new WaitForSeconds(powerUpDto.MolaDto.DelayInicial);

        Collider2D[] result = new Collider2D[5];
        ContactFilter2D filter = new ContactFilter2D().NoFilter();
        //filter.SetLayerMask(LayerMask.NameToLayer("Coletavel"));
        boxCollider2d.OverlapCollider(filter, result);

        for(int i = 0; i < 5; i++)
        {
            Collider2D coliderIt = result[i];
            if(coliderIt != null)
            {
                int resultado;
                bool isNomeNumerico = int.TryParse(result[i].name, out resultado);
                if (isNomeNumerico)
                {
                    Debug.Log("Coletavel " + resultado);
                }
            }
            else
            {
                //Debug.Log("Collider " + i + " Nulo");
            }
        }
        //Debug.Log("Varredura completa");

        animator.Play(JUMP);

        yield return new WaitForSeconds(powerUpDto.MolaDto.DelayInicial * 5);

        resetPup();
        powerUpFinalizacao.finalizado();
        yield return null;
    }

    private string[] getNomeColetaveisColididosComMola()
    {
        return null;
    }
}
