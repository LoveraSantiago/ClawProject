using UnityEngine;

public class ContadorColetavel : ContadorNormal
{
    
    private EstadoContadorDeColetaveis estado;
    private ColetavelEntidade coletavelEntidade;
    private TrincaColetaveisTiles trincaLevelColetaveis;    

    public ContadorColetavel(int pontosColetado, int pontosAcerto) 
        : base(pontosColetado, pontosAcerto)
    {
        estado = new EstadoContadorDeColetaveis();
    }

    public override void configuradoPeloLevel()
    {
        coletavelEntidade = LevelUtils.getColetavelFromLevelColetavel();
    }

    public override void iniciar(int totalColetaveis)
    {
        base.iniciar(totalColetaveis);
        destacarColetaveis();
    }

    private void destacarColetaveis()
    {        
        Coletavel[] coletaveis = HelperColetaveisInGame.getColetavelInGameDoTipo(coletavelEntidade);
        for(int contador = 0; contador < coletaveis.Length; contador++)
        {
            Coletavel coletavelIt = coletaveis[contador];
            Material materialOutline = MaterialOutline.of(coletavelIt.getSprite());
            coletavelIt.addMaterial(materialOutline);
            coletavelIt.colocarNoOrderDestaque();
        }

        trincaLevelColetaveis = new TrincaColetaveisTiles(coletaveis);
    }

    public override int contarColetado(Coletavel coletavel, SomColetagem somColetagem)
    {
        estado.reset();
        int score = base.contarColetado(coletavel, somColetagem);
        
        if (resultCombinacao && 
            trincaLevelColetaveis.isColetaveisNaTrinca(coletados))
        {
            estado.coletadoTrincaSucesso();
        }
        else if (!resultCombinacao && 
            trincaLevelColetaveis.isTodasPosicoesOcupadas(coletados) &&
            trincaLevelColetaveis.isQualquerColetavelNaTrinca(coletados))
        {
            estado.coletadoFailPrematuro();
        }
        
        return score;
    }    

    public override InformacoesFimDeJogoDto getInfoFimDeJogo()
    {
        if (estado.isTrincaSucesso)
        {
            return InformacoesFimDeJogoDto.ofTrinca();
        }
        else if (isZeroTotalColetaveis() || estado.isFailPrematuro)
        {
            return InformacoesFimDeJogoDto.ofTrincaFail();
        }
        else
        {
            return base.getInfoFimDeJogo();
        }
    }

    public override TrocadorDeOrdem fornecer()
    {
        return new TrocadorLevelColetavel(trincaLevelColetaveis);
    }
}
