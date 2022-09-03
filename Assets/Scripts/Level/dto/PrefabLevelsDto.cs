using UnityEngine;

public class PrefabLevelsDto : MonoBehaviour
{
    [SerializeField] private LevelMapDto[] levelsMapDto;

    public LevelMapDto[] getLevelsMapDto(int limite)
    {
        LevelMapDto[] levelsMapsLimitado = new LevelMapDto[limite + 2];
        for(int contador = 0; contador < levelsMapsLimitado.Length; contador++)
        {
            levelsMapsLimitado[contador] = levelsMapDto[contador];
        }
        return levelsMapsLimitado;
    }

}
