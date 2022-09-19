using UnityEngine;

public class MapaEntidade 
{
    public MapaEnum mapaEnum { get { return levelMapDto.MapaEnum; } }

    public int id { get; private set; }
    public string title { get; private set; }

    public bool isLivre     { get { return mapaEstado.isLivre; } }
    public bool isProgresso { get { return mapaEstado.isProgresso; } }
    public bool isBloqueado { get { return mapaEstado.isBloqueado; } }
    public bool isLockado   { get { return mapaEstado.isLockado; } }

    public Sprite spriteMapa { get { return levelMapDto.SprMapa; } }

    private LevelMapDto levelMapDto;
    private MapaEstado mapaEstado;
    private AbstractFornecedorLevels levelFornecedor                = DefaultFornecedorLevels.getInstance();
    private AbstractFornecedorColetaveisLevels coletaveisFornecedor = DefaultFornecedorLevelsColetaveis.getInstace();

    public MapaEntidade(LevelMapDto levelMapDto)
    {
        mapaEstado = new MapaEstado();
        this.levelMapDto = levelMapDto;        
    }

    //**** PARTE CONFIGURACOES BUILDER INICIO ****//
    public MapaEntidade addInfo(int id, string title)
    {
        this.id = id;
        this.title = title;
        return this;
    }

    public MapaEntidade addFornecedoresLevels(AbstractFornecedorLevels levelFornecedor)
    {
        this.levelFornecedor = levelFornecedor;        
        return this;
    }

    public MapaEntidade addFornecedoresColetaveis(AbstractFornecedorColetaveisLevels coletaveisFornecedor)
    {
        this.coletaveisFornecedor = coletaveisFornecedor;        
        return this;
    }
    //**** PARTE CONFIGURACOES BUILDER FIM****//

    //**** PARTE ESTADO INICIO ****//
    public void emProgresso()
    {
        mapaEstado.emProgresso();
    }

    public void lockar()
    {
        mapaEstado.lockar();
    }

    public void bloquear()
    {
        mapaEstado.bloquear();
    }
    //**** PARTE ESTADO FIM ****//

    //**** PARTE UI INICIO ****//
    public Vector2[] getPosicoesBaloes()
    {
        return levelMapDto.Posicoes;
    }
    //**** PARTE UI FIM ****//

    //**** PARTE LEVELS INICIO ****//
    public AbstractLevel getLevelByIndiceDezena(int indice)
    {
        return levelFornecedor.getLevelByIndiceDezena(id, indice);        
    }

    public AbstractLevel getLevelByIndiceGeral(int indice)
    {
        return levelFornecedor.getLevelByIndiceGeral(id, indice);
    }

    public AbstractLevel getLevelColetavelByIndice(int indice)
    {
        return coletaveisFornecedor.getLevel(indice);
    }

    public int getQtdLevels()
    {
        return levelFornecedor.getQtdLevels();        
    }

    public int getIndiceMaxLevelLiberadoDoMapa()
    {
        return levelFornecedor.getIndiceMaxLevelLiberadoDoMapa(id);
    }
    //**** PARTE LEVELS FIM ****//

    //**** PARTE COLETAVEIS INICIO ****//
    public ColetavelEntidade getColetavelEntidadeByIndice(int indice)
    {
        return coletaveisFornecedor.getColetavelEntidadeByIndice(indice, this, levelMapDto);
    }

    public ColetavelEntidade getColetavelEntidadeBySprite(Sprite sprite)
    {
        return coletaveisFornecedor.getColetavelEntidadeBySprite(sprite, this, levelMapDto);
    }

    public ColetavelEntidade getColetavelEntidadeBySpriteNome(string spriteNome)
    {
        return coletaveisFornecedor.getColetavelEntidadeBySpriteNome(spriteNome, this, levelMapDto);
    }

    public ColetavelEntidade getColetavelEntidadeRandom()
    {
        return coletaveisFornecedor.getColetavelEntidadeRandom(this, levelMapDto);
    }

    public int getIndiceColetavelEntidadeBySprite(Sprite sprite)
    {
        return coletaveisFornecedor.getIndiceColetavelEntidadeBySprite(sprite, this, levelMapDto);
    }

    public ColetavelEntidade[] getColetaveis()
    {
        return coletaveisFornecedor.getColetaveis(this, levelMapDto);
    }

    public ColetavelEntidade[] getColetaveisExcluindo(ColetavelEntidade coletavelEntidade)
    {
        return coletaveisFornecedor.getColetaveisExcluindo(coletavelEntidade, this, levelMapDto);
    }
    //**** PARTE COLETAVEIS FIM ****//
}
