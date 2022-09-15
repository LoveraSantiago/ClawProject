using System.Collections.Generic;
using UnityEngine.UIElements;
using UnityEngine;

public abstract class DropDownLevels 
{
    private List<string> listaDeLevels;
    private ListaDeSprites listaDeSprites;

    private DropdownField dropDownLevels;
    private DropdownField dropDownMapas;

    public DropDownLevels(ListaDeSprites listaDeSprites)
    {
        this.listaDeLevels = EditorLevelHelper.listaEmpty;
        this.listaDeSprites = listaDeSprites;
    }   

    public void criarComponentesDropDowns(VisualElement root, BoardCleaner cleaner, RemontadorBoard remontador)
    {
        criarComponenteDropDownField(root, cleaner, remontador);
        criarComponenteDropDownMapas(root, cleaner, remontador);
    }

    public void resetDropDowns()
    {
        dropDownLevels.index = 0;
        dropDownMapas.index = 0;
    }

    private void criarComponenteDropDownField(
       VisualElement root, BoardCleaner cleaner, RemontadorBoard remontador)
    {   
        dropDownLevels = new DropdownField("Dicionarios", listaDeLevels, 0);        
        dropDownLevels.RegisterCallback<ChangeEvent<string>>((evt) => {

            cleaner.clean();

            if (!"0".Equals(evt.newValue) && !"-".Equals(evt.newValue))
            {                
                AbstractLevel level = EditorLevelHelper.getLevelByNameIndice(dropDownMapas.value, evt.newValue);
                int[,] coletaveis = getArrayParaOBoard(level);
                remontador.montarColetaveis(coletaveis);

                onDropDownSelected(level, remontador);                
            }
        });

        root.Q<VisualElement>("espacoDropDown")
               .Add(dropDownLevels);
    }    

    private void criarComponenteDropDownMapas(
        VisualElement root, BoardCleaner cleaner, RemontadorBoard remontador)
    {
        List<string> listaDeMapas = EditorLevelHelper.listaDeNomesMapas;
        dropDownMapas = new DropdownField("Mapas", listaDeMapas, 0);

        dropDownMapas.RegisterCallback<ChangeEvent<string>>((evt) => {

            cleaner.clean();
            listaDeSprites.limparTodaLista();

            if (!"0".Equals(evt.newValue) && !"-".Equals(evt.newValue) && !"DEFAULTS".Equals(evt.newValue))
            {
                MapaEnum mapaEnum = Mapas.getMapaEnumByName(evt.newValue);
                MapaEntidade mapaEntidade = FactoryMapaEntidade.getMapaEntidadeByMapaEnum(mapaEnum);
                ContextoEstaticoUtils.configMapaEntidade(mapaEntidade);
                ColetavelEntidade[] coletaveis = mapaEntidade.getColetaveis();                
                
                for(int contador = 0; contador < coletaveis.Length; contador++)
                {   
                    ColetavelEntidade coletavelIt = coletaveis[contador];
                    listaDeSprites.receberSprite(coletavelIt.sprite);
                }                
                dropDownLevels.choices = getListaBy(mapaEntidade);
                dropDownLevels.index = 0;
            }
        });

            root.Q<VisualElement>("espacoDropDownMapas")
               .Add(dropDownMapas);
    }

    protected abstract int[,] getArrayParaOBoard(AbstractLevel level);

    protected abstract void onDropDownSelected(AbstractLevel level, RemontadorBoard remontador);

    protected abstract List<string> getListaBy(MapaEntidade mapaEntidade);
}
