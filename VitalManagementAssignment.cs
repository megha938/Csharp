using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VitalManagementAssignment
{
    public class VitalManagementApp
    {
        public event Action Alarm;
        public int HeartReading { get; set; }

        public void HeartRateVitalSensor()
        {
            Random num = new Random();
            HeartReading = num.Next(50, 160);
        }

        public void Display()
        {
            Console.WriteLine($"Heart Rate : {HeartReading}");
            if (HeartReading < 70 || HeartReading > 120)
            {
                this.NotifyObserver();
            }
        }

        private void NotifyObserver()
        {
            if (Alarm != null)
            {
                Alarm.Invoke(); 
            }

        }

    }

    public class Vibrator
    {
        public void Vibrate()
        {
            Console.WriteLine("Vibrate");
        }
    }

    public class Beeper
    {
        public void BeepSound()
        {
            Console.WriteLine("Beep");
        }
    }


    class vital
    {
        static void Main(string[] args)
        {
            VitalManagementApp _app = new VitalManagementApp();

            Vibrator _vibrator = new Vibrator();
            Beeper _beep = new Beeper();
           

            _app.Alarm += _vibrator.Vibrate;
            _app.Alarm += _beep.BeepSound;

            while (true)
            {
                _app.HeartRateVitalSensor();
                _app.Display();
                System.Threading.Thread.Sleep(3000);
            }
        }
    }
}