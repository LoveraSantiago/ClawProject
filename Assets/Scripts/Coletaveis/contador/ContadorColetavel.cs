using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContadorColetavel : ContadorNormal
{
    private ColetavelEntidade coletavelEntidade;

    public ContadorColetavel(int pontosColetado, int pontosAcerto) 
        : base(pontosColetado, pontosAcerto){}

    public override void configuradoPeloLevel(AbstractLevel level)
    {
        coletavelEntidade = LevelUtils.getColetavelFromLevelColetavel(level);
    }

    public override void iniciar(int totalColetaveis)
    {
        base.iniciar(totalColetaveis);

    }

    private void destacarColetaveis()
    {
        HelperColetaveisInGame helperInGame = new HelperColetaveisInGame();
        helperInGame.
    }
}
