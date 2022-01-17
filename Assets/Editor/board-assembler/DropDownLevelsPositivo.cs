using System.Collections.Generic;

public class DropDownLevelsPositivo : DropDownLevels
{
    private RemontadorLabelsBoard remontador;

    public DropDownLevelsPositivo(List<string> listaDeLevels, RemontadorLabelsBoard remontador) 
        : base(listaDeLevels)
    {
        this.remontador = remontador;
    }

    protected override void onDropDownSelected(AbstractLevel level)
    {
        BoardOrdem[] ordens = LevelUtils.getBoardOrdensFromLevelOrdenado(level);
        remontador.montarLabels(ordens);
    }
}
