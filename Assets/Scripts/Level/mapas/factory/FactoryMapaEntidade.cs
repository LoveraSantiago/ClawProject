public class FactoryMapaEntidade 
{
    private static PrefabLevelsDto prefabsLevelsDto;

    public static MapaEntidade getMapaEntidadeByMapaEnum(MapaEnum mapaEnum)
    {
        LevelMapDto levelMapDto = prefabsLevelsDto.getLevelMapByEnum(mapaEnum);
        switch (mapaEnum)
        {
            case MapaEnum.DEFAULTS:
                return new MapaEntidade(levelMapDto)
                    .addInfo(0, "Defaults")
                    .addFornecedoresColetaveis(new DefaultColetaveisFornecedor());

            case MapaEnum.FRUTAS:
                return new MapaEntidade(levelMapDto)
                    .addInfo(1, "PARQUE DE DIVERSÕES")                   
                    .addFornecedoresLevels(new FornecedorLevelsParqueDeDiversoes())
                    //.addFornecedoresLevels(new FornecedorLevelsTestes())
                    .addFornecedoresColetaveis(new FrutasColetaveisFornecedor());

            case MapaEnum.DINO:
                return new MapaEntidade(levelMapDto)
                    .addInfo(2, "PARQUE JURASSICO")                    
                    .addFornecedoresLevels(new FornecedorLevelsTestes())
                    .addFornecedoresColetaveis(new DinosColetaveisFornecedor());

            case MapaEnum.BOLAS:
                return new MapaEntidade(levelMapDto)
                    .addInfo(3, "QUADRAS POLIESPORTIVAS")                    
                    .addFornecedoresLevels(new FornecedorLevelsTestes())
                    .addFornecedoresColetaveis(new BolasColetaveisFornecedor());

            case MapaEnum.FALLGUYS:
                return new MapaEntidade(levelMapDto)
                    .addInfo(4, "FULL GUYS WORLD")                    
                    .addFornecedoresLevels(new FornecedorLevelsTestes())
                    .addFornecedoresColetaveis(new FallGuysColetaveisFornecedor());

            case MapaEnum.YUYU:
                return new MapaEntidade(levelMapDto)
                    .addInfo(5, "DESERTO ATACAMA")                    
                    .addFornecedoresLevels(new FornecedorLevelsTestes())
                    .addFornecedoresColetaveis(new YuyuColetaveisFornecedor());

            case MapaEnum.GELEIA:
                return new MapaEntidade(levelMapDto)
                    .addInfo(6, "DESERTO DE GELO")
                    .addFornecedoresLevels(new FornecedorLevelsTestes())
                    .addFornecedoresColetaveis(new GeleiaColetaveisFornecedor());

            case MapaEnum.MARIO:
                return new MapaEntidade(levelMapDto)
                    .addInfo(7, "X")                    
                    .addFornecedoresLevels(new FornecedorLevelsTestes())
                    .addFornecedoresColetaveis(new MarioColetaveisFornecedor());

            case MapaEnum.MEGAMAN:
                return new MapaEntidade(levelMapDto)
                    .addInfo(8, "X")                    
                    .addFornecedoresLevels(new FornecedorLevelsTestes())
                    .addFornecedoresColetaveis(new MegamanColetaveisFornecedor());

            case MapaEnum.COGUMELOS:
                return new MapaEntidade(levelMapDto)
                    .addInfo(9, "X")                    
                    .addFornecedoresLevels(new FornecedorLevelsTestes())
                    .addFornecedoresColetaveis(new CogumelosColetaveisFornecedor());

            case MapaEnum.POOPS:
                return new MapaEntidade(levelMapDto)
                    .addInfo(10, "X")                    
                    .addFornecedoresLevels(new FornecedorLevelsTestes())
                    .addFornecedoresColetaveis(new PoopColetaveisFornecedor());

            case MapaEnum.CACANIQUEL:
                return new MapaEntidade(levelMapDto)
                    .addFornecedoresLevels(new FornecedorLevelsCacaNiquel())
                    .addFornecedoresColetaveis(null);

            case MapaEnum.POWERUP:
                return new MapaEntidade(levelMapDto)
                    .addFornecedoresLevels(new FornecedorLevelPowerUp())
                    .addFornecedoresColetaveis(null);                    
        }
        return null;
    }
}
