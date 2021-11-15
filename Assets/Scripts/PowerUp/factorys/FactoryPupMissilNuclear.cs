public class FactoryPupMissilNuclear 
{
    public static PowerUpEntidade factory()
    {
        return new PowerUpEntidade()
                .configNomes(PowerUpEnums.TIPO.MISSIL_NUCLEAR, "Bomba Nuclear", "nuclear-bomba-btn")
                .configFamilia(PowerUpEnums.FAMILIA.EXPLOSIVOS)
                .configDuracao(9)
                .configSupplierDePowerUpGo(MissilNuclearPowerUpGo.getFornecedor())
                .configIsClicavel(true)
                .configDescricao(
                    "Jogue uma bomba de grande raio de explosão nos coletaveis para espalhar suas posições.",
                    "A bomba nuclear é segurada pela garra e no momento exato toque na tela para que ela solte em cima do seu alvo. Você tem 9 segundos antes que ela solte em um lugar aleatorio.");
    }
}
