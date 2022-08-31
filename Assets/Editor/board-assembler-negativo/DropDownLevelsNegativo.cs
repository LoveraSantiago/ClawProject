using System.Collections.Generic;

public class DropDownLevelsNegativo : DropDownLevels
{
    public DropDownLevelsNegativo(List<string> listaDeLevels, ListaDeSprites listaDeSprites)
        : base(listaDeLevels, listaDeSprites)
    {
    }

    protected override int[,] getArrayParaOBoard(AbstractLevel level)
    {        
        return ((AbstractLevelElevador)level).getArrayDeColetaveisSub();
    }

    protected override void onDropDownSelected(AbstractLevel level, RemontadorBoard remontador){}
}
