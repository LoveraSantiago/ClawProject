using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class MaquinaDto
{
    [Space(5)]
    [SerializeField] DisplayDeColetadoDto displayDeColetadoDto;
    [Space(5)]
    [SerializeField] DisplayDeScoreDto displayDeScoreDto;    
    [SerializeField] private Transform hasteJoystick;

    public DisplayDeColetadoDto DisplayDeColetadoDto { get { return displayDeColetadoDto; } }
    public DisplayDeScoreDto DisplayDeScoreDto { get { return displayDeScoreDto; } }
    
    public Transform HasteJoystick { get { return hasteJoystick;  } }

}
