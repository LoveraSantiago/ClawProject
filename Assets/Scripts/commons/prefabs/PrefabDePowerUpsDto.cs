using UnityEngine;

public class PrefabDePowerUpsDto : MonoBehaviour
{
    [SerializeField] private PowerUpPrefabDto[] powerUpDto;
    [Space(5)]
    [SerializeField] private MaterialsPowerUpDto materiaisPup;
    

    public PowerUpPrefabDto[] PowerUpDtos { get { return powerUpDto; } }
    public MaterialsPowerUpDto MateriaisPup { get { return materiaisPup; } }
}
