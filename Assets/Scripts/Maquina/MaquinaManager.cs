using UnityEngine;

public class MaquinaManager 
{
    private JoystickHaste joystickHaste;

    public MaquinaManager(Transform hasteJoystick, float velocidade)
    {
        joystickHaste = new JoystickHaste(hasteJoystick, velocidade);
    }

    public void fixedUpdate()
    {
        joystickHaste.fixedUpdate();
    }

    public ConsumidorDeEvento<DirecaoDaGarra> getJoystickHasteConsumidorDirecao()
    {
        return joystickHaste.getConsumidorDeEventoDeDirecao();
    }
}
