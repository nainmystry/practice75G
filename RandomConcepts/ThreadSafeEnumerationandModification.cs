
public class ThirdPartyApp
{
    private static List<string> _propA = new List<string>();
    private static readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1,1);

    static ThirdPartyApp()
    {
        Task.Run(async () => {
            Random random = new Random();
            int indx = 0;
            while (true)
            {
                await _semaphore.WaitAsync();
                try
                {
                    _propA.Add(indx.ToString());
                    if (_propA.Count > 50)
                    {
                        break; 
                    }
                    indx++;
                }
                finally
                {
                    _semaphore.Release();
                }
                await Task.Delay(100);
                //considering some other processing.
            }
        });
    }

    public static async Task<List<string>> GetPropAsync()
    {
        await _semaphore.WaitAsync();
        try
        {
            return new List<string>(_propA);
        }
        finally
        {
            _semaphore.Release();
        }
    }
}

public class CallingApp
{
    public static async Task Run()
    {
        await Task.Run(async() => {
            List<string> X = null;
            while (true)
            {
                                           
                List<string> strings = await ThirdPartyApp.GetPropAsync();
                await Task.Delay(200);  
                //Let the ThirdParty List Load some values
                if(X != null && X.Count == strings.Count)   
                {
                    Console.WriteLine("Closing task. No new elements");
                    break;
                }
                X = new List<string>(strings);                
                foreach (string item in X)
                {
                    Console.WriteLine(item.ToString());                    
                }
            }
        });
    }
}
