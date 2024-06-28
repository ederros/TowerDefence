public interface IReloadable
{
    public event System.Action<float> reloadStarted;
    public event System.Action ReloadFinished;
}
