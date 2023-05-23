using System;

// To solve the need to combine enums together,
// The [Flags] decorator is used to treat them as bit masks
// Manually initialised with powers of 2 by using bitwise operator OR |
// Limitations: enums are stored into Int32 therefore shouldn't have more than 32 labels
// Side note: using bitwise AND &, can be used to unpack properties
// e.g. (Access.Writer & Access.Submit returns 000100 if present else 000000 if not present)
// Can use this in code to check for presence of property:
// e.g. bool isSubmit = (Access.Writer & Access.Submit) == Access.Submit; (a & b) == b;
// .NET 4.0 allows for the HasFlag method to be used equivalently
// bool isSubmit = Access.Writer.HasFlag(Access.Submit);
// Bitwise NOT ~, used to negate/invert the bits (~000111 = 111000) (a & (~b)) will Unset the flag
// Bitwise XOR ^, can be used to toggle bits (Access.Writer ^= Access.Submit) will toggle the Submit bit to its opposite state
// (a ^ b)
// As used in this code, setting a flag done using (a | b)
public class Account
{
    [Flags]
    public enum Access
    {
        None = 0, //0 000000
        Delete = 1 << 0, //1 000001
        Publish = 1 << 1, //2 000010
        Submit = 1 << 2, //4 000100
        Comment = 1 << 3, //8 001000
        Modify = 1 << 4, //16 010000
        Writer = Submit | Modify, //20 010100
        Editor = Delete | Publish | Comment, //11 001011
        Owner = Writer | Editor, //31 011111
    }

    public static void Main(string[] args)
    {
        //Console.WriteLine(Access.Writer.HasFlag(Access.Delete)); //Should print: "False"
    }
}