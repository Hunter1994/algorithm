namespace WebApplication4
{
    public class RequestTimeLogger
    {
        private DateTime startTime;

        public RequestTimeLogger()
        {
            startTime = DateTime.Now;
        }

        public DateTime LogEndTime()
        {
            return startTime;
        }
    }
}
