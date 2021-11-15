public class FactoryPupCoringa
{
    public static PowerUpEntidade factory()
    {
        return new PowerUpEntidade()
                .configNomes(PowerUpEnums.TIPO.CORINGA, "Coringa", "coringa-btn")
                .configFamilia(PowerUpEnums.FAMILIA.TRANSMUTACAO)
                .configPreco(1)
                .configDuracao(9)
                .configSupplierDePowerUpGo(CoringaPowerUpGo.getFornecedor())
                .configIsClicavel(true)
                .configDescricao(
                    "Troque um coletavel por um outro coletavel aleatorio",
                    "Selecione o coletavel de interesse de ser trocado. Toque novamente nele durante para fixar a transformação."); 
    }
}
