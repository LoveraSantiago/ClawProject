using UnityEngine;

public class PrefabPowerUpDto : MonoBehaviour
{
    private static PrefabPowerUpDto instance;
    [SerializeField] private Sprite[] powerUpSprites;

    private void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public Sprite[] PowerUpSprites { get { return powerUpSprites; } }

    public static PrefabPowerUpDto getInstance()
    {
        return instance;
    }
}
