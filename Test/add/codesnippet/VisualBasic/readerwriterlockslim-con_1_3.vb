Public Module Example
   Public Sub Main()
      Dim sc As New SynchronizedCache()
      Dim tasks As New List(Of Task)
      Dim itemsWritten As Integer
      
      ' Execute a writer.
      tasks.Add(Task.Run( Sub()
                             Dim vegetables() As String = { "broccoli", "cauliflower",
                                                            "carrot", "sorrel", "baby turnip",
                                                            "beet", "brussel sprout",
                                                            "cabbage", "plantain",
                                                            "spinach", "grape leaves",
                                                            "lime leaves", "corn",
                                                            "radish", "cucumber",
                                                            "raddichio", "lima beans" }
                             For ctr As Integer = 1 to vegetables.Length
                                sc.Add(ctr, vegetables(ctr - 1))
                             Next
                             itemsWritten = vegetables.Length
                             Console.WriteLine("Task {0} wrote {1} items{2}",
                                               Task.CurrentId, itemsWritten, vbCrLf)
                          End Sub))
      ' Execute two readers, one to read from first to last and the second from last to first.
      For ctr As Integer = 0 To 1
         Dim flag As Integer = ctr
         tasks.Add(Task.Run( Sub()
                                Dim start, last, stp As Integer
                                Dim items As Integer
                                Do
                                   Dim output As String = String.Empty
                                   items = sc.Count
                                   If flag = 0 Then
                                      start = 1 : stp = 1 : last = items
                                   Else
                                      start = items : stp = -1 : last = 1
                                   End If
                                   For index As Integer = start To last Step stp
                                      output += String.Format("[{0}] ", sc.Read(index))
                                   Next
                                   Console.WriteLine("Task {0} read {1} items: {2}{3}",
                                                           Task.CurrentId, items, output,
                                                           vbCrLf)
                                Loop While items < itemsWritten Or itemsWritten = 0
                             End Sub))
      Next
      ' Execute a red/update task.
      tasks.Add(Task.Run( Sub()
                             For ctr As Integer = 1 To sc.Count
                                Dim value As String = sc.Read(ctr)
                                If value = "cucumber" Then
                                   If sc.AddOrUpdate(ctr, "green bean") <> SynchronizedCache.AddOrUpdateStatus.Unchanged Then
                                      Console.WriteLine("Changed 'cucumber' to 'green bean'")
                                   End If
                                End If
                             Next
                          End Sub ))

      ' Wait for all three tasks to complete.
      Task.WaitAll(tasks.ToArray())

      ' Display the final contents of the cache.
      Console.WriteLine()
      Console.WriteLine("Values in synchronized cache: ")
      For ctr As Integer = 1 To sc.Count
         Console.WriteLine("   {0}: {1}", ctr, sc.Read(ctr))
      Next
   End Sub
End Module
' The example displays output like the following:
'    Task 1 read 0 items:
'
'    Task 3 wrote 17 items
'
'    Task 1 read 17 items: [broccoli] [cauliflower] [carrot] [sorrel] [baby turnip] [
'    beet] [brussel sprout] [cabbage] [plantain] [spinach] [grape leaves] [lime leave
'    s] [corn] [radish] [cucumber] [raddichio] [lima beans]
'
'    Task 2 read 0 items:
'
'    Task 2 read 17 items: [lima beans] [raddichio] [cucumber] [radish] [corn] [lime
'    leaves] [grape leaves] [spinach] [plantain] [cabbage] [brussel sprout] [beet] [b
'    aby turnip] [sorrel] [carrot] [cauliflower] [broccoli]
'
'    Changed 'cucumber' to 'green bean'
'
'    Values in synchronized cache:
'       1: broccoli
'       2: cauliflower
'       3: carrot
'       4: sorrel
'       5: baby turnip
'       6: beet
'       7: brussel sprout
'       8: cabbage
'       9: plantain
'       10: spinach
'       11: grape leaves
'       12: lime leaves
'       13: corn
'       14: radish
'       15: green bean
'       16: raddichio
'       17: lima beans