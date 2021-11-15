public class FactoryPupMissilTeleguiado
{
    public static PowerUpEntidade factory()
    {
        return new PowerUpEntidade()
                .configNomes(PowerUpEnums.TIPO.MISSIL_TELEGUIADO, "Missil Teleguiado", "missil-btnv2")
                .configFamilia(PowerUpEnums.FAMILIA.EXPLOSIVOS)
                .configPreco(2)
                .configDuracao(9)
                .configSupplierDePowerUpGo(MissilTeleguiadoPowerUpGo.getFornecedor())
                .configIsClicavel(true)
                .configDescricao(
                    "Acerte um missil teleguiado no coletavel de interesse para mudar a posição atual dele.",
                    "Selecione a mira do coletavel de interesse a ser acertado pelo missil teleguiado.");
    }
}
