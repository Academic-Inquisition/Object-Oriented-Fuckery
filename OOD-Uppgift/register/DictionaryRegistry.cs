using System;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using OOD_Uppgift.employee;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace OOD_Uppgift.register
{
    internal class DictionaryRegistry : BaseRegistry
    {
        private static DictionaryRegistry? registry;

        private Dictionary<string, Employee> _dictionary;

        private DictionaryRegistry()
        {
            _dictionary = new Dictionary<string, Employee>();
        }

        public override bool Add(string socialId, Employee employee)
        {
            if (_dictionary.ContainsKey(socialId))
            {
                Console.WriteLine($"ERROR: Cannot add new Employee with Social ID: {socialId}, because said employee already exists!");
                return false;
            }
            _dictionary.Add(socialId, employee);
            return true;
        }

        public override Employee? Get(string socialId)
        {
            if (!_dictionary.ContainsKey(socialId))
            {
                Console.WriteLine($"ERROR: Cannot get Employee with Social ID: {socialId}, because said employee doesn't exist!");
                return null;
            }
            return _dictionary[socialId];
        }

        public override Employee? Update(string socialId, Employee employee)
        {
            if (_dictionary.Remove(socialId))
            {
                _dictionary.Add(socialId, employee);
                return employee;
            }
            Console.WriteLine($"ERROR: Failed to Update Employee with Social ID: {socialId}");
            return null;
        }

        public override Employee? Update(string socialId, Func<Employee, Employee> updateFunction)
        {
            if (_dictionary.ContainsKey(socialId))
            {
                Employee employee = _dictionary[socialId];
                if (_dictionary.Remove(socialId))
                {
                    updateFunction(employee);
                    return Add(socialId, employee) ? employee : null;
                }
                Console.WriteLine($"ERROR: Failed to Update Employee with Social ID: {socialId}");
            }
            return null;  
        }

        public override bool Remove(string socialId)
        {
            return _dictionary.Remove(socialId);
        }

        public override void RemoveAll()
        {
            _dictionary.Clear();
        }

        public static DictionaryRegistry GetRegistry()
        {
            if (registry is not null) return registry;
            registry = new DictionaryRegistry();
            return registry;
        }
    }
}
