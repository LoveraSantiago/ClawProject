using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;
using System.Collections;
using System.Collections.Generic;
using System;

public class ListaDeSprites 
{
    private ListView listView;
    private List<Sprite> listaDeSprites;
    private Action<Sprite> consumidorDeSprite;

    public ListaDeSprites(VisualElement root, StyleSheet styleSheet, Action<Sprite> consumidorDeSprite)
    {
        this.consumidorDeSprite = consumidorDeSprite;
        inicializarLista();
        inicializarListView(root, styleSheet);
    }

    private void inicializarLista()
    {
        listaDeSprites = new List<Sprite>();
        listaDeSprites.Add(Resources.Load<Sprite>("Sprites/collectables/tile-vazio"));
        listaDeSprites.Add(Resources.Load<Sprite>("Sprites/collectables/tile-random"));
    }

    private void inicializarListView(VisualElement root, StyleSheet styleSheet)
    {
        listView = new ListView();
        listView.name = "listViewSprites";
        listView.itemsSource = listaDeSprites;
        listView.makeItem = () => funcMakeItem();
        listView.bindItem = (e, i) => actionBindItem(e, i);
        listView.selectionType = SelectionType.Single;
        listView.styleSheets.Add(styleSheet);
        listView.onSelectionChange += objects => {
            //Debug.Log("onSelectionChange: " + objects);
            //Debug.Log("onSelectionChange: " + objects.GetEnumerator());
            //objects[0]//PEGA o SPRITE    

            //IEnumerator<object> enumerator = objects.GetEnumerator();
            Sprite spr = (Sprite)((List<System.Object>)objects)[0];

            consumidorDeSprite.Invoke(spr);
            //colocarSprite(navegacao.getGoDaMira(), spr);
        };
        root.Add(listView);
    }

    private VisualElement funcMakeItem()
    {
        Image image = new Image();
        Label label = new Label();

        VisualElement visualElement = new VisualElement();
        visualElement.AddToClassList("veLinha");
        visualElement.Add(image);
        visualElement.Add(label);
        return visualElement;
    }

    private void actionBindItem(VisualElement e, int i)
    {
        VisualElement visualElement = e;
        Image image = visualElement.Q<Image>();
        image.style.backgroundImage = new StyleBackground(listaDeSprites[i].texture);
        Label label = visualElement.Q<Label>();
        label.text = listaDeSprites[i].name;
    }

    public void receberSprite(Sprite sprite)
    {
        listaDeSprites.Add(sprite);
        listView.Refresh();
    }

    public void removerUltimaLinha()
    {
        if(listaDeSprites.Count > 2)
        {
            listaDeSprites.RemoveAt(listaDeSprites.Count - 1);

            listView.Refresh();
        }
    }

    public void limparTodaLista()
    {
        while(listaDeSprites.Count > 2)
        {
            removerUltimaLinha();
        }
        listView.Refresh();
    }

    public Sprite getSpriteVazio()
    {
        return listaDeSprites[0];
    }
}
