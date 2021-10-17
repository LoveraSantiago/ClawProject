using UnityEngine;

public interface ItemsBottomBar 
{
    void configurarIndicePesquisado(int indice);

    int getQtdItems();

    string   getLabelQtdDoItem();
    Sprite   getSprDoItem();
    Material getMaterialDoItem();
    Color    getCorImgDoItem();
}
