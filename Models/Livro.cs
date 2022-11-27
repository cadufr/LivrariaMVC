namespace Livraria.Models;
using System.ComponentModel.DataAnnotations;

public class Livro
{
    public int? Id { get; set; }

    [Required(ErrorMessage = "Preencha o campo")]
    public String? Nome { get; set; }

    [Required(ErrorMessage = "Preencha o campo")]
    public String? Descricao { get; set; }

    public Livro()
    {
        
    }

    public Livro(int id, string nome, string descricao)
    {
        Id = id;
        Nome = nome;
        Descricao = descricao;
    }
}