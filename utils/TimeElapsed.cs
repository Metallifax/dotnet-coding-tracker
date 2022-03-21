using System;
using System.Timers;
using static CodingTracker.utils.Utils;

namespace CodingTracker.utils
{
    public class TimeElapsed
    {
        private static Timer _timer;
        private static int _totalSeconds;

        public static void DisplayTimer()
        {
            _timer = new Timer();
            _timer.Interval = 1000;
            _timer.Elapsed += OnTimedEvent;
            _timer.AutoReset = true;
            _timer.Enabled = true;

            Print("Press enter to end coding session");
            Console.ReadLine();
            _timer.Enabled = false;
        }

        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            _totalSeconds++;
            var time = TimeSpan.FromSeconds(_totalSeconds);
            Console.WriteLine("Total elapsed time: {0}:{1}:{2}", time.Hours, time.Minutes, time.Seconds);
        }
    }
}