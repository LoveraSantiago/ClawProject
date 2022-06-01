using System.Collections.Generic;

public class ColoridorJoystickV2
{
    public void colorir(MesaJoystickDto mesaJoystickDto, Dictionary<string, string> dicionarioCores)
    {
        string hexCor = dicionarioCores[ConstantesCoresMaquinaV2.JOYSTICK_MESA_CIMA];
        mesaJoystickDto.SprRendererMesaCima.color = Utils.getCorByHex(hexCor);

        hexCor = dicionarioCores[ConstantesCoresMaquinaV2.JOYSTICK_MESA_BAIXO];
        mesaJoystickDto.SprRendererMesaBaixo.color = Utils.getCorByHex(hexCor);

        hexCor = dicionarioCores[ConstantesCoresMaquinaV2.JOYSTICK_SUPORTE];
        mesaJoystickDto.SprRendererBaseJoystick.color = Utils.getCorByHex(hexCor);

        hexCor = dicionarioCores[ConstantesCoresMaquinaV2.JOYSTICK_HASTE];
        mesaJoystickDto.SprRendererHaste.color = Utils.getCorByHex(hexCor);

        hexCor = dicionarioCores[ConstantesCoresMaquinaV2.JOYSTICK_BOLA];
        mesaJoystickDto.SprRendererBolaJoystick.color = Utils.getCorByHex(hexCor);

        hexCor = dicionarioCores[ConstantesCoresMaquinaV2.JOYSTICK_BTN_SUPORTE];
        mesaJoystickDto.SprRendererBaseBotao.color = Utils.getCorByHex(hexCor);

        hexCor = dicionarioCores[ConstantesCoresMaquinaV2.JOYSTICK_BTN];
        mesaJoystickDto.SprRendererBotao.color = Utils.getCorByHex(hexCor);

        hexCor = dicionarioCores[ConstantesCoresMaquinaV2.ORIFICIO_FICHA];
        mesaJoystickDto.SprRendererFicha.color = Utils.getCorByHex(hexCor);

        hexCor = dicionarioCores[ConstantesCoresMaquinaV2.ORIFICIO_CARD];
        mesaJoystickDto.SprRendererCard.color = Utils.getCorByHex(hexCor);

        hexCor = dicionarioCores[ConstantesCoresMaquinaV2.ORIFICIO_SETA];
        mesaJoystickDto.SprRendererSetaCard.color = Utils.getCorByHex(hexCor);
    }
}
