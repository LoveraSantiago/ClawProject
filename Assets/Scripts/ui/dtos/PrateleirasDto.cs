using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class PrateleirasDto 
{
    [SerializeField] private int qtdPrateleirasVisiveis;
    [Space(3)]
    [SerializeField] private RectTransform rTransformRefCima;
    [SerializeField] private RectTransform rTransformRefBaixo;
    [Space(3)]
    [SerializeField] private RectTransform rTransformArmario;
    [SerializeField] private PrateleiraArmarioDto[] prateleiraDto;
    [Space(3)]
    [SerializeField] private RectTransform rPrateleiraBottom;

    public PrateleiraArmarioDto[] PrateleiraDto { get { return prateleiraDto; } }

    public RectTransform RTransformRefCima { get { return rTransformRefCima; } }
    public RectTransform RTransformRefBaixo { get { return rTransformRefBaixo; } }

    public RectTransform RTransformArmario { get { return rTransformArmario; } }
    public int QtdPrateleirasVisiveis { get { return qtdPrateleirasVisiveis; } }

    public RectTransform RPrateleiraBottom { get { return rPrateleiraBottom; } }
}
