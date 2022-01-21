using System.Collections.Generic;
using UnityEngine;

public class DropDownLevelsNegativo : DropDownLevels
{
    public DropDownLevelsNegativo(List<string> listaDeLevels)
        : base(listaDeLevels)
    {
    }

    protected override int[,] getArrayParaOBoard(AbstractLevel level)
    {
        Debug.Log("dropdown negativo");
        return ((AbstractLevelElevador)level).getArrayDeColetaveisSub();
    }

    protected override void onDropDownSelected(AbstractLevel level, RemontadorBoard remontador){}
}
