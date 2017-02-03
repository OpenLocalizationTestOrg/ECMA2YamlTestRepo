      var lockObj = new Object();
      var timeout = TimeSpan.FromMilliseconds(500);
      bool lockTaken = false;
      
      try {
         Monitor.TryEnter(lockObj, timeout, ref lockTaken);
         if (lockTaken) {
            // The critical section.
         }
         else {
            // The lock was not acquired.
         }
      }
      finally {
         // Ensure that the lock is released.
         if (lockTaken) {
            Monitor.Exit(lockObj);
         }
      }