public class FactoryMapaEntidade 
{
    public static MapaEntidade getMapaEntidadeByMapaEnum(MapaEnum mapaEnum)
    {
        switch (mapaEnum)
        {
            case MapaEnum.DEFAULTS:
                return new MapaEntidade()
                    .addInfo(0, "Defaults")
                    .addFornecedoresColetaveis(new DefaultColetaveisFornecedor());

            case MapaEnum.FRUTAS:
                return new MapaEntidade()
                    .addInfo(1, "PARQUE DE DIVERSÕES")
                    .addPathSprite("frutas")
                    .addFornecedoresLevels(new FornecedorLevelsParqueDeDiversoes())
                    //.addFornecedoresLevels(new FornecedorLevelsTestes())
                    .addFornecedoresColetaveis(new FrutasColetaveisFornecedor());

            case MapaEnum.DINO:
                return new MapaEntidade()
                    .addInfo(2, "PARQUE JURASSICO")
                    .addPathSprite("dinos")
                    .addFornecedoresLevels(new FornecedorLevelsTestes())
                    .addFornecedoresColetaveis(new DinosColetaveisFornecedor());

            case MapaEnum.BOLAS:
                return new MapaEntidade()
                    .addInfo(3, "QUADRAS POLIESPORTIVAS")
                    .addPathSprite("bolas")
                    .addFornecedoresLevels(new FornecedorLevelsTestes())
                    .addFornecedoresColetaveis(new BolasColetaveisFornecedor());

            case MapaEnum.FALLGUYS:
                return new MapaEntidade()
                    .addInfo(4, "FULL GUYS WORLD")
                    .addPathSprite("fg")
                    .addFornecedoresLevels(new FornecedorLevelsTestes())
                    .addFornecedoresColetaveis(new FallGuysColetaveisFornecedor());

            case MapaEnum.YUYU:
                return new MapaEntidade()
                    .addInfo(5, "DESERTO ATACAMA")
                    .addPathSprite("yuyu")
                    .addFornecedoresLevels(new FornecedorLevelsTestes())
                    .addFornecedoresColetaveis(new YuyuColetaveisFornecedor());

            case MapaEnum.GELEIA:
                return new MapaEntidade()
                    .addInfo(6, "DESERTO DE GELO")
                    .addPathSprite("geleia")
                    .addFornecedoresLevels(new FornecedorLevelsTestes())
                    .addFornecedoresColetaveis(new GeleiaColetaveisFornecedor());

            case MapaEnum.MARIO:
                return new MapaEntidade()
                    .addInfo(7, "X")
                    .addPathSprite("mario")
                    .addFornecedoresLevels(new FornecedorLevelsTestes())
                    .addFornecedoresColetaveis(new MarioColetaveisFornecedor());

            case MapaEnum.MEGAMAN:
                return new MapaEntidade()
                    .addInfo(8, "X")
                    .addPathSprite("megaman")
                    .addFornecedoresLevels(new FornecedorLevelsTestes())
                    .addFornecedoresColetaveis(new MegamanColetaveisFornecedor());

            case MapaEnum.COGUMELOS:
                return new MapaEntidade()
                    .addInfo(9, "X")
                    .addPathSprite("cogumelos")
                    .addFornecedoresLevels(new FornecedorLevelsTestes())
                    .addFornecedoresColetaveis(new CogumelosColetaveisFornecedor());

            case MapaEnum.POOPS:
                return new MapaEntidade()
                    .addInfo(10, "X")
                    .addPathSprite("poops")
                    .addFornecedoresLevels(new FornecedorLevelsTestes())
                    .addFornecedoresColetaveis(new PoopColetaveisFornecedor());

            case MapaEnum.CACANIQUEL:
                return new MapaEntidade()
                    .addFornecedoresLevels(new FornecedorLevelsCacaNiquel())
                    .addFornecedoresColetaveis(null);

            case MapaEnum.POWERUP:
                return new MapaEntidade()
                    .addFornecedoresLevels(new FornecedorLevelPowerUp())
                    .addFornecedoresColetaveis(null);                    
        }
        return null;
    }
}
