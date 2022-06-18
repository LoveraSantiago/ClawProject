public class FactoryPowerUpCoringa : AbstractFactoryPowerUp
{
    public override PowerUpEntidade factoryPupEntidade()
    {
        return new PowerUpEntidade()
                .configNomes(6, PowerUpEnums.TIPO.CORINGA, "Coringa", "coringa-btn")
                .configFamilia(PowerUpEnums.FAMILIA.TRANSMUTACAO)
                .configPreco(1)
                .configDuracao(9)
                .configSupplierDePowerUpGo(this)
                .configIsClicavel(true)
                .configDescricao(
                    "Troque um coletavel por um outro coletavel aleatorio",
                    "Selecione o coletavel de interesse de ser trocado. Toque novamente nele durante para fixar a transformação.");
    }

    public override AbstractPowerUpGo fornecer()
    {
        return new CoringaPowerUpGo();
    }
}
