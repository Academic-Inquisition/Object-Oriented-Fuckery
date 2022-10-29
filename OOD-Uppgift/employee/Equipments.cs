using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD_Uppgift.employee
{
    public class Equipments
    {
        private static Equipments? equipments;

        public List<IEquipment> items = new List<IEquipment>();

        private Equipments()
        {
            items.Add(new Tool("Pliers", "Pulls Nails"));
            items.Add(new Tool("Hammer", "Hammers Planks"));
            items.Add(new Attire("Hard Hat", "Protects Yer Nogging"));
            items.Add(new Attire("Work Pants", "Protection For Yer Tuchy"));
        }

        public static Equipments GetEquipments()
        {
            if (equipments == null)
                equipments = new Equipments();
            return equipments;
        }

    }
}
