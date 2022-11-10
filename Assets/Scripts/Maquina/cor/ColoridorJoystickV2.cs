using System.Collections.Generic;

public class ColoridorJoystickV2
{
    public void colorir(MesaJoystickDto mesaJoystickDto, Dictionary<string, string> dicionarioCores)
    {
        string hexCor = dicionarioCores[ConstantesCoresMaquinaV2.JOYSTICK_MESA_CIMA];
        mesaJoystickDto.SprRendererMesaCima.color = CorUtils.getCorByHex(hexCor);

        hexCor = dicionarioCores[ConstantesCoresMaquinaV2.JOYSTICK_MESA_BAIXO];
        mesaJoystickDto.SprRendererMesaBaixo.color = CorUtils.getCorByHex(hexCor);

        hexCor = dicionarioCores[ConstantesCoresMaquinaV2.JOYSTICK_SUPORTE];
        mesaJoystickDto.SprRendererBaseJoystick.color = CorUtils.getCorByHex(hexCor);

        hexCor = dicionarioCores[ConstantesCoresMaquinaV2.JOYSTICK_HASTE];
        mesaJoystickDto.SprRendererHaste.color = CorUtils.getCorByHex(hexCor);

        hexCor = dicionarioCores[ConstantesCoresMaquinaV2.JOYSTICK_BOLA];
        mesaJoystickDto.SprRendererBolaJoystick.color = CorUtils.getCorByHex(hexCor);

        hexCor = dicionarioCores[ConstantesCoresMaquinaV2.JOYSTICK_BTN_SUPORTE];
        mesaJoystickDto.SprRendererBaseBotao.color = CorUtils.getCorByHex(hexCor);

        hexCor = dicionarioCores[ConstantesCoresMaquinaV2.JOYSTICK_BTN];
        mesaJoystickDto.SprRendererBotao.color = CorUtils.getCorByHex(hexCor);

        hexCor = dicionarioCores[ConstantesCoresMaquinaV2.ORIFICIO_FICHA];
        mesaJoystickDto.SprRendererFicha.color = CorUtils.getCorByHex(hexCor);

        hexCor = dicionarioCores[ConstantesCoresMaquinaV2.ORIFICIO_CARD];
        mesaJoystickDto.SprRendererCard.color = CorUtils.getCorByHex(hexCor);

        hexCor = dicionarioCores[ConstantesCoresMaquinaV2.ORIFICIO_SETA];
        mesaJoystickDto.SprRendererSetaCard.color = CorUtils.getCorByHex(hexCor);
    }
}
