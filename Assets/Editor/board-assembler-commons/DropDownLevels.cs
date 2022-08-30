using System.Collections.Generic;
using UnityEngine.UIElements;

public abstract class DropDownLevels 
{
    private List<string> listaDeLevels;

    public DropDownLevels(List<string> listaDeLevels)
    {
        this.listaDeLevels = listaDeLevels;
    }

    public void criarComponentDropDownField(
       VisualElement root, BoardCleaner cleaner, RemontadorBoard remontador)
    {   
        DropdownField dropDownField = new DropdownField("Dicionarios", listaDeLevels, 0);
        dropDownField.RegisterCallback<ChangeEvent<string>>((evt) => {

            cleaner.clean();

            if (evt.newValue != "0" && evt.newValue != "-")
            {
                AbstractLevel level = LevelHelper.getLevelByString(evt.newValue);
                int[,] coletaveis = getArrayParaOBoard(level);
                remontador.montarColetaveis(coletaveis);

                onDropDownSelected(level, remontador);                
            }
        });

        root.Q<VisualElement>("espacoDropDown")
               .Add(dropDownField);
    }

    public void criarComponenteDropDownFamilias(
        VisualElement root, BoardCleaner cleaner, RemontadorBoard remontador, ListaDeSprites listaDeSprites)
    {
        List<string> listaDeFamilia = MapaEntidade.getTodosOsMapasAsListString();
        DropdownField dropDownField = new DropdownField("Familias", listaDeFamilia, 0);

        dropDownField.RegisterCallback<ChangeEvent<string>>((evt) => {

            cleaner.clean();
            listaDeSprites.limparTodaLista();

            if (evt.newValue != "0" && evt.newValue != "-")
            {
                
            }
        });

            root.Q<VisualElement>("espacoDropDownFamilias")
               .Add(dropDownField);
    }

    protected abstract int[,] getArrayParaOBoard(AbstractLevel level);

    protected abstract void onDropDownSelected(AbstractLevel level, RemontadorBoard remontador);
}
