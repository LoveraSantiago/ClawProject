using UnityEngine;

public class PrefabDeMateriaisDto : MonoBehaviour
{
    [SerializeField] private Material materialGrayScale;
    [SerializeField] private Material materialOutline;
    [SerializeField] private Material materialTroca;
    [SerializeField] private Material materialLed;

    public Material MaterialGrayScale { get { return materialGrayScale; } }
    public Material MaterialOutline   { get { return materialOutline; } }
    public Material MaterialTroca     { get { return materialTroca; } }
    public Material MaterialLed       { get { return materialLed; } }
    
}
