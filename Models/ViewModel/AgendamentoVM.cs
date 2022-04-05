using System;

namespace Models.ViewModel
{
    public class AgendamentoVM
    {
        public TimeSpan horario { get; set; }
        public string paciente { get; set; }
        public string procedimentos { get; set; }
        public string status { get; set; }
    }
}
