namespace Trade.Core.Job
{
    public interface IJob
    {
        JobResultCode Execute(string[] args);
    }

    public enum JobResultCode
    {
        Success = 0,
        Fail = 1,
        Timeout = 2,
    }
}
