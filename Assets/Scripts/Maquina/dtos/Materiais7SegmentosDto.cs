using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class Materiais7SegmentosDto 
{
    [SerializeField] private Material mat7SegmentosAditivos;
    [SerializeField] private Material mat7SegmentosAlpha;

    public Material Mat7SegmentosAditivos { get { return mat7SegmentosAditivos; } }
    public Material Mat7SegmentosAlpha { get { return mat7SegmentosAlpha; } }

    public Material getMaterialFromAlbedo(bool albedo)
    {
        if (albedo) return Mat7SegmentosAditivos;
        else return Mat7SegmentosAlpha;
    }
}
