public class FactoryPupDescarte
{
    public static PowerUpEntidade factory()
    {
        return new PowerUpEntidade()
                .configNomes(PowerUpEnums.TIPO.DESCARTE, "Descarte", "descarte-botao")
                .configFamilia(PowerUpEnums.FAMILIA.MECANISMO)
                .configPreco(2)
                .configDuracao(9)
                .configSupplierDePowerUpGo(DescartePowerUpGo.getFornecedor())
                .configIsClicavel(true)
                .configIsColetavel(true)
                .configDescricao("Descarte um coletado para tentar uma melhor combinação de coletados.",
                "Selecione no display de coletados o coletado que deseja ser descartado.");
    }
}
