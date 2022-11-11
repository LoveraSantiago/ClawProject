using UnityEngine;

public class GarraTitle 
{
    private static readonly int INTRO_MACHO = Animator.StringToHash("intro-macho");
    private static readonly int INTRO_FEMEA = Animator.StringToHash("intro-femea");
    private static readonly int ANIMACAO1_MACHO = Animator.StringToHash("macho-piscando");
    private static readonly int ANIMACAO1_FEMEA = Animator.StringToHash("femea-coracao");
        
    private int ANIMACAO1;
    private Animator animator;

    public GarraTitle(Genero genero, Animator animator)
    {
        this.animator = animator;
        if (GeneroUtils.isGeneroMacho(genero))
        {
            ANIMACAO1 = ANIMACAO1_MACHO;
            animator.Play(INTRO_MACHO);
        }
        else
        {
            ANIMACAO1 = ANIMACAO1_FEMEA;
            animator.Play(INTRO_FEMEA);
        }
    }

    public void playAnimacao()
    {
        animator.Play(ANIMACAO1);
    }
}
