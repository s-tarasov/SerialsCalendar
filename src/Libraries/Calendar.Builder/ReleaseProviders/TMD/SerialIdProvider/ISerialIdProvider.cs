using System.Threading.Tasks;

namespace Calendar.Builder.ReleaseProviders.TMD
{
    public interface ISerialIdProvider
    {
        Task<string> GetSerialId(string serialAlias);
    }
}