using UnityEngine;

public interface ItemsBottomBar 
{
    int getQtdItems();

    string getLabelQtdDoItemIndice(int indice);
    Sprite getSprDoItemIndice(int indice);
    Material getMaterialDoItemIndice(int indice);
    Color getCorImgDoItemIndice(int indice);
}
