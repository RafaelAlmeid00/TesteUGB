using System;
using System.Collections.Generic;

namespace UGB.Data;

public partial class Serviço
{
    public int ServId { get; set; }

    public string ServNome { get; set; } = null!;

    public string ServDescricao { get; set; } = null!;

    public string ServPrazo { get; set; } = null!;

    public int UsuarioUserMat { get; set; }

    public int FornecedorFornecedorCnpj { get; set; }

}
