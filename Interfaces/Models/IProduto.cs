namespace UGB.Interface
{
    public interface IProduto
    {
        public string ProdEan { get; set; }

        public string? ProdNome { get; set; }

        public string? ProdPreco { get; set; }

        public string? ProdFabricante { get; set; }

        public string? ProdEstoqueminimo { get; set; }

        public string? UsuarioUserMat { get; set; }
    }
}