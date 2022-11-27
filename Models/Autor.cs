namespace Livraria.Models;
using System.ComponentModel.DataAnnotations;

public class Autor
{
    public int? Id { get; set; }

    [Required(ErrorMessage = "Preencha o campo")]
    public String? Nome { get; set; }

    [Required(ErrorMessage = "Preencha o campo")]
    public int? Idade { get; set; }

    public Autor()
    {
        
    }

    public Autor(int id, string nome, int idade)
    {
        Id = id;
        Nome = nome;
        Idade = idade;
    }
}