using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class PrateleiraArmarioDto 
{
    [SerializeField] private ItemPrateleiraDto[] itensPrateleira;

    public ItemPrateleiraDto[] ItensPrateleira { get { return itensPrateleira; } }
}
