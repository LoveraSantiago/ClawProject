using System;
using UnityEngine;

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
