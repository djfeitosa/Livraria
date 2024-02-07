using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Livraria.Domain.Enums;

namespace Livraria.Domain.Entities
{
    public class Livro(int livroId, string? titulo, string? autor,
    DateTime lancamento, string? capa, Editora editora, Categoria categoria)
    {
        public int LivroId { get; set; } = livroId;

        [Required(ErrorMessage = "Informe o título do livro")]
        [StringLength(150)]
        public string? Titulo { get; set; } = titulo;

        [Required(ErrorMessage = "Informe o autor do livro")]
        [StringLength(200)]
        public string? Autor { get; set; } = autor;

        [Required(ErrorMessage = "Informe a data de lançamento do livro")]
        public DateTime Lancamento { get; set; } = lancamento;

        [Required(ErrorMessage = "Informe o título do livro")]
        [StringLength(100)]
        public string? Capa { get; set; } = capa;

        [Required]
        [EnumDataType(typeof(Editora), ErrorMessage = "Selecione a editora")]
        public Editora Editora { get; set; } = editora;

        [Required]
        [EnumDataType(typeof(Categoria), ErrorMessage = "Selecione a categoria")]
        public Categoria Categoria { get; set; } = categoria;
    }
}