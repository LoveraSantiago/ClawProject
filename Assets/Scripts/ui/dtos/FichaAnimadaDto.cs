using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class FichaAnimadaDto 
{
    [Space(3)]
    [SerializeField] private Animator animatorFicha;
    [SerializeField] private Transform[] posFichas = new Transform[3];

    public Transform[] PosFichas { get { return posFichas; } }
    public Animator AnimatorFicha { get { return animatorFicha; } }
}
