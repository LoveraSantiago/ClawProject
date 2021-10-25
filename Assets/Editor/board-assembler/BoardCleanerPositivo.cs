using System;
using UnityEngine;
using UnityEngine.UI;

public class BoardCleanerPositivo : BoardCleaner
{
    public BoardCleanerPositivo(
        ReferenciasDoBoardAssembler referenciasDoBoard, NavegacaoPeloBoard navegacao, Action<GameObject> acaoCleanGo) 
        : base(referenciasDoBoard, navegacao, acaoCleanGo){}

    protected override bool isSextoElementoTipoLinha(int linha, int coluna)
    {
        return isSextoElementoLinhaPar(linha, coluna);
    }
}
