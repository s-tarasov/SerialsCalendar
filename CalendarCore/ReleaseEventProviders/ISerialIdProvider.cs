using System.Threading.Tasks;

namespace CalendarCore
{
    public interface ISerialIdProvider
    {
        Task<string> GetSerialId(string serialAlias);
    }
}