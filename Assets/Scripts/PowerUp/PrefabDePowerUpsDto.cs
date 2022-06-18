using UnityEngine;

public class PrefabDePowerUpsDto : MonoBehaviour
{
    [SerializeField] private PowerUpPrefabDto[] powerUpDto;

    public PowerUpPrefabDto[] PowerUpDtos { get { return powerUpDto; } }
}
