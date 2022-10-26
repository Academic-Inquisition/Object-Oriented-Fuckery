using System;
using System.ComponentModel;

namespace OOD_Uppgift
{
  public class Util
  {
    public static void ResetProgram(Action input) // Generic Reset Method
    {
      Console.WriteLine();
      Console.WriteLine("Press any key to go back to the Main Menu");
      Console.ReadKey();
      Console.Clear();
      input.Invoke(); // Invoke the passed in Reset Method
    }
    
    // Reads the line and tries to parse the input string to an appropriate generic T value
    public static T? ReadLine<T>(Func<string, string>? inputModifier = null) // Input optional Function alter for the input string
    {
      var input = Console.ReadLine(); // Reads the input string
      if (input == null) // Checks if Null
      {
        return default; // If null return default
      }
      if (inputModifier != null) 
      {
        input = inputModifier.Invoke(input);
      }
      if (typeof(T) == typeof(string)) // If T is a string just return the input
      {
        return (T) (object) input;
      }
      try // Try to get the TypeConverter, Convert it from String to T type using the Type Converter and return either default or T 
      {
        TypeConverter converter = TypeDescriptor.GetConverter(typeof(T)); 
        // Cast ConvertFromString(string text) : object to (T)
        return (T)converter.ConvertFromString(input);
      }
      catch (NotSupportedException)
      {
        return default;
      }
    }
  }
}