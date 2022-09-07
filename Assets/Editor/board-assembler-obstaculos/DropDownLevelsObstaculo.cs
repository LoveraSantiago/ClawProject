using System.Collections.Generic;

public class DropDownLevelsObstaculo : DropDownLevels
{
    public DropDownLevelsObstaculo(List<string> listaDeLevels, ListaDeSprites listaDeSprites) 
        : base(listaDeLevels, listaDeSprites) {}

    protected override int[,] getArrayParaOBoard(AbstractLevel level)
    {
        return level.getArrayDeColetaveis();
    }

    protected override List<string> getListaBy(MapaEntidade mapaEntidade)
    {
        throw new System.NotImplementedException();
    }

    protected override void onDropDownSelected(AbstractLevel level, RemontadorBoard remontador)
    {
        bool[,] obstaculos = LevelUtils.getArrayDeObstaculos(level);
        ((ControleObstaculos)remontador).montarObstaculos(obstaculos);
    }
}
