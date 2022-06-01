using UnityEngine;

public class CorDisplayTimerDto
{
    public Color CorDigito { get; private set; }
    public Color CorPlaca { get; private set; }

    public CorDisplayTimerDto(Color corDigito, Color corPlaca)
    {
        CorDigito = corDigito;
        this.CorPlaca = corPlaca;
    }
}
