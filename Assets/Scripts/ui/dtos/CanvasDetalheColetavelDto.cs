using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class CanvasDetalheColetavelDto 
{
    [SerializeField]private Animator animatorCanvas;

    public Animator AnimatorCanvas { get { return animatorCanvas; } }
}
