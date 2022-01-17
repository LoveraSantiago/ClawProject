using System;
using UnityEngine;
using UnityEngine.UI;

public class BoardCleanerPositivo : BoardCleaner
{
    public BoardCleanerPositivo(
        ReferenciasDoBoardAssembler referenciasDoBoard, NavegacaoPeloBoard navegacao,
        Func<Sprite> fornecedorSpriteVazio) 
        : base(referenciasDoBoard, navegacao, fornecedorSpriteVazio){}

    protected override void cleanElement(int indiceLinha, int indiceColuna, ReferenciasDoBoardAssembler referencias, bool estado)
    {
        Text textIt = ((ReferenciasDoBoardAssemblerPositivo)referencias).dicionarioTextLabels[indiceLinha][indiceColuna];
        Preenchedor.resetText(textIt);
        textIt.gameObject.SetActive(estado);
    }

    protected override bool isSextoElementoTipoLinha(int linha, int coluna)
    {
        return isSextoElementoLinhaPar(linha, coluna);
    }
}
