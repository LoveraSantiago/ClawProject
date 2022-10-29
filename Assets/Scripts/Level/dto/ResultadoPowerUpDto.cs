using System.Collections.Generic;

public class ResultadoPowerUpDto 
{
    public List<PowerUpUsadoDto> listaPupsUsados { get; private set; }
    public int totalPowerUps { get { return listaPupsUsados.Count; } }

    public ResultadoPowerUpDto(List<PowerUpUsadoDto> listaPupsUsados)
    {
        this.listaPupsUsados = listaPupsUsados;
    }
}
