using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD_Uppgift.employee
{
    public class Equipments
    {
        private static List<IEquipment> Items = new();

        // Attire
        public static IEquipment PLIERS = Register(new Tool("Pliers", "Pulls Nails"));
        public static IEquipment HAMMER = Register(new Tool("Hammer", "Hammers Planks"));
        public static IEquipment SAW = Register(new Tool("Saw", "Saws Wood"));
        
        // Attire
        public static IEquipment HARD_HAT = Register(new Attire("Hard Hat", "Protects Yer Nogging"));
        public static IEquipment WORK_PANTS = Register(new Attire("Work Pants", "Protection For Yer Tuchy"));

        public static IEquipment Register(IEquipment equipment)
        {
            Items.Add(equipment);
            return equipment;
        }

    }
}
