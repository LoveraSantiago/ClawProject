using System;
using UnityEngine;

public class BoardCleanerNegativo : BoardCleaner
{
    public BoardCleanerNegativo(
        ReferenciasDoBoard referenciasDoBoard, NavegacaoPeloBoard navegacao,
        Func<Sprite> fornecedorSpriteVazio) 
        : base(referenciasDoBoard, navegacao, fornecedorSpriteVazio){}

    protected override void cleanElement(int indiceLinha, int indiceColuna, ReferenciasDoBoard referencias, bool estado)
    {        
    }

    protected override bool isSextoElementoTipoLinha(int linha, int coluna)
    {
        return isSextoElementoLinhaImpar(linha, coluna);
    }
}
