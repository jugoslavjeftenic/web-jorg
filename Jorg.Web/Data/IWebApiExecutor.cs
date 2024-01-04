
namespace Jorg.Web.Data
{
	public interface IWebApiExecutor
	{
		Task<T?> InvokeGet<T>(string relativeUrl);
	}
}