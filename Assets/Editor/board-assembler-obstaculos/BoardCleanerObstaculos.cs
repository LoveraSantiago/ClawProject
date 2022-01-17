using System;
using UnityEngine;

public class BoardCleanerObstaculos : BoardCleaner
{
    public BoardCleanerObstaculos(
        ReferenciasDoBoardAssembler referenciasDoBoard, NavegacaoPeloBoard navegacao, 
        Func<Sprite> fornecedorSpriteVazio) 
        : base(referenciasDoBoard, navegacao, fornecedorSpriteVazio){}

    protected override void cleanElement(int indiceLinha, int indiceColuna, ReferenciasDoBoardAssembler referencias, bool estado)
    {        
    }

    protected override bool isSextoElementoTipoLinha(int linha, int coluna)
    {
        return false;
    }
}
