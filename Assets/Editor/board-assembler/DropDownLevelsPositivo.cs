using System.Collections.Generic;

public class DropDownLevelsPositivo : DropDownLevels
{
    public DropDownLevelsPositivo(List<string> listaDeLevels) 
        : base(listaDeLevels)
    {  
    }

    protected override int[,] getArrayParaOBoard(AbstractLevel level)
    {
        return level.getArrayDeColetaveis();
    }

    protected override void onDropDownSelected(AbstractLevel level, RemontadorBoard remontador)
    {
        BoardOrdem[] ordens = LevelUtils.getBoardOrdensFromLevelOrdenado(level);
        ((RemontadorLabelsBoard) remontador).montarLabels(ordens);
    }
}
