public class BoardOrdem 
{
    public int ordem { get; private set; }
    public string nome{ get; private set; }    

    public BoardOrdem(int ordem, string nome)
    {
        this.ordem = ordem;
        this.nome = nome;
    }    
}
