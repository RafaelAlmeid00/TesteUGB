namespace UGB.Interface;
public interface IServiço
{

    int ServId { get; set; }
    string ServNome { get; set; }

    string ServDescricao { get; set; }

    string ServPrazo { get; set; }
    int UsuarioUserMat { get; set; }

    int FornecedorFornecedorCnpj { get; set; }
}