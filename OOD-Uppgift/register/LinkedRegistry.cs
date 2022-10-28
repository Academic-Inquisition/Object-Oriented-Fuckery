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
        private static LinkedRegistry? registry;

        private LinkedList<KeyValuePair<string,Employee>> _linkedRegistry;

        private LinkedRegistry()
        {
            _linkedRegistry= new LinkedList<KeyValuePair<string,Employee>>();
        }

        public override bool Add(string socialId, Employee employee)
        {
            //Does the socialId already exist?
            if (GetKeyValuePair(socialId)!=null)
            {
                //If Yes then Error, and return false
                Console.WriteLine($"Error: Cannot add new Employee with Social ID: {socialId}, because said employee already exists!");
                return false;
            }
            //If No, then we can safley add a new Employee
            _linkedRegistry.AddLast(new KeyValuePair<string,Employee>(socialId, employee));
            return true;
        }

        
        public override Employee? Get(string socialId)
        {
            //Get the SocialID, Employee Value pair from the Social ID 
            var kvp = GetKeyValuePair(socialId);
            if (kvp!=null)
            {
                //If the Emplyee Exists return the Employee
                return  kvp.Value.Value;
            }
            //If not Error
            Console.WriteLine($"Error: Cannot get Employee with Social ID: {socialId}, because said employee doesn't exist!");
            return null;
        }

        public override bool Remove(string socialId)
        {
            //Get the SocialID, Employee Value pair from the Social ID 
            var kvp = GetKeyValuePair(socialId);
            if (kvp != null)
            {
                //if the emplyee was found, remove it
                return _linkedRegistry.Remove(kvp.Value);
            }
            //if the emplyee wasn't found, return false
            return false;
        }

        public override void RemoveAll()
        {
            //This removes all emelemts in the Linkedlist
            _linkedRegistry.Clear();
        }

        public override Employee? Update(string socialId, Employee employee)
        {
            //try to remove the Emplyee
            if (this.Remove(socialId))
            {
                // if it worked add the new employee with the same SocialID
                return this.Add(socialId, employee) ? employee : null;
            }
            //Else error
            Console.WriteLine($"Error: Failed to Update Employee with Social ID: {socialId}");
            return null;
        }

        public override Employee? Update(string socialId, Func<Employee, Employee> updateFunction)
        {
            //Get the SocialID, Employee Value pair from the Social ID 
            var kvp = GetKeyValuePair(socialId);
            if (kvp != null)
            {
                //if Emplyee exists , extract the emplyee variable
                Employee employee = kvp.Value.Value;
                //Try to remove the Employee from the list
                if (this.Remove(socialId))
                {
                    //if that succeded then apply the updateFunc on the extracted Emplyee
                    updateFunction(employee);
                    // and then add the extracted and now modfied Emplyee to list again
                    // and then retrun the now added Employee
                    return this.Add(socialId, employee) ? employee : null;
                }
                //if Employee doesn't exists then error
                Console.WriteLine($"Error: Failed to Update Employee with Social ID: {socialId}");
            }
            return null;
        }

        //---------------------------------------

        //Helper Function
        private KeyValuePair<string, Employee>? GetKeyValuePair(string socialId)
        {
            //Get the first node in the Linkedlist
            LinkedListNode<KeyValuePair<string, Employee>>? node = _linkedRegistry.First;
            //Use a while loop to step through the LinkedList one by one, (linear search)
            while (node != null)
            {
                //Check if the current node has the socialId we are looking for
                if (node.Value.Key == socialId)
                {
                    // If Yes then return the employee
                    return node.Value;
                }
                //If No got to next node
                node = node.Next;
            }
            //If we reached the end of the LinkedList without finding matching scoialID
            return null;
        }

        //----------------------------------------

        public static LinkedRegistry GetRegistry()
        {
            if (registry is not null) return registry;
            registry = new LinkedRegistry();
            return registry;
        }
    }
}
