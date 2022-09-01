using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabLevelsDto : MonoBehaviour
{
    [SerializeField] private LevelMapDto[] levelsMapDto;

    public LevelMapDto[] getLevelsMapDto()
    {
        return levelsMapDto;
    }

}
