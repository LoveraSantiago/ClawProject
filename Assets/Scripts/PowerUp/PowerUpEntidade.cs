using System.Collections.Generic;
using UnityEngine;

public class PowerUpEntidade 
{
    private static Dictionary<string, Sprite> dicionarioDeSprites;   

    public string nome { get; private set; }
    public string nomeSpriteBtn { get; private set; }
    public string descCurta { get; private set; }
    public string descDetalhada { get; private set; }

    public bool isClicavel { get; private set; }
    public bool isColetavel { get; private set; }

    public int duracao { get; private set; }

    public PowerUpEnums.TIPO tipo { get; private set; }
    public PowerUpEnums.AREA area { get; private set; }
    public Sprite sprPowerUp { get { return dicionarioDeSprites[nomeSpriteBtn]; }}

    private Fornecedor<AbstractPowerUpGo> fornecedorPowerUpGo;
    private AbstractPowerUpGo powerUpGo;

    public PowerUpEntidade()
    {
        isColetavel = false;
        area = PowerUpEnums.AREA.NONE;
    }    

    public PowerUpEntidade configNomes(PowerUpEnums.TIPO tipoEntidade, string nome, string nomeSpriteBtn)
    {
        tipo = tipoEntidade;
        this.nome = nome;
        this.nomeSpriteBtn = nomeSpriteBtn;
        return this;
    }

    public PowerUpEntidade configIsClicavel(bool clicavel)
    {
        isClicavel = clicavel;
        return this;
    }

    public PowerUpEntidade configDuracao(int duracao)
    {
        this.duracao = duracao;
        return this;
    }

    public PowerUpEntidade configIsColetavel(bool isColetavel)
    {
        this.isColetavel = isColetavel;
        return this;
    }   

    public PowerUpEntidade configArea(PowerUpEnums.AREA area)
    {
        this.area = area;
        return this;
    }

    public PowerUpEntidade configSupplierDePowerUpGo(Fornecedor<AbstractPowerUpGo> supplierPowerUpGo) 
    {
        this.fornecedorPowerUpGo = supplierPowerUpGo;
        return this;
    }

    public PowerUpEntidade configDescricao(string descCurta, string descDetalhada)
    {
        this.descCurta = descCurta;
        this.descDetalhada = descDetalhada;
        return this;
    }

    public AbstractPowerUpGo getPowerUpGo()
    {
        if(powerUpGo == null)
        {
            powerUpGo = fornecedorPowerUpGo.fornecer();
        }
        return powerUpGo;
    }

    public static void configurarDicionarioDeSpritesPup(GameObject goPrefabPupDto)
    {
        PrefabPowerUpDto prefabPUpDto = goPrefabPupDto.GetComponent<PrefabPowerUpDto>();
        dicionarioDeSprites = prefabPUpDto.getInstance().dicionarioDeSprites;
    }
}
