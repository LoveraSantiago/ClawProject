using System.Collections.Generic;
using UnityEngine.UIElements;

public class DropDownLevels 
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
                int[,] coletaveis = level.getArrayDeColetaveis();
                remontador.montarColetaveis(coletaveis);

                onDropDownSelected(level);                
            }
        });

        root.Q<VisualElement>("espacoDropDown")
               .Add(dropDownField);
    }

    protected virtual void onDropDownSelected(AbstractLevel level) { }
}
