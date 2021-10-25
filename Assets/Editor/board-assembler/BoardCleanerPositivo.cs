using System;
using UnityEngine;
using UnityEngine.UI;

public class BoardCleanerPositivo : BoardCleaner
{
    public BoardCleanerPositivo(
        ReferenciasDoBoardAssembler referenciasDoBoard, NavegacaoPeloBoard navegacao, Action<GameObject> acaoCleanGo, Action<Text> acaoCleanText) 
        : base(referenciasDoBoard, navegacao, acaoCleanGo, acaoCleanText){}

    protected override bool isSextoElementoTipoLinha(int linha, int coluna)
    {
        return isSextoElementoLinhaPar(linha, coluna);
    }
}
