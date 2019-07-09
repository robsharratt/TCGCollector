using System;
namespace TCGCollector.Models
{
    public class AttackEnergy
    {
        public int AttackEnergyID { get; set; }

        public int AttackID { get; set; }
        public Attack Attack { get; set; }
        public int EnergyTypeID { get; set; }
        public EnergyType EnergyType { get; set; }
    }
}
