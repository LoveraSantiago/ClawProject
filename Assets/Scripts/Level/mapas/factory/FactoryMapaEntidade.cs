public class FactoryMapaEntidade 
{
    public static MapaEntidade getMapaEntidadeByMapaEnum(MapaEnum mapaEnum)
    {
        switch (mapaEnum)
        {
            case MapaEnum.FRUTAS:
                return new MapaEntidade()
                    .addInfo(1, "PARQUE DE DIVERSÕES")
                    .addPathSprite("frutas")
                    .addFornecedoresLevels(new FornecedorLevelsParqueDeDiversoes(), new FrutasColetaveisLevelFornecedor());

            case MapaEnum.DINO:
                return new MapaEntidade()
                    .addInfo(2, "PARQUE JURASSICO")
                    .addPathSprite("dinos");

            case MapaEnum.BOLAS:
                return new MapaEntidade()
                    .addInfo(3, "QUADRAS POLIESPORTIVAS")
                    .addPathSprite("bolas");

            case MapaEnum.FALLGUYS:
                return new MapaEntidade()
                    .addInfo(4, "FULL GUYS WORLD")
                    .addPathSprite("fg");

            case MapaEnum.YUYU:
                return new MapaEntidade()
                    .addInfo(5, "DESERTO ATACAMA")
                    .addPathSprite("yuyu");

            case MapaEnum.GELEIA:
                return new MapaEntidade()
                    .addInfo(6, "X")
                    .addPathSprite("geleia");

            case MapaEnum.MARIO:
                return new MapaEntidade()
                    .addInfo(7, "X")
                    .addPathSprite("mario");

            case MapaEnum.MEGAMAN:
                return new MapaEntidade()
                    .addInfo(8, "X")
                    .addPathSprite("megaman");

            case MapaEnum.COGUMELOS:
                return new MapaEntidade()
                    .addInfo(9, "X")
                    .addPathSprite("cogumelos");

            case MapaEnum.POOPS:
                return new MapaEntidade()
                    .addInfo(10, "X")
                    .addPathSprite("poops");

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
