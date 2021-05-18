using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class PartesMaquinaDto 
{
    [SerializeField] private SpriteRenderer placaCima;
    [SerializeField] private SpriteRenderer baseParteCima;
    [SerializeField] private SpriteRenderer baseParteBaixo;
    [SerializeField] private SpriteRenderer baseChao;
    [SerializeField] private SpriteRenderer bordaVidro;
    [SerializeField] private SpriteRenderer placaFrontal;
    [SerializeField] private SpriteRenderer barra;
    [SerializeField] private SpriteRenderer chaoDentro;
    [SerializeField] private SpriteRenderer tubo;
    [SerializeField] private SpriteRenderer vigaTrasEsquerda;
    [SerializeField] private SpriteRenderer vigaTrasDireita;
    [SerializeField] private SpriteRenderer placaFicha;

    

    public SpriteRenderer PlacaCima { get { return placaCima; } }
    public SpriteRenderer BaseParteCima { get { return baseParteCima; } }
    public SpriteRenderer BaseParteBaixo { get { return baseParteBaixo; } }
    public SpriteRenderer BaseChao { get { return baseChao; } }
    public SpriteRenderer BordaVidro { get { return bordaVidro; } }
    public SpriteRenderer PlacaFrontal { get { return placaFrontal; } }
    public SpriteRenderer Barra { get { return barra; } }
    public SpriteRenderer ChaoDentro { get { return chaoDentro; } }
    public SpriteRenderer Tubo { get { return tubo; } }
    public SpriteRenderer VigaTrasEsquerda { get { return vigaTrasEsquerda; } }
    public SpriteRenderer VigaTrasDireita { get { return vigaTrasDireita; } }
}
