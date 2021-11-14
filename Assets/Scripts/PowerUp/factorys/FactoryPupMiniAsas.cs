public class FactoryPupMiniAsas
{
    public static PowerUpEntidade factory()
    {
        return new PowerUpEntidade()
                .configNomes(PowerUpEnums.TIPO.MINI_ASAS, "Mini Asas de Escape", "mini-asas-botao")
                .configFamilia(PowerUpEnums.FAMILIA.LEVITACAO)
                .configPreco(2)
                .configDuracao(9)
                .configSupplierDePowerUpGo(AsaMiniPowerUpGo.getFornecedor())
                .configIsClicavel(true)
                .configDescricao(
                    "Dê um par de mini asas ao coletavel do seu interesse para que ele tente alcançar a liberdade.",
                    "Selecione o coletavel de interesse a tentar alcançar a liberdade.");
    }
}
