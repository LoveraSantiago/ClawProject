using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class LevelMapDto 
{
    [SerializeField] private MapaEnum mapaEnum;
    [Space(2)]
    [SerializeField] private Sprite sprMapa;
    [Space(2)]
    [SerializeField] private Vector2[] posicoes = new Vector2[10];
}
