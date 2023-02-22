using UnityEngine;

public abstract class AbstractLevelTutorial : AbstractLevel
{
    protected AbstractLevelTutorial(MaquinaCor maquinaCor) : base(maquinaCor){}

    public override TipoGame getTipoGame()
    {
        return TipoGame.TUTORIAL;
    }
    
    public abstract AbstractMainGameEventosTutorial getMainGameEventos(AllGameManagers allGameManagers, MainGameDto mainDto);

    public abstract int recuperarQtdPup(PowerUpEnums.TIPO powerupTipo);

    public override Challenge[] getChallenges()
    {
        return new Challenge[] {
            new ChallengeLevelCompleto("Aprenda seguindo o tutorial"),
            new ChallengeLevelCompleto("Ative um power up"),
            new ChallengeLevelCompleto("Se divertir completamente")
        };
    }

    public InformacoesColetadoDto[] getInformacoesColetadosDto()
    {
        int[] indicesColetados = getColetados();
        InformacoesColetadoDto[] informacoesColetados = new InformacoesColetadoDto[indicesColetados.Length];
        for(int contador = 0; contador < indicesColetados.Length; contador++)
        {
            ColetavelEntidade coletavelEntidade = ContextoEstaticoUtils.mapaEntidade.getColetavelEntidadeByIndice(indicesColetados[contador]);
            Sprite spriteColetado = coletavelEntidade.sprite;

            InformacoesColetadoDto infoColetado = new InformacoesColetadoDto();
            infoColetado.addInfosDisplayColetados(spriteColetado, false);            
            informacoesColetados[contador] = infoColetado;
        }
        return informacoesColetados;
    }

    public Coletavel[] getColetaveisColetados()
    {
        int[] indicesColetados = getColetados();
        Coletavel[] coletaveis = new Coletavel[indicesColetados.Length];
        for(int contador = 0; contador < indicesColetados.Length; contador++)
        {
            ColetavelEntidade coletavelEntidade = ContextoEstaticoUtils.mapaEntidade.getColetavelEntidadeByIndice(indicesColetados[contador]);

            Coletavel coletavel = HelperColetaveisInGame.criarColetavel();
            coletavel.receberSprite(coletavelEntidade.sprite);
            coletavel.desligarComEstado();
            coletaveis[contador] = coletavel;
        }
        return coletaveis;
    }

    public virtual int[] getColetados()
    {
        return new int[] { };
    }
}
