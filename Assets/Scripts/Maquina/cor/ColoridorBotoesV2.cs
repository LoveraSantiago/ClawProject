using System.Collections.Generic;

public class ColoridorBotoesV2 
{
    public void colorir(BotaoPowerUp[] btnsPowerUp, Dictionary<string, string> dicionarioDeCores)
    {
        string hexBotaoBase = dicionarioDeCores[ConstantesCoresMaquinaV2.BTN_PUP_BASE_ESQUERDA];
        string hexBotaoTampa = dicionarioDeCores[ConstantesCoresMaquinaV2.BTN_PUP_TAMPA_ESQUERDA];
        btnsPowerUp[0].receberCorLevelV2(hexBotaoBase, hexBotaoTampa);

        hexBotaoBase = dicionarioDeCores[ConstantesCoresMaquinaV2.BTN_PUP_BASE_DIREITA];
        hexBotaoTampa = dicionarioDeCores[ConstantesCoresMaquinaV2.BTN_PUP_TAMPA_DIREITA];
        btnsPowerUp[1].receberCorLevelV2(hexBotaoBase, hexBotaoTampa);
    }
}
