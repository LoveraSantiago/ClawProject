using UnityEngine;

#pragma warning disable 0649
public class PrefabDeMateriaisDto : MonoBehaviour
{
    [SerializeField] private Material materialGrayScale;
    [SerializeField] private Material materialOutline;
    [SerializeField] private Material materialTroca;        
    [SerializeField] private Material materialHdrAditivo;
    [SerializeField] private Material materialHdrAlpha;
    [SerializeField] private Material materialSprUnlitDefault;
    [SerializeField] private Material materialMaquina;

    public Material MaterialGrayScale { get { return materialGrayScale; } }
    public Material MaterialOutline   { get { return materialOutline; } }
    public Material MaterialTroca     { get { return materialTroca; } }    
    public Material MaterialHdrAditivo{ get { return materialHdrAditivo; } }    
    public Material MaterialHdrAlpha  { get { return materialHdrAlpha; } }    
    public Material MaterialSprUnlitDefault { get { return materialSprUnlitDefault; } }
    public Material MaterialMaquina   { get { return materialMaquina; } }
}
