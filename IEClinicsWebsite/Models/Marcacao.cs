using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace IEClinicsWebsite.Models
{
    public class Marcacao
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Especialidade { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string Medico { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [DisplayName("Nome do utente")]
        public string Paciente { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [DisplayName("Data de nascimento")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [DisplayName("Data da consulta")]
        public DateTime DataConsulta { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [DisplayName("Hora da consulta")]
        public string HoraMarcacao { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public int Telefone { get; set; }
    }
}