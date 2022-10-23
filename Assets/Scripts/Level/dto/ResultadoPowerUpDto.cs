using System.Collections.Generic;

public class ResultadoPowerUpDto 
{
    private List<PowerUpUsadoDto> listaPupsUsados;
    public int totalPowerUps { get { return listaPupsUsados.Count; } }

    public ResultadoPowerUpDto(List<PowerUpUsadoDto> listaPupsUsados)
    {
        this.listaPupsUsados = listaPupsUsados;
    }
}
