namespace ServiceCenterReception.Service
{
    public class RecurringMethodsService: BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                // create a timer to run the function every minute
                var timer = new Timer(_ => MyFunction(), null, TimeSpan.FromSeconds(10), TimeSpan.FromMinutes(1));
                await Task.Delay(Timeout.Infinite, stoppingToken);
            }
        }
        private void MyFunction()
        {
            //call function or code
            Console.WriteLine("running the function every minute");
        }

    }
}
