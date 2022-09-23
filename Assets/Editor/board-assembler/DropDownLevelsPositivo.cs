using System.Collections.Generic;

public class DropDownLevelsPositivo : DropDownLevels
{
    public DropDownLevelsPositivo(ListaDeSprites listaDeSprites) 
        : base(listaDeSprites){}

    protected override int[,] getArrayParaOBoard(AbstractLevel level)
    {
        return level.getArrayDeColetaveis();
    }

    protected override List<string> getListaBy(MapaEntidade mapaEntidade)
    {
        return EditorLevelHelper.getListaDeNomesLevelsNaoObstaculo(mapaEntidade);
    }

    protected override void onDropDownSelected(AbstractLevel level, RemontadorBoard remontador)
    {
        BoardOrdem[] ordens = LevelUtils.getBoardOrdensFromLevelOrdenado(level);
        ((RemontadorLabelsBoard) remontador).montarLabels(ordens);
    }
}
