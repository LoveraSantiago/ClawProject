using System;
using UnityEngine;

public class BoardCleanerNegativo : BoardCleaner
{
    public BoardCleanerNegativo(
        ReferenciasDoBoardAssembler referenciasDoBoard, NavegacaoPeloBoard navegacao, Action<GameObject> acaoCleanGo) 
        : base(referenciasDoBoard, navegacao, acaoCleanGo){}

    protected override bool isSextoElementoTipoLinha(int linha, int coluna)
    {
        return isSextoElementoLinhaImpar(linha, coluna);
    }
}
