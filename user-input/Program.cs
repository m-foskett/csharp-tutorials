﻿using System;

public class TextInput
{
    public string current;

    public virtual void Add(char c)
    {
        current += c;
    }

    public string GetValue()
    {
        return current;
    }

    public TextInput()
    {
        current = "";
    }
}

public class NumericInput : TextInput
{
    public override void Add(char c)
    {
        if (Char.IsDigit(c))
        {
            current += c;
        }
    }
}

public class UserInput
{
    public static void Main(string[] args)
    {
        TextInput input = new NumericInput();
        input.Add('1');
        input.Add('a');
        input.Add('0');
        Console.WriteLine(input.GetValue());
    }
}