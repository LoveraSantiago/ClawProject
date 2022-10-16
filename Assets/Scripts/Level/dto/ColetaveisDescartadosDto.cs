using System.Collections.Generic;
using UnityEngine;

public class ColetaveisDescartadosDto 
{
    public List<TrincaColetaveisDescartadosDto> coletaveisDescartados { get; private set; }

    public ColetaveisDescartadosDto()
    {
        coletaveisDescartados = new List<TrincaColetaveisDescartadosDto>();
    }

    private void addTrinca(TrincaColetaveisDescartadosDto trinca)
    {
        coletaveisDescartados.Add(trinca);
    }

    public void addTrinca(Sprite[] sprites)
    {
        addTrinca(new TrincaColetaveisDescartadosDto(sprites, Time.time));
    }
}
