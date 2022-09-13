public class FactoryMapaEntidade 
{
    public static MapaEntidade getMapaEntidadeByMapaEnum(MapaEnum mapaEnum)
    {
        switch (mapaEnum)
        {
            case MapaEnum.DEFAULTS:
                return new MapaEntidade(MapaEnum.DEFAULTS)
                    .addInfo(0, "Defaults")
                    .addFornecedoresColetaveis(new DefaultColetaveisFornecedor());

            case MapaEnum.FRUTAS:
                return new MapaEntidade(MapaEnum.FRUTAS)
                    .addInfo(1, "PARQUE DE DIVERSÕES")                   
                    .addFornecedoresLevels(new FornecedorLevelsParqueDeDiversoes())
                    //.addFornecedoresLevels(new FornecedorLevelsTestes())
                    .addFornecedoresColetaveis(new FrutasColetaveisFornecedor());

            case MapaEnum.DINO:
                return new MapaEntidade(MapaEnum.DINO)
                    .addInfo(2, "PARQUE JURASSICO")                    
                    .addFornecedoresLevels(new FornecedorLevelsTestes())
                    .addFornecedoresColetaveis(new DinosColetaveisFornecedor());

            case MapaEnum.BOLAS:
                return new MapaEntidade(MapaEnum.BOLAS)
                    .addInfo(3, "QUADRAS POLIESPORTIVAS")                    
                    .addFornecedoresLevels(new FornecedorLevelsTestes())
                    .addFornecedoresColetaveis(new BolasColetaveisFornecedor());

            case MapaEnum.FALLGUYS:
                return new MapaEntidade(MapaEnum.FALLGUYS)
                    .addInfo(4, "FULL GUYS WORLD")                    
                    .addFornecedoresLevels(new FornecedorLevelsTestes())
                    .addFornecedoresColetaveis(new FallGuysColetaveisFornecedor());

            case MapaEnum.YUYU:
                return new MapaEntidade(MapaEnum.YUYU)
                    .addInfo(5, "DESERTO ATACAMA")                    
                    .addFornecedoresLevels(new FornecedorLevelsTestes())
                    .addFornecedoresColetaveis(new YuyuColetaveisFornecedor());

            case MapaEnum.GELEIA:
                return new MapaEntidade(MapaEnum.GELEIA)
                    .addInfo(6, "DESERTO DE GELO")
                    .addFornecedoresLevels(new FornecedorLevelsTestes())
                    .addFornecedoresColetaveis(new GeleiaColetaveisFornecedor());

            case MapaEnum.MARIO:
                return new MapaEntidade(MapaEnum.MARIO)
                    .addInfo(7, "X")                    
                    .addFornecedoresLevels(new FornecedorLevelsTestes())
                    .addFornecedoresColetaveis(new MarioColetaveisFornecedor());

            case MapaEnum.MEGAMAN:
                return new MapaEntidade(MapaEnum.MEGAMAN)
                    .addInfo(8, "X")                    
                    .addFornecedoresLevels(new FornecedorLevelsTestes())
                    .addFornecedoresColetaveis(new MegamanColetaveisFornecedor());

            case MapaEnum.COGUMELOS:
                return new MapaEntidade(MapaEnum.COGUMELOS)
                    .addInfo(9, "X")                    
                    .addFornecedoresLevels(new FornecedorLevelsTestes())
                    .addFornecedoresColetaveis(new CogumelosColetaveisFornecedor());

            case MapaEnum.POOPS:
                return new MapaEntidade(MapaEnum.POOPS)
                    .addInfo(10, "X")                    
                    .addFornecedoresLevels(new FornecedorLevelsTestes())
                    .addFornecedoresColetaveis(new PoopColetaveisFornecedor());

            case MapaEnum.CACANIQUEL:
                return new MapaEntidade(MapaEnum.CACANIQUEL)
                    .addFornecedoresLevels(new FornecedorLevelsCacaNiquel())
                    .addFornecedoresColetaveis(null);

            case MapaEnum.POWERUP:
                return new MapaEntidade(MapaEnum.POWERUP)
                    .addFornecedoresLevels(new FornecedorLevelPowerUp())
                    .addFornecedoresColetaveis(null);                    
        }
        return null;
    }
}
