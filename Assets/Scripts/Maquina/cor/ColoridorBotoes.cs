using System.Collections.Generic;

public class ColoridorBotoes 
{
    public void colorir(BotaoPowerUp[] btnsPowerUp, Dictionary<string, string> dicionarioDeCores)
    {
        string hexBotao = dicionarioDeCores[ConstantesCoresMaquina.BTN_POWERUP_1];
        string hexDentro = dicionarioDeCores[ConstantesCoresMaquina.BTN_PARTEDENTRO_1];
        string hexContorno = dicionarioDeCores[ConstantesCoresMaquina.BTN_CONTORNO_1];
        //btnsPowerUp[0].receberCorLevel(hexBotao, hexDentro, hexContorno);

        hexBotao = dicionarioDeCores[ConstantesCoresMaquina.BTN_POWERUP_2];
        hexDentro = dicionarioDeCores[ConstantesCoresMaquina.BTN_PARTEDENTRO_2];
        hexContorno = dicionarioDeCores[ConstantesCoresMaquina.BTN_CONTORNO_2];
        //btnsPowerUp[1].receberCorLevel(hexBotao, hexDentro, hexContorno);

        hexBotao = dicionarioDeCores[ConstantesCoresMaquina.BTN_POWERUP_3];
        hexDentro = dicionarioDeCores[ConstantesCoresMaquina.BTN_PARTEDENTRO_3];
        hexContorno = dicionarioDeCores[ConstantesCoresMaquina.BTN_CONTORNO_3];
        //btnsPowerUp[2].receberCorLevel(hexBotao, hexDentro, hexContorno);

        hexBotao = dicionarioDeCores[ConstantesCoresMaquina.BTN_POWERUP_4];
        hexDentro = dicionarioDeCores[ConstantesCoresMaquina.BTN_PARTEDENTRO_4];
        hexContorno = dicionarioDeCores[ConstantesCoresMaquina.BTN_CONTORNO_4];
        //btnsPowerUp[3].receberCorLevel(hexBotao, hexDentro, hexContorno);
    }
}
