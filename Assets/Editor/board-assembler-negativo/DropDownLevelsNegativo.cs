using System.Collections.Generic;

public class DropDownLevelsNegativo : DropDownLevels
{
    public DropDownLevelsNegativo(ListaDeSprites listaDeSprites)
        : base(listaDeSprites)
    {
    }

    protected override int[,] getArrayParaOBoard(AbstractLevel level)
    {        
        return ((AbstractLevelElevador)level).getArrayDeColetaveisSub();
    }

    protected override List<string> getListaBy(MapaEntidade mapaEntidade)
    {
        return EditorLevelHelper.getListaDenomesLevelsElevadores(mapaEntidade);
    }

    protected override void onDropDownSelected(AbstractLevel level, RemontadorBoard remontador){}
}
