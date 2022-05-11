using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class EfeitoHologramaBtnPupDto 
{
    [SerializeField] private Transform transfMainEfeito;
    [SerializeField] private MeshRenderer meshRendererEfeitoHorizontal;
    [SerializeField] private MeshRenderer meshRendererEfeitoVertical;    

    public Transform TransfMainEfeito { get { return transfMainEfeito; } }
    public GameObject GoMainEfeito { get { return transfMainEfeito.gameObject; } }

    public MeshRenderer MeshRendererEfeitoHorizontal { get { return meshRendererEfeitoHorizontal; } }
    public GameObject GoEfeitoHorizontal { get { return meshRendererEfeitoHorizontal.gameObject; } }

    public MeshRenderer MeshRendererEfeitoVertical   { get { return meshRendererEfeitoVertical; } }
    public GameObject GoEfeitoVertical  { get { return meshRendererEfeitoVertical.gameObject; } }
}
