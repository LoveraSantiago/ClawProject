using UnityEngine;

public class ColetavelContexto : MainGOContexto
{
    public Nomeador nomeador { get; private set; }

    public ColetavelContexto(ColetaveisDto coletaveisDto)
        :base(coletaveisDto.Tile, coletaveisDto.BoardDto.StartBoard)
    {
        nomeador = new Nomeador();
    }    
}
