using System.Threading.Tasks;

namespace Calendar.Builder.ReleaseProviders
{
    public interface ISerialIdProvider
    {
        Task<string> GetSerialId(string serialAlias);
    }
}