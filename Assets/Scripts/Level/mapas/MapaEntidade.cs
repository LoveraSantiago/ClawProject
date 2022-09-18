using UnityEngine;

public class MapaEntidade 
{
    public MapaEnum mapaEnum { get { return levelMapDto.MapaEnum; } }
    private LevelMapDto levelMapDto;

    public int id { get; private set; }
    public string title { get; private set; }
    public bool locked { get; private set; }

    private AbstractFornecedorLevels levelFornecedor                = DefaultFornecedorLevels.getInstance();
    private AbstractFornecedorColetaveisLevels coletaveisFornecedor = DefaultFornecedorLevelsColetaveis.getInstace();

    public MapaEntidade(LevelMapDto levelMapDto)
    {
        this.levelMapDto = levelMapDto;        
    }

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

    public void lockar()
    {
        locked = true;
    }

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

    public int getIndiceColetavelEntidadeBySprite(Sprite sprite)
    {
        return coletaveisFornecedor.getIndiceColetavelEntidadeBySprite(sprite, this, levelMapDto);
    }

    public ColetavelEntidade[] getColetaveis()
    {
        return coletaveisFornecedor.getColetaveis(this, levelMapDto);
    }

}
