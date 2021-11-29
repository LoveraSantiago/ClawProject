using UnityEngine;

public class PrefabDeMateriaisDto : MonoBehaviour
{
    [SerializeField] private Material materialGrayScale;
    [SerializeField] private Material materialOutline;
    [SerializeField] private Material materialGlow;

    public Material MaterialGrayScale { get { return materialGrayScale; } }
    public Material MaterialOutline   { get { return materialOutline; } }
    public Material MaterialGlow      { get { return materialGlow; } }
}
