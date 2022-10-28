using OOD_Uppgift.employee;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD_Uppgift.register
{
    internal class SortedListRegistry : BaseRegistry
    {
        private static SortedListRegistry? registry;

        private SortedList<string, Employee> _sortedlist;

        private SortedListRegistry()
        {
            _sortedlist = new SortedList<string, Employee>();
        }

        public override bool Add(string socialId, Employee employee)
        {
            if (_sortedlist.ContainsKey(socialId))
            {
                Console.WriteLine($"Error: Cannot add new Employee with Social ID: {socialId}, because said employee already exists!");
                return false;
            }
            _sortedlist.Add(socialId, employee);
            return true;
        }


        public override Employee? Get(string socialId)
        {
            if (!_sortedlist.ContainsKey(socialId))
            {
                Console.WriteLine($"Error: Cannot get Employee with Social ID: {socialId}, because said employee doesn't exist!");
                return null;
            }
            return _sortedlist[socialId];
        }

        public override Employee? Update(string socialId, Employee employee)
        {
            if (_sortedlist.Remove(socialId))
            {
                _sortedlist.Add(socialId, employee);
                return employee;
            }
            Console.WriteLine($"Error: Failed to Update Employee with Social ID: {socialId}");
            return null;
        }

        public override Employee? Update(string socialId, Func<Employee, Employee> updateFunction)
        {
            if (_sortedlist.ContainsKey(socialId))
            {
                Employee employee = _sortedlist[socialId];
                if (_sortedlist.Remove(socialId))
                {
                    updateFunction(employee);
                    return Add(socialId, employee) ? employee : null;
                }
                Console.WriteLine($"Error: Failed to Update Employee with Social ID: {socialId}");
            }
            return null;
        }

        public override bool Remove(string socialId)
        {
            return _sortedlist.Remove(socialId);
        }

        public override void RemoveAll()
        {
            _sortedlist.Clear();
        }

        public static SortedListRegistry GetRegistry()
        {
            if (registry is not null) return registry;
            registry = new SortedListRegistry();
            return registry;
        }
    }
}
