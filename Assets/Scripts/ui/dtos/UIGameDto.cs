using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class UIGameDto 
{
    [Space(5)]
    [SerializeField] private ModalPontosDto modalPontosDto;
    [Space(5)]
    [SerializeField] private ModalSairDto modalSairDto;
    [Space(5)]
    [SerializeField] private ModalCacaNiquelDto modalCacaNiquelDto;

    public ModalPontosDto ModalPontosDto { get { return modalPontosDto; } }
    public ModalSairDto ModalSairDto { get { return modalSairDto; } }    
    public ModalCacaNiquelDto ModalCacaNiquelDto { get { return modalCacaNiquelDto; } }
}
