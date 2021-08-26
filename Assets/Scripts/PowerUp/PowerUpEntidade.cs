using System.Collections.Generic;
using UnityEngine;

public class PowerUpEntidade 
{
    private static Dictionary<string, Sprite> dicionarioDeSprites;

    public enum TIPO
    {
        BOMBA_DA_GARRA, MISSIL_NUCLEAR, MINA_TERRESTRE, MISSIL_TELEGUIADO,
        TELEPORTE, ASAS, ROLLBACK, NONE
    }

    public enum AREA
    {
        CHAO, NONE
    }

    public enum INTERACAOGARRA
    {
        MOVIMENTO, PARADO, NAO_INTERACAO
    }

    public TIPO tipo   { get; private set; }
    public Sprite sprPowerUp { get { return dicionarioDeSprites[nomeSpriteBtn]; }}
    public int duracao { get; private set; }
    public string nomeSpriteBtn { get; private set; }
    public bool isClicavel { get; private set; }
    public AREA area { get; private set; }

    private Fornecedor<AbstractPowerUpGo> fornecedorPowerUpGo;
    private AbstractPowerUpGo powerUpGo;

    public PowerUpEntidade()
    {   
    }    

    public PowerUpEntidade configNomes(TIPO tipoEntidade, string nomeSpriteBtn)
    {
        tipo = tipoEntidade;
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

    public PowerUpEntidade configArea()
    {
        return configArea(AREA.NONE);
    }

    public PowerUpEntidade configArea(AREA area)
    {
        this.area = area;
        return this;
    }

    public PowerUpEntidade configSupplierDePowerUpGo(Fornecedor<AbstractPowerUpGo> supplierPowerUpGo) 
    {
        this.fornecedorPowerUpGo = supplierPowerUpGo;
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
