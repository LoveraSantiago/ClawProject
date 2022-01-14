using System.Collections.Generic;
using UnityEngine.UIElements;

public class DropDownLevels 
{
    public void criarComponentDropDownField(
       VisualElement root, BoardCleanerPositivo cleaner, RemontadorBoard remontador)
    {
        List<string> listaDeLevels = LevelHelper.getNormalLevelsAlias();
        Preenchedor preenchedor = new Preenchedor();
        DropdownField dropDownField = new DropdownField("Dicionarios", listaDeLevels, 0);
        dropDownField.RegisterCallback<ChangeEvent<string>>((evt) => {

            cleaner.clean();

            if (evt.newValue != "0")
            {
                AbstractLevel level = LevelHelper.getLevelByString(evt.newValue);
                int[,] coletaveis = level.getArrayDeColetaveis();
                remontador.montarColetaveis(coletaveis, (go, spr) => preenchedor.colocarSprite(go, spr));

                BoardOrdem[] ordens = LevelUtils.getBoardOrdensFromLevelOrdenado(level);
                remontador.montarLabels(ordens);
            }
        });

        root.Q<VisualElement>("espacoDropDown")
               .Add(dropDownField);
    }
}
