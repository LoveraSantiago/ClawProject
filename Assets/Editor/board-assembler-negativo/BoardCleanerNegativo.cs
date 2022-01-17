using System;
using UnityEngine;

public class BoardCleanerNegativo : BoardCleaner
{
    public BoardCleanerNegativo(
        ReferenciasDoBoardAssembler referenciasDoBoard, NavegacaoPeloBoard navegacao,
        Func<Sprite> fornecedorSpriteVazio) 
        : base(referenciasDoBoard, navegacao, fornecedorSpriteVazio){}

    protected override void cleanElement(int indiceLinha, int indiceColuna, ReferenciasDoBoardAssembler referencias, bool estado)
    {        
    }

    protected override bool isSextoElementoTipoLinha(int linha, int coluna)
    {
        return isSextoElementoLinhaImpar(linha, coluna);
    }
}
