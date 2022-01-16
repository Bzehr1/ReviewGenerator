using System.Threading.Tasks;

namespace ReviewGenerator.Core.Interfaces
{
    public interface IDataReaderService
    {
        Task ReadData(string fileName);
    }
}
