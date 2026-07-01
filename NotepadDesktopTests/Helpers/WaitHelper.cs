using System.Diagnostics;

public static class WaitHelper
{
    public static void WaitUntil(
        Func<bool> condition,
        int timeoutSeconds = 10)
    {
        var sw = Stopwatch.StartNew();

        while (sw.Elapsed.TotalSeconds < timeoutSeconds)
        {
            if (condition())
                return;

            Thread.Sleep(200);
        }

        throw new TimeoutException();
    }
}