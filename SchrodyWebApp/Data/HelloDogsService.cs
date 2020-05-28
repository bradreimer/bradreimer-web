using System.Threading.Tasks;

namespace SchrodyWebApp.Data
{
	public class HelloDogsService
	{
		private readonly HelloDogs m_helloDogs = new HelloDogs();

		public Task<HelloDogs> GetHelloDogsAsync()
		{
			return Task.FromResult(m_helloDogs);
		}

		public Task IncrementFletchAsync()
		{
			++m_helloDogs.FletchCount;
			return Task.CompletedTask;
		}

		public Task IncrementFibsAsync()
		{
			++m_helloDogs.FibsCount;
			return Task.CompletedTask;
		}
	}
}
