using System.Collections.Generic;

public class ColoridorJoystick
{
    public void colorir(JoystickDto joystickDto, Dictionary<string, string> dicionarioCores)
    {
        string hexCor = dicionarioCores[ConstantesCoresMaquina.PARTE_CIMA];
        //joystickDto.ParteCima.color = Utils.getCorByHex(hexCor);

        hexCor = dicionarioCores[ConstantesCoresMaquina.PARTE_BAIXO];
        //joystickDto.ParteBaixo.color = Utils.getCorByHex(hexCor);

        hexCor = dicionarioCores[ConstantesCoresMaquina.FURO_HASTE];
        joystickDto.FuroHaste.color = Utils.getCorByHex(hexCor);

        hexCor = dicionarioCores[ConstantesCoresMaquina.HASTE];
        joystickDto.Haste.color = Utils.getCorByHex(hexCor);

        hexCor = dicionarioCores[ConstantesCoresMaquina.JOYSTICK_BOLA];
        joystickDto.Bola.color = Utils.getCorByHex(hexCor);

        hexCor = dicionarioCores[ConstantesCoresMaquina.FURO_BOTAO];
        joystickDto.FuroBotao.color = Utils.getCorByHex(hexCor);

        hexCor = dicionarioCores[ConstantesCoresMaquina.BOTAO];
        joystickDto.JoystickBotao.color = Utils.getCorByHex(hexCor);
    }
}
