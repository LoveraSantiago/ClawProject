using UnityEngine;
using UnityEngine.UI;

#pragma warning disable 0649
[System.Serializable]
public class CanvasDetalheColetavelDto 
{
    [SerializeField] private Animator animatorCanvas;
    [SerializeField] private Image imgDetalhe;

    public Animator AnimatorCanvas { get { return animatorCanvas; } }
    public Image ImgDetalhe { get { return imgDetalhe; } }
}
