public class FactoryDeColetaveisEntidades 
{
    public static ColetavelEntidade[] factory()
    {
        return new ColetavelEntidade[] {
            new ColetavelEntidade(0, -1, "vazio" , "tile-vazio"      , MapaEnum.DEFAULTS),//Range de 0 a 9 pra defaults
            new ColetavelEntidade(1, -1, "random", "tile-random"     , MapaEnum.DEFAULTS),
            new ColetavelEntidade(2, -1, "ovo"   , "capsula-completa", MapaEnum.DEFAULTS),
        };
    }
}
