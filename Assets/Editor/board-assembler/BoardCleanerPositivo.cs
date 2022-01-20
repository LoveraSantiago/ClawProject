using System;
using UnityEngine;
using UnityEngine.UI;

public class BoardCleanerPositivo : BoardCleaner
{
    public BoardCleanerPositivo(
        ReferenciasDoBoardPositivo referenciasDoBoard, NavegacaoPeloBoard navegacao,
        Func<Sprite> fornecedorSpriteVazio) 
        : base(referenciasDoBoard, navegacao, fornecedorSpriteVazio){}

    protected override void cleanElement(int indiceLinha, int indiceColuna, ReferenciasDoBoard referencias, bool estado)
    {
        ((ReferenciasDoBoardPositivo)referencias).updateElementoTexto(indiceLinha, indiceColuna, "00", estado);        
    }

    protected override bool isSextoElementoTipoLinha(int linha, int coluna)
    {
        return isSextoElementoLinhaPar(linha, coluna);
    }
}
