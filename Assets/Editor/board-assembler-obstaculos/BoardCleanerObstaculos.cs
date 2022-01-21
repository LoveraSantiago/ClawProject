using System;
using UnityEngine;

public class BoardCleanerObstaculos : BoardCleaner
{
    private ControleObstaculos controleObstaculos;

    public BoardCleanerObstaculos(
        ReferenciasDoBoardObstaculo referenciasDoBoard, 
        NavegacaoPeloBoard navegacao, 
        Func<Sprite> fornecedorSpriteVazio,
        ControleObstaculos controleObstaculos) 
        : base(referenciasDoBoard, navegacao, fornecedorSpriteVazio)
    {
        this.controleObstaculos = controleObstaculos;
    }

    public override void clean()
    {
        base.clean();
        controleObstaculos.resetControle();
    }

    protected override void cleanElement(int indiceLinha, int indiceColuna, ReferenciasDoBoard referencias, bool estado)
    {
        ((ReferenciasDoBoardObstaculo)referencias).updateElementoGaiola(indiceLinha, indiceColuna, false);
    }

    protected override bool isSextoElementoTipoLinha(int linha, int coluna)
    {
        return false;
    }
}
