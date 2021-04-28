using System;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Faithlife.SurveyApi.Data
{
	public sealed class MySqlConnectionFactory
	{
		public MySqlConnectionFactory(string connectionString)
		{
			m_connectionString = connectionString;
		}

		public async Task<IDbConnection> OpenConnectionAsync(CancellationToken cancellationToken)
		{
			var connection = new MySqlConnection(m_connectionString);
			await connection.OpenAsync(cancellationToken);
			return connection;
		}

		private readonly string m_connectionString;
	}
}
