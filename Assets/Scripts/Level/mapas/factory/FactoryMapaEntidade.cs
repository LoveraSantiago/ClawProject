public class FactoryMapaEntidade 
{
    public static MapaEntidade getMapaEntidadeByMapaEnum(MapaEnum mapaEnum)
    {
        switch (mapaEnum)
        {
            case MapaEnum.DEFAULTS:
                return new MapaEntidade()
                    .addInfo(0, "Defaults");

            case MapaEnum.FRUTAS:
                return new MapaEntidade()
                    .addInfo(1, "PARQUE DE DIVERSÕES")
                    .addPathSprite("frutas")
            //        .addFornecedoresLevels(new FornecedorLevelsParqueDeDiversoes(), new FrutasColetaveisLevelFornecedor());
            .addFornecedoresLevels(new FornecedorLevelsTestes(), new FrutasColetaveisLevelFornecedor());

            case MapaEnum.DINO:
                return new MapaEntidade()
                    .addInfo(2, "PARQUE JURASSICO")
                    .addPathSprite("dinos")
                    .addFornecedoresLevels(new FornecedorLevelsTestes(), new FrutasColetaveisLevelFornecedor());

            case MapaEnum.BOLAS:
                return new MapaEntidade()
                    .addInfo(3, "QUADRAS POLIESPORTIVAS")
                    .addPathSprite("bolas")
                    .addFornecedoresLevels(new FornecedorLevelsTestes(), new FrutasColetaveisLevelFornecedor());

            case MapaEnum.FALLGUYS:
                return new MapaEntidade()
                    .addInfo(4, "FULL GUYS WORLD")
                    .addPathSprite("fg")
                    .addFornecedoresLevels(new FornecedorLevelsTestes(), new FrutasColetaveisLevelFornecedor());

            case MapaEnum.YUYU:
                return new MapaEntidade()
                    .addInfo(5, "DESERTO ATACAMA")
                    .addPathSprite("yuyu")
                    .addFornecedoresLevels(new FornecedorLevelsTestes(), new FrutasColetaveisLevelFornecedor());

            case MapaEnum.GELEIA:
                return new MapaEntidade()
                    .addInfo(6, "DESERTO DE GELO")
                    .addPathSprite("geleia")
                    .addFornecedoresLevels(new FornecedorLevelsTestes(), new FrutasColetaveisLevelFornecedor());

            case MapaEnum.MARIO:
                return new MapaEntidade()
                    .addInfo(7, "X")
                    .addPathSprite("mario")
                    .addFornecedoresLevels(new FornecedorLevelsTestes(), new FrutasColetaveisLevelFornecedor());

            case MapaEnum.MEGAMAN:
                return new MapaEntidade()
                    .addInfo(8, "X")
                    .addPathSprite("megaman")
                    .addFornecedoresLevels(new FornecedorLevelsTestes(), new FrutasColetaveisLevelFornecedor());

            case MapaEnum.COGUMELOS:
                return new MapaEntidade()
                    .addInfo(9, "X")
                    .addPathSprite("cogumelos")
                    .addFornecedoresLevels(new FornecedorLevelsTestes(), new FrutasColetaveisLevelFornecedor());

            case MapaEnum.POOPS:
                return new MapaEntidade()
                    .addInfo(10, "X")
                    .addPathSprite("poops")
                    .addFornecedoresLevels(new FornecedorLevelsTestes(), new FrutasColetaveisLevelFornecedor());

            case MapaEnum.CACANIQUEL:
                return new MapaEntidade()
                    .addFornecedoresLevels(new FornecedorLevelsCacaNiquel(), null);

            case MapaEnum.POWERUP:
                return new MapaEntidade()
                    .addFornecedoresLevels(new FornecedorLevelPowerUp(), null);                    
        }
        return null;
    }
}
