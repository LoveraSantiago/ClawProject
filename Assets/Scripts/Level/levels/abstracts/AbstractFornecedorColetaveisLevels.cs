using UnityEngine;

public abstract class AbstractFornecedorColetaveisLevels
{
    private ColetavelEntidade[] arrayDeColetaveis;   
    
    public ColetavelEntidade getColetavelEntidadeByIndice(int indice, MapaEntidade mapaEntidade, LevelMapDto levelMapDto)
    {
        iniciarArrayDeColetaveis(mapaEntidade, levelMapDto);
        if(indice < 0 || indice > arrayDeColetaveis.Length)
        {
            return arrayDeColetaveis[0];
        }
        return arrayDeColetaveis[indice];
    }

    public ColetavelEntidade getColetavelEntidadeBySprite(Sprite sprite, MapaEntidade mapaEntidade, LevelMapDto levelMapDto)
    {
        return getColetavelEntidadeBySpriteNome(sprite.name, mapaEntidade, levelMapDto);        
    }

    public ColetavelEntidade getColetavelEntidadeBySpriteNome(string nomeSprite, MapaEntidade mapaEntidade, LevelMapDto levelMapDto)
    {
        iniciarArrayDeColetaveis(mapaEntidade, levelMapDto);
        for (int contador = 0; contador < arrayDeColetaveis.Length; contador++)
        {
            ColetavelEntidade coletavelEntidadeIt = arrayDeColetaveis[contador];
            if (coletavelEntidadeIt.sprite.name.Equals(nomeSprite))
            {
                return coletavelEntidadeIt;
            }
        }
        return getColetavelEntidadeByIndice(0, mapaEntidade, levelMapDto);
    }

    public int getIndiceColetavelEntidadeBySprite(Sprite sprite, MapaEntidade mapaEntidade, LevelMapDto levelMapDto)
    {
        ColetavelEntidade coletavel = getColetavelEntidadeBySpriteNome(sprite.name, mapaEntidade, levelMapDto);
        return coletavel.indice;
    }    

    public ColetavelEntidade getColetavelEntidadeRandom(MapaEntidade mapaEntidade, LevelMapDto levelMapDto)
    {
        iniciarArrayDeColetaveis(mapaEntidade, levelMapDto);
        int indiceSorteado = Random.Range(0, arrayDeColetaveis.Length);
        return getColetavelEntidadeByIndice(indiceSorteado, mapaEntidade, levelMapDto);
    }

    public AbstractLevel getLevel(int indice)
    {
        AbstractLevelColetavel levelColetavel = (AbstractLevelColetavel)getLevelToColetavel(indice);
        if(levelColetavel != null)
        {
            levelColetavel.setColetavelEntidade(arrayDeColetaveis[indice]);
        }
        return levelColetavel;
    }

    protected abstract AbstractLevel getLevelToColetavel(int indice);

    public ColetavelEntidade[] getColetaveis(MapaEntidade mapaEntidade, LevelMapDto levelMapDto)
    {
        iniciarArrayDeColetaveis(mapaEntidade, levelMapDto);
        return arrayDeColetaveis;
    }

    public ColetavelEntidade[] getColetaveisExcluindo(ColetavelEntidade coletavelEntidade, MapaEntidade mapaEntidade, LevelMapDto levelMapDto)
    {
        iniciarArrayDeColetaveis(mapaEntidade, levelMapDto);
        ColetavelEntidade[] coletaveisFiltrado = new ColetavelEntidade[arrayDeColetaveis.Length - 1];

        int contadorFiltrado = 0;
        for(int contadorColetaveis = 0; contadorColetaveis < arrayDeColetaveis.Length; contadorColetaveis++)
        {
            ColetavelEntidade coletavelIt = arrayDeColetaveis[contadorColetaveis];
            if(coletavelIt.indice != coletavelEntidade.indice)
            {
                coletaveisFiltrado[contadorFiltrado] = coletavelIt;
                contadorFiltrado++;
            }
        }
        return coletaveisFiltrado;
    }

    public void resetArrayDeColetaveis()
    {
        arrayDeColetaveis = null;
    }

    private void iniciarArrayDeColetaveis(MapaEntidade mapaEntidade, LevelMapDto levelMapDto)
    {
        if(arrayDeColetaveis == null)
        {            
            configurarColetaveis(mapaEntidade, levelMapDto);
        }
    }

    private void configurarColetaveis(MapaEntidade mapaEntidade, LevelMapDto levelMapDto)
    {
        int qtdColetaveisDto = levelMapDto.ColetaveisDto.Length;
        arrayDeColetaveis    = new ColetavelEntidade[qtdColetaveisDto];

        int[] adquiridosColetaveis = loadColetaveisAdquiridos(mapaEntidade, qtdColetaveisDto);        
        int[] liberadosColetaveis  = loadColetaveisLiberados(mapaEntidade, qtdColetaveisDto);
        for (int contador = 0; contador < qtdColetaveisDto; contador++)
        {
            ColetavelEntidadeDto coletavelEntidadeDtoIt = levelMapDto.ColetaveisDto[contador];
            ColetavelEntidade coletavelEntidadeIt = new ColetavelEntidade(contador, coletavelEntidadeDtoIt);
            coletavelEntidadeIt.setMapaEntidade(mapaEntidade);

            
            bool adquirido = adquiridosColetaveis[contador] == 1;
            bool liberado  = liberadosColetaveis[contador] == 1;
            coletavelEntidadeIt.adquirir(adquirido);
            coletavelEntidadeIt.exclamar(liberado);

            //Debug.Log("Coletavel " + coletavelEntidadeDtoIt.Nome + " adquirido: " + adquirido);
            arrayDeColetaveis[contador] = coletavelEntidadeIt;            
        }
    }

    private int[] loadColetaveisAdquiridos(MapaEntidade mapaEntidade, int qtdColetaveisDto)
    {
        return  PlayerPrefsMapas.getColetaveisAdquiridosDoMapa(mapaEntidade, qtdColetaveisDto);        
    }

    private int[] loadColetaveisLiberados(MapaEntidade mapaEntidade, int qtdColetaveisDto)
    {
        return PlayerPrefsMapas.getColetaveisEstadoLiberadosDoMapa(mapaEntidade, qtdColetaveisDto);        
    }
}
