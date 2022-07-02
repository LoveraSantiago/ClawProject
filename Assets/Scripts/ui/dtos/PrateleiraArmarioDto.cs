using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class PrateleiraArmarioDto 
{
    [SerializeField] private RectTransform rectTransformPrateleira;
    [SerializeField] private ItemPrateleiraDto[] itensPrateleira;

    public RectTransform RectTransformPrateleira { get { return rectTransformPrateleira; } }
    public ItemPrateleiraDto[] ItensPrateleira { get { return itensPrateleira; } }
}
