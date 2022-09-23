public class FactoryMapaEntidade 
{
    private static PrefabLevelsDto prefabsLevelsDto;

    public static MapaEntidade getMapaEntidadeByMapaEnum(MapaEnum mapaEnum, bool loadLiberacao)
    {
        LevelMapDto levelMapDto = prefabsLevelsDto.getLevelMapByEnum(mapaEnum);
        switch (mapaEnum)
        {
            case MapaEnum.DEFAULTS:
                return new MapaEntidade(levelMapDto)
                    .addInfo(0, "Defaults")
                    .addFornecedoresColetaveis(new DefaultFornecedorLevelsColetaveis(), loadLiberacao);

            case MapaEnum.FRUTAS:
                return new MapaEntidade(levelMapDto)
                    .addInfo(1, "PARQUE DE DIVERSÕES")
                    .addFornecedoresLevels(new FornecedorLevelsParqueDeDiversoes())
                    //.addFornecedoresLevels(new FornecedorLevelsTestes())
                    .addFornecedoresColetaveis(new FornecedorLevelColetaveisFrutas(), loadLiberacao);

            case MapaEnum.DINO:
                return new MapaEntidade(levelMapDto)
                    .addInfo(2, "PARQUE JURASSICO")                    
                    .addFornecedoresLevels(new FornecedorLevelsTestes())
                    //.addFornecedoresColetaveis(new FornecedorLevelColetaveisDinos(), loadLiberacao);
                    .addFornecedoresColetaveis(new FornecedorLevelColetaveisFrutas(), loadLiberacao);

            case MapaEnum.BOLAS:
                return new MapaEntidade(levelMapDto)
                    .addInfo(3, "QUADRAS POLIESPORTIVAS")                    
                    .addFornecedoresLevels(new FornecedorLevelsTestes())
                    //.addFornecedoresColetaveis(new FornecedorLevelColetaveisBolas(), loadLiberacao);
                .addFornecedoresColetaveis(new FornecedorLevelColetaveisFrutas(), loadLiberacao);

            case MapaEnum.FALLGUYS:
                return new MapaEntidade(levelMapDto)
                    .addInfo(4, "FULL GUYS WORLD")                    
                    .addFornecedoresLevels(new FornecedorLevelsTestes())
                    //.addFornecedoresColetaveis(new FornecedorLevelColetaveisFallGuys(), loadLiberacao);
                .addFornecedoresColetaveis(new FornecedorLevelColetaveisFrutas(), loadLiberacao);

            case MapaEnum.YUYU:
                return new MapaEntidade(levelMapDto)
                    .addInfo(5, "DESERTO ATACAMA")                    
                    .addFornecedoresLevels(new FornecedorLevelsTestes())
                    //.addFornecedoresColetaveis(new FornecedorLevelColetaveisYuyu(), loadLiberacao);
                .addFornecedoresColetaveis(new FornecedorLevelColetaveisFrutas(), loadLiberacao);

            case MapaEnum.GELEIA:
                return new MapaEntidade(levelMapDto)
                    .addInfo(6, "DESERTO DE GELO")
                    .addFornecedoresLevels(new FornecedorLevelsTestes())
                    //.addFornecedoresColetaveis(new FornecedorLevelColetaveisGeleia(), loadLiberacao);
                .addFornecedoresColetaveis(new FornecedorLevelColetaveisFrutas(), loadLiberacao);

            case MapaEnum.MARIO:
                return new MapaEntidade(levelMapDto)
                    .addInfo(7, "X")                    
                    .addFornecedoresLevels(new FornecedorLevelsTestes())
                    //.addFornecedoresColetaveis(new FornecedorLevelColetaveisMario(), loadLiberacao);
                .addFornecedoresColetaveis(new FornecedorLevelColetaveisFrutas(), loadLiberacao);

            case MapaEnum.MEGAMAN:
                return new MapaEntidade(levelMapDto)
                    .addInfo(8, "X")                    
                    .addFornecedoresLevels(new FornecedorLevelsTestes())
                    //.addFornecedoresColetaveis(new FornecedorLevelColetaveisMegaman(), loadLiberacao);
                    .addFornecedoresColetaveis(new FornecedorLevelColetaveisFrutas(), loadLiberacao); 

            case MapaEnum.COGUMELOS:
                return new MapaEntidade(levelMapDto)
                    .addInfo(9, "X")                    
                    .addFornecedoresLevels(new FornecedorLevelsTestes())
                    //.addFornecedoresColetaveis(new FornecedorLevelColetaveisCogumelos(), loadLiberacao);
                .addFornecedoresColetaveis(new FornecedorLevelColetaveisFrutas(), loadLiberacao);

            case MapaEnum.POOPS:
                return new MapaEntidade(levelMapDto)
                    .addInfo(10, "X")                    
                    .addFornecedoresLevels(new FornecedorLevelsTestes())
                    //.addFornecedoresColetaveis(new FornecedorLevelColetaveisPoop(), loadLiberacao);
                .addFornecedoresColetaveis(new FornecedorLevelColetaveisFrutas(), loadLiberacao);

            case MapaEnum.CACANIQUEL:
                return new MapaEntidade(levelMapDto)
                    .addFornecedoresLevels(new FornecedorLevelsCacaNiquel());                    

            case MapaEnum.POWERUP:
                return new MapaEntidade(levelMapDto)
                    .addFornecedoresLevels(new FornecedorLevelsPowerUp());                    
        }
        return null;
    }

    public static MapaEntidade[] getMapaEntidadesLiberados(int adicao, bool loadLiberacao)
    {
        int indiceMapaLiberado = PlayerPrefsMapas.getIndiceMapaLiberado();
        LevelMapDto[] levelMapsDto = prefabsLevelsDto.getLevelsMapLiberadosDto(indiceMapaLiberado, adicao);
        MapaEntidade[] mapaEntidades = new MapaEntidade[levelMapsDto.Length];
        for(int contador = 0; contador < levelMapsDto.Length; contador++)
        {
            MapaEntidade mapaEntidadeIt = mapaEntidades[contador];
            mapaEntidadeIt = getMapaEntidadeByMapaEnum(levelMapsDto[contador].MapaEnum, loadLiberacao); 
            if(mapaEntidadeIt.id <= indiceMapaLiberado)
            {
                mapaEntidadeIt.liberar();
            }
            mapaEntidades[contador] = mapaEntidadeIt;
        }
        return mapaEntidades;
    }

    public static void configurar(PrefabLevelsDto prefabsLevelsDtoArg)
    {
        prefabsLevelsDto = prefabsLevelsDtoArg;
    }
}
