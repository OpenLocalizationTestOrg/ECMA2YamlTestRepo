      Dim values() As Decimal = {7.03d, 7.64d, 0.12d, -0.12d, -7.1d, -7.6d}
      Console.WriteLine("  Value          Ceiling          Floor")
      Console.WriteLine()
      For Each value As Decimal In values
         Console.WriteLine("{0,7} {1,16} {2,14}", _
                           value, Math.Ceiling(value), Math.Floor(value))
      Next   
      ' The example displays the following output to the console:
      '         Value          Ceiling          Floor
      '       
      '          7.03                8              7
      '          7.64                8              7
      '          0.12                1              0
      '         -0.12                0             -1
      '          -7.1               -7             -8
      '          -7.6               -7             -8