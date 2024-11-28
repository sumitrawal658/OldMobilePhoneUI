using System;
using System.Collections.Generic;
using System.Text;

public class Program
{
    public static string OldPhonePad(string input)
    {
        // Key mappings for old phone keypad
        Dictionary<char, string> keypad = new Dictionary<char, string>
        {
            {'1', ""},
            {'2', "ABC"},
            {'3', "DEF"},
            {'4', "GHI"},
            {'5', "JKL"},
            {'6', "MNO"},
            {'7', "PQRS"},
            {'8', "TUV"},
            {'9', "WXYZ"},
            {'0', " "},
            {'*', "BACKSPACE"},
            {'#', "SEND"}
        };

        StringBuilder result = new StringBuilder();
        StringBuilder currentSequence = new StringBuilder();

        for (int i = 0; i < input.Length; i++)
        {
            char currentChar = input[i];

            // Handle backspace
            if (currentChar == '*')
            {
                if (result.Length > 0)
                {
                    result.Remove(result.Length - 1, 1);
                }
                currentSequence.Clear();
                continue;
            }

            // Handle send (#), stop processing input
            if (currentChar == '#')
            {
                break;
            }

            // Append to sequence if the same button is pressed repeatedly
            if (currentSequence.Length > 0 && currentChar == currentSequence[0])
            {
                currentSequence.Append(currentChar);
            }
            else
            {
                // Process the current sequence into a letter
                if (currentSequence.Length > 0)
                {
                    char key = currentSequence[0];
                    int pressCount = currentSequence.Length;
                    if (keypad.ContainsKey(key) && !string.IsNullOrEmpty(keypad[key]))
                    {
                        string characters = keypad[key];
                        char selectedChar = characters[(pressCount - 1) % characters.Length];
                        result.Append(selectedChar);
                    }
                }

                // Start a new sequence
                currentSequence.Clear();
                currentSequence.Append(currentChar);
            }
        }

        // Handle the last sequence
        if (currentSequence.Length > 0)
        {
            char key = currentSequence[0];
            int pressCount = currentSequence.Length;
            if (keypad.ContainsKey(key) && !string.IsNullOrEmpty(keypad[key]))
            {
                string characters = keypad[key];
                char selectedChar = characters[(pressCount - 1) % characters.Length];
                result.Append(selectedChar);
            }
        }

        return result.ToString();
    }

    public static void Main()
    {
        // Test cases
        Console.WriteLine(OldPhonePad("33#")); // Output: E
        Console.WriteLine(OldPhonePad("227*#")); // Output: B
        Console.WriteLine(OldPhonePad("4433555 555666#")); // Output: HELLO
    }
}
