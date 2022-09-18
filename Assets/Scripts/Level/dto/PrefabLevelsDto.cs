using UnityEngine;

//CANDIDATO A SER SINGLETO VER CONSUMO E QTD DE VEZES Q É INSTANCIADO
#pragma warning disable 0649
public class PrefabLevelsDto : MonoBehaviour
{
    [SerializeField] private LevelMapDto[] levelsMapDto;

    public LevelMapDto[] getLevelsMapLiberadosDto(int adicao)
    {
        int limite = PlayerPrefsMapas.getIndiceMapaLiberado();
        int maxIndice = limite + adicao;
        maxIndice = Mathf.Min(maxIndice, levelsMapDto.Length);

        LevelMapDto[] levelsMapsLimitado = new LevelMapDto[maxIndice];
        for(int contador = 0; contador < levelsMapsLimitado.Length; contador++)
        {
            levelsMapsLimitado[contador] = levelsMapDto[contador];
        }
        return levelsMapsLimitado;
    }

    public LevelMapDto getLevelMapByEnum(MapaEnum mapaEnum)
    {
        for (int contador = 0; contador < levelsMapDto.Length; contador++){
            LevelMapDto levelMapDtoIt = levelsMapDto[contador];
            if(levelMapDtoIt.MapaEnum == mapaEnum)
            {
                return levelMapDtoIt;
            }
        }
        return null;
    }

}
