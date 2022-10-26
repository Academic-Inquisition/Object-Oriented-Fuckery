using System;

namespace OOD_Uppgift.employee
{
    public enum WorkerType
    {
        Ant = 1,
        Bumblebee = 2,
        Giraff = 3
    }
    public static class WorkerTypeHandler

    {
        public static Dictionary<int, string> getTypes()
        {
            Dictionary<int, string> result = new Dictionary<int, string>();
            foreach (WorkerType wt in Enum.GetValues(typeof(WorkerType)))
                result.Add((int)wt, wt.ToString());

            return result;
        }
    }
}
