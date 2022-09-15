using UnityEngine;

public class MapaEntidade 
{
    private LevelMapDto levelMapDto;

    public int id { get; private set; }
    public string title { get; private set; }

    private AbstractFornecedorLevels levelFornecedor                = FornecedorLevelsDefault.getInstance();
    private AbstractFornecedorColetaveisLevels coletaveisFornecedor = FornecedorColetaveisDefault.getInstace();

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

    public AbstractLevel getLevelByIndiceDezena(int indice)
    {
        return levelFornecedor.getLevelByIndiceDezena(id, indice);        
    }

    public AbstractLevel getLevelByIndiceGeral(int indice)
    {
        return levelFornecedor.getLevelByIndiceGeral(id, indice);
    }

    public int getQtdLevels()
    {
        return levelFornecedor.getQtdLevels();        
    }

    public int getIndiceMaxLevelLiberadoDoMapa()
    {
        return levelFornecedor.getIndiceMaxLevelLiberadoDoMapa(id);
    }

    public AbstractLevel getLevelByColetavelEntidade(ColetavelEntidade coletavelEntidade)
    {
        return coletaveisFornecedor.getLevel(coletavelEntidade);
    }

    public ColetavelEntidade getColetavelEntidadeByIndice(int indice)
    {
        return coletaveisFornecedor.getColetavelEntidadeByIndice(indice, levelMapDto);
    }

    public int getIndiceColetavelEntidadeBySprite(Sprite sprite)
    {
        return coletaveisFornecedor.getIndiceColetavelEntidadeBySprite(sprite, levelMapDto);
    }

    public ColetavelEntidade[] getColetaveis()
    {
        return coletaveisFornecedor.getColetaveis(levelMapDto);
    }

}
