using System.Collections.Generic;
using UnityEngine.UIElements;
using UnityEngine;

public abstract class DropDownLevels 
{
    private List<string> listaDeLevels;
    private ListaDeSprites listaDeSprites;

    private DropdownField dropDownLevels;
    private DropdownField dropDownFamilia;

    public DropDownLevels(List<string> listaDeLevels, ListaDeSprites listaDeSprites)
    {
        this.listaDeLevels = listaDeLevels;
        this.listaDeSprites = listaDeSprites;
    }

    public void criarComponentesDropDowns(VisualElement root, BoardCleaner cleaner, RemontadorBoard remontador)
    {
        criarComponenteDropDownField(root, cleaner, remontador);
        criarComponenteDropDownFamilias(root, cleaner, remontador);
    }

    public void resetDropDowns()
    {
        dropDownLevels.index = 0;
        dropDownFamilia.index = 0;
    }

    private void criarComponenteDropDownField(
       VisualElement root, BoardCleaner cleaner, RemontadorBoard remontador)
    {   
        dropDownLevels = new DropdownField("Dicionarios", listaDeLevels, 0);        
        dropDownLevels.RegisterCallback<ChangeEvent<string>>((evt) => {

            cleaner.clean();

            if (!"0".Equals(evt.newValue) && !"-".Equals(evt.newValue))
            {
                AbstractLevel level = LevelHelper.getLevelByString(evt.newValue);
                int[,] coletaveis = getArrayParaOBoard(level);
                remontador.montarColetaveis(coletaveis);

                onDropDownSelected(level, remontador);                
            }
        });

        root.Q<VisualElement>("espacoDropDown")
               .Add(dropDownLevels);
    }    

    private void criarComponenteDropDownFamilias(
        VisualElement root, BoardCleaner cleaner, RemontadorBoard remontador)
    {
        List<string> listaDeFamilia = EditorLevelHelper.listaDeNomesMapas;
        dropDownFamilia = new DropdownField("Familias", listaDeFamilia, 0);

        dropDownFamilia.RegisterCallback<ChangeEvent<string>>((evt) => {

            cleaner.clean();
            listaDeSprites.limparTodaLista();

            if (!"0".Equals(evt.newValue) && !"-".Equals(evt.newValue) && !"DEFAULTS".Equals(evt.newValue))
            {
                MapaEnum mapaEnum = Mapas.getMapaEnumByName(evt.newValue);
                List<ColetavelEntidade>  listaDeColetaveis = HelperColetavelEntidade.getListaDeColetaveisEntidadeByFamilia(mapaEnum);
                MapaEntidade mapaEntidade = HelperMapaEntidade.getMapaEntidadeByMapaEnum(mapaEnum);
                for(int contador = 0; contador < listaDeColetaveis.Count; contador++)
                {
                    string nomeSprite = listaDeColetaveis[contador].nomeSprite;
                    string spriteFileName = mapaEntidade.getRootPathSprites() + nomeSprite;                    
                    Sprite sprite = Resources.Load<Sprite>(spriteFileName);
                    listaDeSprites.receberSprite(sprite);
                }
            }
        });

            root.Q<VisualElement>("espacoDropDownFamilias")
               .Add(dropDownFamilia);
    }

    protected abstract int[,] getArrayParaOBoard(AbstractLevel level);

    protected abstract void onDropDownSelected(AbstractLevel level, RemontadorBoard remontador);
}
