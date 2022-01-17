using System;
using UnityEngine;
using UnityEngine.UI;

public class BoardCleanerPositivo : BoardCleaner
{
    public BoardCleanerPositivo(
        ReferenciasDoBoard referenciasDoBoard, NavegacaoPeloBoard navegacao,
        Func<Sprite> fornecedorSpriteVazio) 
        : base(referenciasDoBoard, navegacao, fornecedorSpriteVazio){}

    protected override void cleanElement(int indiceLinha, int indiceColuna, ReferenciasDoBoard referencias, bool estado)
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
