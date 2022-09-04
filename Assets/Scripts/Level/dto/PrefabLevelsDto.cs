using UnityEngine;

#pragma warning disable 0649
public class PrefabLevelsDto : MonoBehaviour
{
    [SerializeField] private LevelMapDto[] levelsMapDto;

    public LevelMapDto[] getLevelsMapDto()
    {
        int limite = PlayerPrefsMapas.getMapaMaxLevelIndice();
        int maxIndice = limite + 2;
        maxIndice = Mathf.Min(maxIndice, levelsMapDto.Length);

        LevelMapDto[] levelsMapsLimitado = new LevelMapDto[maxIndice];
        for(int contador = 0; contador < levelsMapsLimitado.Length; contador++)
        {
            levelsMapsLimitado[contador] = levelsMapDto[contador];
        }
        return levelsMapsLimitado;
    }

}
