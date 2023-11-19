using SistemaPacientes.Core.Application.ViewModels.Cita;
using SistemaPacientes.Core.Application.ViewModels.PruebaLaboratorio;
using SistemaPacientes.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPacientes.Core.Application.ViewModels.ResultadoLaboratorio
{
    public class ResultadoLaboratorioSaveViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo prueba es requerido")]
        [DataType(DataType.Currency)]
        public int IdPruebaL { get; set; }
        [Required(ErrorMessage = "El campo Cita es requerido")]
        [DataType(DataType.Currency)]
        public int IdCita { get; set; }
        [Required(ErrorMessage = "El campo Estado es requerido")]

        public bool Estado { get; set; }
        [DataType(DataType.Currency)]
        public int? IdPaciente { get; set; }
        public CitaSaveViewModel? cita { get; set; }
        public ICollection<PruebaLaboratorioViewModel>? pruebaLaboratorio { get; set; }
    }
}
