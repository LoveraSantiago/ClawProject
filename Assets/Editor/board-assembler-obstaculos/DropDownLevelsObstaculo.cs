using System.Collections.Generic;

public class DropDownLevelsObstaculo : DropDownLevels
{
    public DropDownLevelsObstaculo(List<string> listaDeLevels) : base(listaDeLevels)
    {
    }

    protected override int[,] getArrayParaOBoard(AbstractLevel level)
    {
        throw new System.NotImplementedException();
    }

    protected override void onDropDownSelected(AbstractLevel level, RemontadorBoard remontador)
    {
        throw new System.NotImplementedException();
    }
}
