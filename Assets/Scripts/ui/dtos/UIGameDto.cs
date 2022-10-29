using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class UIGameDto 
{
    [SerializeField] private float delayAbrirModal;
    [Space(5)]
    [SerializeField] private ModalPontosDto modalPontosDto;
    [Space(5)]
    [SerializeField] private ModalSairDto modalSairDto;
    [Space(5)]
    [SerializeField] private ModalCacaNiquelDto modalCacaNiquelDto;
    [Space(5)]
    [SerializeField] private ModalColetaveisDto modalColetaveisDto;
    [Space(5)]
    [SerializeField] private ModalFailGameDto modalFailGameDto;

    public float DelayAbrirModal { get { return delayAbrirModal; } }
    public ModalPontosDto ModalPontosDto { get { return modalPontosDto; } }
    public ModalSairDto ModalSairDto { get { return modalSairDto; } }    
    public ModalCacaNiquelDto ModalCacaNiquelDto { get { return modalCacaNiquelDto; } }
    public ModalColetaveisDto ModalColetaveisDto { get { return modalColetaveisDto; } }
    public ModalFailGameDto ModalFailOrdem { get { return modalFailGameDto; } }
}
