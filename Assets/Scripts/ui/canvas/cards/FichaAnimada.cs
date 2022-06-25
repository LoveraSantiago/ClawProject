using UnityEngine;

public class FichaAnimada 
{
    private static readonly int FICHA_GIRANDO = Animator.StringToHash("ficha-girando");
    private Animator animatorFicha; 

    public FichaAnimada(Animator animatorFicha)
    {
        this.animatorFicha = animatorFicha;
    }

    public void girarFicha(Vector3 posicao)
    {
        animatorFicha.gameObject.transform.position = posicao;
        animatorFicha.Play(FICHA_GIRANDO);
    }
}
