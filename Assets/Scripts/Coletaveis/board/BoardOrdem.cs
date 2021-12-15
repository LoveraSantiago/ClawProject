public class BoardOrdem 
{
    public int ordem { get; private set; }
    public string nome{ get; private set; }    

    public BoardOrdem(int ordem, string nome)
    {
        this.ordem = ordem;
        this.nome = nome;
    }    

    public void trocarNome(string nome)
    {
        this.nome = nome;
    }

    public bool isNomeEquals(string nome)
    {
        return this.nome.Equals(nome);
    }

    public bool isOrdem(int ordem)
    {
        return this.ordem == ordem;
    }
}
