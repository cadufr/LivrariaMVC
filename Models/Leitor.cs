namespace Livraria.Models;
using System.ComponentModel.DataAnnotations;

public class Leitor
{
    public int? Id { get; set; }

    [Required(ErrorMessage = "Preencha o campo")]
    public String? Nome { get; set; }

    [Required(ErrorMessage = "Preencha o campo")]
    public int? Idade { get; set; }

    public Leitor()
    {
        
    }

    public Leitor(int id, string nome, int idade)
    {
        Id = id;
        Nome = nome;
        Idade = idade;
    }
}