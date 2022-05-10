namespace Skul.Entities
{
    public interface IPlace
    {
        string Address { get; set; }

        void CleanPlace();
    }
}