namespace MarsRoverProject.Classes
{
    using System;

    public class StringValue : Attribute
    {
        public string Text;
        public StringValue(string text)
        {
            Text = text;
        }
    }
}
