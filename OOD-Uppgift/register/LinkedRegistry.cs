using OOD_Uppgift.employee;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD_Uppgift.register
{
    internal class LinkedRegistry : BaseRegistry
    {
        private static DictionaryRegistry? registry;

        private LinkedList<KeyValuePair<string,Employee>> _linkedRegistry;

        public LinkedRegistry()
        {
            _linkedRegistry= new LinkedList<KeyValuePair<string,Employee>>();
        }

        public override bool Add(string socialId, Employee employee)
        {
            //Does the socialId already exist?
            if (GetKeyValuePair(socialId)!=null)
            {
                Console.WriteLine($"Error: Cannot add new Employee with Social ID: {socialId}, because said employee already exists!");
                return false;
            }
            _linkedRegistry.AddLast(new KeyValuePair<string,Employee>(socialId, employee));
            return true;
        }

        
        public override Employee? Get(string socialId)
        {
            var kvp = GetKeyValuePair(socialId);
            if (kvp!=null)
            {
                return  kvp.Value.Value;
            }
            Console.WriteLine($"Error: Cannot get Employee with Social ID: {socialId}, because said employee doesn't exist!");
            return null;
        }

        public override bool Remove(string socialId)
        {
            var kvp = GetKeyValuePair(socialId);
            if (kvp != null)
            {
                return _linkedRegistry.Remove(kvp.Value);
            }
            return false;
            

        }

        public override void RemoveAll()
        {
            _linkedRegistry.Clear();
        }

        public override Employee? Update(string socialId, Employee employee)
        {

            if (this.Remove(socialId))
            {
                return this.Add(socialId, employee) ? employee : null;
            }
            Console.WriteLine($"Error: Failed to Update Employee with Social ID: {socialId}");
            return null;
        }

        public override Employee? Update(string socialId, Func<Employee, Employee> updateFunction)
        {

            var kvp = GetKeyValuePair(socialId);
            if (kvp != null)
            { 
                Employee employee = kvp.Value.Value;
                if (this.Remove(socialId)==true)
                {
                    updateFunction(employee);
                    return this.Add(socialId, employee) ? employee : null;
                }
                Console.WriteLine($"Error: Failed to Update Employee with Social ID: {socialId}");
            }
            return null;
        }

        //---------------------------------------

        //Helper Function
        private KeyValuePair<string, Employee>? GetKeyValuePair(string socialId)
        {
            LinkedListNode<KeyValuePair<string, Employee>>? node = _linkedRegistry.First;
            while (node != null)
            {
                //Check if the current node has the socialId we are looking for
                if (node.Value.Key == socialId)
                {
                    // if yes then return the employee
                    return node.Value;
                }
                node = node.Next;
            }
            return null;
        }

        //----------------------------------------

        public static BaseRegistry GetRegistry()
        {

            if (registry == null)
            {
                registry = new DictionaryRegistry();
                return registry;
            }
            return registry;
        }
    }
}
