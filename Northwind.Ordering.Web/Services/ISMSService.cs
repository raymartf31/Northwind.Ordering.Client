using System.Threading.Tasks;

namespace Northwind.Ordering.Web.Services
{
    public interface ISMSService
    {
        Task Send();
    }
}
