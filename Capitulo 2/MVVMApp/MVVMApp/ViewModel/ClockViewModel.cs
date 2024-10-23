namespace MVVMApp.ViewModel
{
    public class ClockViewModel
    {
        public System.Timers.Timer timer { get; set; }
        public string CurrentTime { get; set; }
        public string Name { get; set; }
        public ClockViewModel() { 
            CurrentTime = DateTime.Now.ToString("hh:mm:ss");
            timer = new System.Timers.Timer(1000);
            timer.Elapsed += Update_Time;
            timer.Start();
        }

        public void Update_Time(object? sender, System.Timers.ElapsedEventArgs e)
        {
            this.CurrentTime = DateTime.Now.ToString("hh:mm:ss");
        }

        public void Dispose()
        {
            timer.Dispose();
        }
    }
}
