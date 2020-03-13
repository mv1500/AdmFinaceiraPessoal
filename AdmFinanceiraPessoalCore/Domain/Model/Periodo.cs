using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmFinanceiraPessoalCore.Domain.Model
{
    public class Periodo
    {
        public enum Month
        {
            NotSet = 0,
            January = 1,
            February = 2,
            March = 3,
            April = 4,
            May = 5,
            June = 6,
            July = 7,
            August = 8,
            September = 9,
            October = 10,
            November = 11,
            December = 12
        }

        public Periodo()
        {

        }

        public static Periodo Hoje()
        {
            return new Periodo
            {
                Fim = DateTime.Now,
                Inicio = DateTime.Today
            };
        }

        public static Periodo MesAtual()
        {

            var date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

            return new Periodo
            {
                Inicio = date,

                Fim = date.AddMonths(1).AddDays(-1)
            };

        }

        public static Periodo SemanaAtual()
        {            
            var inicioSem = DateTime.Now;
            var fimSem = DateTime.Now;

           while(inicioSem.DayOfWeek != DayOfWeek.Sunday) {
               inicioSem = inicioSem.AddDays(-1);            
           }

           while(fimSem.DayOfWeek != DayOfWeek.Saturday)
           {
                fimSem = fimSem.AddDays(1);
           }

            return new Periodo
            {
                Inicio = inicioSem,

                Fim = fimSem
            };
        }

        public static Periodo ProxSem()
        {
            var date = Periodo.SemanaAtual();

            return new Periodo
            {
                Inicio = date.Inicio.AddDays(7),
                Fim = date.Fim.AddDays(7)
            };
        }

        public DateTime Inicio { get; set; }

        public DateTime Fim { get; set; }
    }
}
