public class FichaEntidade
{ 
    public Ficha ficha { get; private set; }
    public int limiteFree { get; private set; }
    public int intervaloHoras { get; private set; }
    public int intervaloMinutos { get; private set; }

    private FichaEntidade(Ficha ficha, int limiteFree, int intervaloHoras, int intervaloMinutos)
    {
        this.ficha = ficha;
        this.limiteFree = limiteFree;
        this.intervaloHoras = intervaloHoras;
        this.intervaloMinutos = intervaloMinutos;
    }

    public static readonly FichaEntidade OURO   = new FichaEntidade(Ficha.OURO, 2, 1, 30);
    public static readonly FichaEntidade PRATA  = new FichaEntidade(Ficha.PRATA, 4, 1, 00);
    public static readonly FichaEntidade BRONZE = new FichaEntidade(Ficha.BRONZE, 6, 0, 30);

    public static FichaEntidade getFichaEntidade(Ficha ficha)
    {
        if (ficha == Ficha.OURO)   return OURO;
        if (ficha == Ficha.PRATA)  return PRATA;
        if (ficha == Ficha.BRONZE) return BRONZE;

        return null;
    }
}
