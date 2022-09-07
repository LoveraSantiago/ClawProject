using System.Collections.Generic;

public class DropDownLevelsObstaculo : DropDownLevels
{
    public DropDownLevelsObstaculo(ListaDeSprites listaDeSprites) 
        : base(listaDeSprites) {}

    protected override int[,] getArrayParaOBoard(AbstractLevel level)
    {
        return level.getArrayDeColetaveis();
    }

    protected override List<string> getListaBy(MapaEntidade mapaEntidade)
    {
        return EditorLevelHelper.getListaDenomesLevelsObstaculos(mapaEntidade);
    }

    protected override void onDropDownSelected(AbstractLevel level, RemontadorBoard remontador)
    {
        bool[,] obstaculos = LevelUtils.getArrayDeObstaculos(level);
        ((ControleObstaculos)remontador).montarObstaculos(obstaculos);
    }
}
