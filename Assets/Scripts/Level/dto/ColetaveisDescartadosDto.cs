using System.Collections.Generic;
using UnityEngine;

public class ColetaveisDescartadosDto 
{
    public List<TrincaColetaveisDescartadosDto> listaDeTrincaDeDescartados { get; private set; }

    public ColetaveisDescartadosDto()
    {
        listaDeTrincaDeDescartados = new List<TrincaColetaveisDescartadosDto>();
    }

    private void addTrinca(TrincaColetaveisDescartadosDto trinca)
    {
        listaDeTrincaDeDescartados.Add(trinca);
    }

    public void addTrinca(Sprite[] sprites)
    {
        addTrinca(new TrincaColetaveisDescartadosDto(sprites, Time.time));
    }
}
