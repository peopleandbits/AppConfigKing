namespace AppConfigKing
{
    public interface ICmd
    {
        string Execute();
        bool ResultOK { get; set; }
    }
}
