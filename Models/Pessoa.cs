using System;
using System.ComponentModel.DataAnnotations;

namespace cadastro_cliente_mvc.Models
{
    public class Pessoa
    {
        [Display(Name = "id")]
        public int pessoaId { get; set; }

        [Display(Name = "Tipo")]
        public String tipoPessoa { get; set; }
        public String CPF { get; set; }

        [Display(Name = "Data de Nascimento")]
        public DateTime? DataNascimento { get; set; }
        public String Nome { get; set; }
        public String Sobrenome { get; set; }
        public String CNPJ { get; set; }

        [Display(Name = "Razão Social")]
        public String RazaoSocial { get; set; }

        [Display(Name = "Nome Fantasia")]
        public String NomeFantasia { get; set; }
        public String CEP { get; set; }
        public String Logradouro { get; set; }
        public int Numero { get; set; }
        public String Completemento { get; set; }
        public String Bairro { get; set; }
        public String Cidade { get; set; }
        public String UF { get; set; }
    }
}