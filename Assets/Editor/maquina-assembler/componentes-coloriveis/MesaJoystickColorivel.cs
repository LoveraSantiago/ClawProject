using UnityEngine;

public class MesaJoystickColorivel
{
    private GameObject goMesaCima;
    private GameObject goMesaBaixo;
    private GameObject goMesaJoystickCima;

    private FinderComponente finder;

    public MesaJoystickColorivel(FinderComponente finder)
    {
        this.finder = finder;
        GameObject goMesa = finder.findNaMaquina("mesa-joystick");
        goMesaCima  = finder.findNoComponente(goMesa, "cima");
        goMesaBaixo = finder.findNoComponente(goMesa, "baixo");
        goMesaJoystickCima = getGoMesaJoystickCima();
    }

    public ComponenteColorivel getMesaCima()
    {
        return new SingleCompColorivel(goMesaJoystickCima);
    }

    public ComponenteColorivel getMesaBaixo()
    {
        GameObject goMesaJoystickBaixo = finder.findNoComponente(goMesaBaixo, ConstantesCoresMaquinaV2.JOYSTICK_MESA_BAIXO);
        return new SingleCompColorivel(goMesaJoystickBaixo);
    }

    public ComponenteColorivel getJoystickSuporte()
    {
        GameObject goJoystick = getGoJoystick();
        GameObject goSuporte = finder.findNoComponente(goJoystick, ConstantesCoresMaquinaV2.JOYSTICK_SUPORTE);
        return new SingleCompColorivel(goSuporte);
    }

    public ComponenteColorivel getJoystickHaste()
    {   
        GameObject goJoystick = getGoJoystick();
        GameObject goHaste = finder.findNoComponente(goJoystick, ConstantesCoresMaquinaV2.JOYSTICK_HASTE);
        return new SingleCompColorivel(goHaste);
    }

    public ComponenteColorivel getJoystickBola()
    {
        GameObject goJoystick = getGoJoystick();
        GameObject goHaste = finder.findNoComponente(goJoystick, ConstantesCoresMaquinaV2.JOYSTICK_HASTE);
        GameObject goBola = finder.findNoComponente(goHaste, ConstantesCoresMaquinaV2.JOYSTICK_BOLA);
        return new SingleCompColorivel(goBola);
    }

    public ComponenteColorivel getJoystickBtnSuporte()
    {
        GameObject goBotaoJoystick = getBotaoJoystick();
        GameObject goSuporte = finder.findNoComponente(goBotaoJoystick, ConstantesCoresMaquinaV2.JOYSTICK_BTN_SUPORTE);
        return new SingleCompColorivel(goSuporte);
    }

    public ComponenteColorivel getJoystickBtn()
    {
        GameObject goBotaoJoystick = getBotaoJoystick();
        GameObject goBtn = finder.findNoComponente(goBotaoJoystick, ConstantesCoresMaquinaV2.JOYSTICK_BTN);
        return new SingleCompColorivel(goBtn);
    }

    private GameObject getGoMesaJoystickCima()
    {
        return finder.findNoComponente(goMesaCima, ConstantesCoresMaquinaV2.JOYSTICK_MESA_CIMA);
    }    

    private GameObject getGoJoystick()
    {
        return finder.findNoComponente(goMesaCima, "joystick");
    }

    private GameObject getBotaoJoystick()
    {
        return finder.findNoComponente(goMesaCima, "botao-joystick");
    }
}
