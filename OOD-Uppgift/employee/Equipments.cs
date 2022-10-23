using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD_Uppgift.employee
{
    public static class Equipments
    {
    public static List<IEquipment> items = new List<IEquipment>();

    public static void init()
        {
        register(new Tool("Hammer", "Hammers Planks"));
        register(new Tool("Pliers", "Pulls Nails"));
        register(new Attire("Hard Hat", "Protects Yer Nogging"));
        register(new Attire("Work Pants", "Protection For Yer Tuchy"));

    }
    public static IEquipment register(IEquipment equipment)
        {
            items.Add(equipment);
            return equipment;
        }

    }
}
