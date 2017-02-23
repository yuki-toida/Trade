namespace Trade.UI.Batch
{
    public interface IBatch
    {
        BatchResultCode Execute(string argument);
    }
}
