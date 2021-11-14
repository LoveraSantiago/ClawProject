using UnityEngine;

public class FactoryPupTeleporte : MonoBehaviour
{
    public static PowerUpEntidade factory()
    {
        return new PowerUpEntidade()
                .configNomes(PowerUpEnums.TIPO.TELEPORTE, "Tele-Transporte", "teleport-btn")
                .configFamilia(PowerUpEnums.FAMILIA.TRANSMUTACAO)
                .configPreco(3)
                .configDuracao(9)
                .configSupplierDePowerUpGo(TeleportePowerUpGo.getFornecedor())
                .configIsClicavel(true)
                .configDescricao(
                    "Troque as posições de um par de coletaveis para mudar suas respectivas posições.",
                    "Selecione o primeiro coletavel a ser trocado de lugar. Selecione o segundo coletavel que será trocado de posicao com o primeiro");
    }
}
