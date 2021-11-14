public class FactoryPupMinaTerrestre
{
    public static PowerUpEntidade factory()
    {
        return new PowerUpEntidade()
                .configNomes(PowerUpEnums.TIPO.MINA_TERRESTRE, "Mina Terrestre", "mina-terrestre")
                .configFamilia(PowerUpEnums.FAMILIA.EXPLOSIVOS)
                .configPreco(2)
                .configDuracao(3)
                .configArea(PowerUpEnums.AREA.CHAO)
                .configSupplierDePowerUpGo(MinaTerrestrePowerUpGo.getFornecedor())
                .configIsClicavel(false)
                .configDescricao(
                    "Plante uma mina de explosão terrestre nos coletaveis para espalhar suas posições.",
                    "Arraste o botão da mina terrestre para a area azulada indicada. Um explosão abaixo dos coletaveis é acionada quando a mina é solta no lugar que foi posicionada.");
    }
}
