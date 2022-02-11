using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class PartesMaquinaDto 
{
    [SerializeField] private SpriteRenderer placaCima;
    [SerializeField] private SpriteRenderer baseParteCima;
    [SerializeField] private SpriteRenderer baseParteBaixo;
    [SerializeField] private SpriteRenderer baseChao;    
    [SerializeField] private SpriteRenderer placaFrontal;    
    [SerializeField] private SpriteRenderer placaSaida;
    [SerializeField] private SpriteRenderer placaFicha;
    [SerializeField] private SpriteRenderer placaParteCima;
    [SerializeField] private SpriteRenderer placaParteBaixo;
    [SerializeField] private SpriteRenderer quadMaior;
    [SerializeField] private SpriteRenderer quadMenor;
    [SerializeField] private SpriteRenderer furoCima;
    [SerializeField] private SpriteRenderer furoBaixo;    

    public SpriteRenderer PlacaCima { get { return placaCima; } }
    public SpriteRenderer BaseParteCima { get { return baseParteCima; } }
    public SpriteRenderer BaseParteBaixo { get { return baseParteBaixo; } }
    public SpriteRenderer BaseChao { get { return baseChao; } }    
    public SpriteRenderer PlacaFrontal { get { return placaFrontal; } }         
    public SpriteRenderer PlacaDeSaida { get { return placaSaida; } }
    public SpriteRenderer PlacaFicha { get { return placaFicha; } }
    public SpriteRenderer PlacaParteCima { get { return placaParteCima; } }
    public SpriteRenderer PlacaParteBaixo { get { return placaParteBaixo; } }
    public SpriteRenderer QuadMaior { get { return quadMaior; } }
    public SpriteRenderer QuadMenor { get { return quadMenor; } }
    public SpriteRenderer FuroCima { get { return furoCima; } }
    public SpriteRenderer FuroBaixo { get { return furoBaixo; } }
}
