using UnityEngine;

public class AnimacaoDisplayColetado 
{
    private static readonly int IDLE           = Animator.StringToHash("idle");
    private static readonly int MIRAR_ON       = Animator.StringToHash("mira-on");
    private static readonly int MIRAR_SELECTED = Animator.StringToHash("mira-selected");

    private Animator animator;
    public bool isMiraLigado { get; private set; }

    public AnimacaoDisplayColetado(Animator animator)
    {
        this.animator = animator;
    }

    public void ligarAnimacaoMira()
    {
        animator.Play(MIRAR_ON);
        isMiraLigado = true;
    }

    //public void ligarAnimacaoMiraSelecionado()
    //{
    //    //Debug.Log("Mira Selecionada");
    //    animator.Play(MIRAR_SELECTED);        
    //}

    public void desligarAnimacao()
    {
        //Debug.Log("Idle Chamado");
        animator.Play(IDLE);
        isMiraLigado = false;
    }    
}
