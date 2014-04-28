using System.Threading.Tasks;

namespace SerialsCalendar
{
    public interface ISerialIdProvider
    {
        Task<string> GetSerialId(string serialAlias);
    }
}