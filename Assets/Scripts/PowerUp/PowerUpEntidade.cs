using UnityEngine;

public class PowerUpEntidade 
{
    private static PowerUpPrefabDto[] powerUpDtos;

    public int indice { get; private set; }
    public string nome { get; private set; }    
    public string familia { get; private set; }
    public string descCurta { get; private set; }
    public string descDetalhada { get; private set; }
    public string preco { get; private set; }

    public bool isClicavel { get; private set; }
    public bool isColetavel { get; private set; }

    public int duracao { get; private set; }

    public PowerUpEnums.TIPO tipo { get; private set; }
    public PowerUpEnums.AREA area { get; private set; }
    public Sprite sprPowerUp { get { return powerUpDtos[indice].SprGO; }}

    private Fornecedor<AbstractPowerUpGo> fornecedorPowerUpGo;
    private AbstractPowerUpGo powerUpGo;

    public PowerUpEntidade()
    {
        isColetavel = false;
        area = PowerUpEnums.AREA.NONE;
        this.preco = "1";
    }    

    public PowerUpEntidade configNomes(int indice, PowerUpEnums.TIPO tipoEntidade, string nome)
    {
        this.indice = indice;
        tipo = tipoEntidade;
        this.nome = nome;        
        return this;
    }

    public PowerUpEntidade configFamilia(string familia)
    {
        this.familia = familia;
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

    public PowerUpEntidade configPreco(int preco)
    {
        this.preco = preco.ToString();
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
        PrefabDePowerUpsDto prefabPUpDto = goPrefabPupDto.GetComponent<PrefabDePowerUpsDto>();
        powerUpDtos = prefabPUpDto.PowerUpDtos;
    }
}
