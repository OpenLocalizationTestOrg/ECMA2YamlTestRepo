using namespace System;
using namespace System::Runtime::InteropServices;


[StructLayout(LayoutKind::Explicit,Size=16,CharSet=CharSet::Ansi)]
value class MySystemTime
{
public:

   [FieldOffset(0)]
   short wYear;

   [FieldOffset(2)]
   short wMonth;

   [FieldOffset(4)]
   short wDayOfWeek;

   [FieldOffset(6)]
   short wDay;

   [FieldOffset(8)]
   short wHour;

   [FieldOffset(10)]
   short wMinute;

   [FieldOffset(12)]
   short wSecond;

   [FieldOffset(14)]
   short wMilliseconds;
};

ref class LibWrapper
{
public:

   [DllImport("kernel32.dll")]
   static void GetSystemTime( MySystemTime * st );
};

int main()
{
   try
   {
      MySystemTime sysTime;
      LibWrapper::GetSystemTime(  &sysTime );
      Console::WriteLine( "The System time is {0}/{1}/{2} {3}:{4}:{5}", sysTime.wDay, sysTime.wMonth, sysTime.wYear, sysTime.wHour, sysTime.wMinute, sysTime.wSecond );
   }
   catch ( TypeLoadException^ e ) 
   {
      Console::WriteLine( "TypeLoadException : {0}", e->Message );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception : {0}", e->Message );
   }

}
