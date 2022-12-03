using System.Collections;
using UnityEngine;

public class BoardMontadorNormal : BoardMontador
{
    private DestaqueGrayScale destaque;

    public override void configuradoPeloLevel()
    {   
        setArrayDeColetavel(ContextoEstaticoUtils.level.getArrayDeColetaveis());
        destaque = new DestaqueGrayScale();
    }

    protected override IEnumerator create(BoardDto boardDto)
    {
        PosicaoItensDoBoardDto posYItem = getPosYITem(boardDto);
        for (int contadorLinha = 0; contadorLinha < posYItem.Total; contadorLinha++)
        {
            PosicaoItensDoBoardDto posXItem = getPosicaoItem(boardDto, contadorLinha);
            float alturaY = posYItem.Inicio + (posYItem.Acrescimo * contadorLinha);
            yield return montarLinha(posXItem, contadorLinha, alturaY);
        }        
    }
    
    protected virtual PosicaoItensDoBoardDto getPosYITem(BoardDto boardDto)
    {
        return boardDto.PosicoesY;
    }

    protected override IEnumerator onColetavelCriado(int posX, int posY, Coletavel coletavel)
    {
        destaque.destacar(coletavel);
        yield return new WaitForSeconds(getDelay());
    }
}
 