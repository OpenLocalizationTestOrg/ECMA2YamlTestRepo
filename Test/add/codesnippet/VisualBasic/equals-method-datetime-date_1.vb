      Dim today1 As New System.DateTime(System.DateTime.Today.Ticks)
      Dim today2 As New System.DateTime(System.DateTime.Today.Ticks)
      Dim tomorrow As New System.DateTime( _
                              System.DateTime.Today.AddDays(1).Ticks)

      ' todayEqualsToday gets true.
      Dim todayEqualsToday As Boolean = System.DateTime.Equals(today1, today2)

      ' todayEqualsTomorrow gets false.
      Dim todayEqualsTomorrow As Boolean = System.DateTime.Equals(today1, tomorrow)