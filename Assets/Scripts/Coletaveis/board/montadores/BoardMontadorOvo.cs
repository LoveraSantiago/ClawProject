using System.Collections;
using UnityEngine;

public class BoardMontadorOvo : BoardMontadorNormal
{
    protected override IEnumerator create(BoardDto boardDto)
    {
        yield return base.create(boardDto);
        
        yield return new WaitForSeconds(boardDto.DelayMontagemOvo);        
        
        int qtdColetaveis = HelperColetaveisInGame.getQtdColetaveisInGame();        

        for (int contador = 1; contador <= qtdColetaveis; contador++)
        {   
            Coletavel coletavel = HelperColetaveisInGame.getColetavelInGameByGoName(contador.ToString());
            coletavel.ligarAnimacaoFecharOvo();
            yield return new WaitForSeconds(0.1f);
        }
    }
}
