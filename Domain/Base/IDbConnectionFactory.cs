using System.Data;

namespace Domain.Base
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateConnection();
    }
}
