using System.Collections.Generic;

public class DropDownLevelsObstaculo : DropDownLevels
{
    public DropDownLevelsObstaculo(List<string> listaDeLevels) 
        : base(listaDeLevels){}

    protected override int[,] getArrayParaOBoard(AbstractLevel level)
    {
        return level.getArrayDeColetaveis();
    }

    protected override void onDropDownSelected(AbstractLevel level, RemontadorBoard remontador)
    {
        bool[,] obstaculos = LevelUtils.getArrayDeObstaculos(level);
        ((ControleObstaculos)remontador).montarObstaculos(obstaculos);
    }
}
