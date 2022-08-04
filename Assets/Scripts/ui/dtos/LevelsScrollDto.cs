using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class LevelsScrollDto
{
    [SerializeField] private int qtdItensVisiveis;
    [Space(3)]
    [SerializeField] private RectTransform rTransformRefCima;
    [SerializeField] private RectTransform rTransformRefBaixo;
    [Space(3)]
    [SerializeField] private RectTransform rTransformScroll;
    [Space(3)]
    [SerializeField] private RectTransform[] rItens;

    public int QtdItensVisiveis { get { return qtdItensVisiveis; } }
    public RectTransform RTransformRefCima { get { return rTransformRefCima; } }
    public RectTransform RTransformRefBaixo { get { return rTransformRefBaixo; } }
    public RectTransform[] RItens { get { return rItens; } }
    public RectTransform RTransformScroll { get { return rTransformScroll; } }
}
