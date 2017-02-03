// This code example demonstrates the DateTime.ToLongDateString(),
// DateTime.ToLongTimeString(), DateTime.ToShortDateString(), and
// DateTime.ToShortTimeString() methods.

using System;
using System.Threading;
using System.Globalization;

class Sample 
{
    public static void Main() 
    {
    string msg1 = "The date and time patterns are defined in the DateTimeFormatInfo \n" +
                  "object associated with the current thread culture.\n";

// Initialize a DateTime object.
    Console.WriteLine("Initialize the DateTime object to May 16, 2001 3:02:15 AM.\n");
    DateTime myDateTime = new System.DateTime(2001, 5, 16, 3, 2, 15);

// Identify the source of the date and time patterns.
    Console.WriteLine(msg1);

// Display the name of the current culture.
    CultureInfo ci = Thread.CurrentThread.CurrentCulture;
    Console.WriteLine("Current culture: \"{0}\"\n", ci.Name);

// Display the long date pattern and string.
    Console.WriteLine("Long date pattern: \"{0}\"", ci.DateTimeFormat.LongDatePattern);
    Console.WriteLine("Long date string:  \"{0}\"\n", myDateTime.ToLongDateString());

// Display the long time pattern and string.
    Console.WriteLine("Long time pattern: \"{0}\"", ci.DateTimeFormat.LongTimePattern);
    Console.WriteLine("Long time string:  \"{0}\"\n", myDateTime.ToLongTimeString());

// Display the short date pattern and string.
    Console.WriteLine("Short date pattern: \"{0}\"", ci.DateTimeFormat.ShortDatePattern);
    Console.WriteLine("Short date string:  \"{0}\"\n", myDateTime.ToShortDateString());

// Display the short time pattern and string.
    Console.WriteLine("Short time pattern: \"{0}\"", ci.DateTimeFormat.ShortTimePattern);
    Console.WriteLine("Short time string:  \"{0}\"\n", myDateTime.ToShortTimeString());
    }
}

/*
This code example produces the following results:

Initialize the DateTime object to May 16, 2001 3:02:15 AM

The date and time patterns are defined in the DateTimeFormatInfo
object associated with the current thread culture.

Current culture: "en-US"

Long date pattern: "dddd, MMMM dd, yyyy"
Long date string:  "Wednesday, May 16, 2001"

Long time pattern: "h:mm:ss tt"
Long time string:  "3:02:15 AM"

Short date pattern: "M/d/yyyy"
Short date string:  "5/16/2001"

Short time pattern: "h:mm tt"
Short time string:  "3:02 AM"

*/