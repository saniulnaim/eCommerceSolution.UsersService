using Dapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Infrastructure.DbContext;

namespace eCommerce.Infrastructure.Repositories
{
    internal class UsersRepository : IUsersRepository
    {
        private readonly DapperDbContext _dbContext;

        public UsersRepository(DapperDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ApplicationUser?> AddUsers(ApplicationUser user)
        {
            user.UserID = Guid.NewGuid();

            string query = "INSERT INTO public.\"Users\" (\"UserID\", \"PersonName\", \"Email\", \"Password\", \"Gender\") VALUES (@UserID, @PersonName, @Email, @Password, @Gender)";
            int rowCountAffected = await _dbContext.DbConnection.ExecuteAsync(query, user);

            if (rowCountAffected > 0) { return user; }

            return null;
        }

        public async Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password)
        {
            string query = "SELECT * FROM public.\"Users\" WHERE \"Email\" = @Email AND \"Password\" = @Password";
            var parameters = new { Email = email, Password = password };
            var user = await _dbContext.DbConnection.QueryFirstOrDefaultAsync<ApplicationUser>(query, parameters);

            //return new ApplicationUser()
            //{
            //    UserID = Guid.NewGuid(),
            //    PersonName = "Test User",
            //    Gender = GenderOptions.Male.ToString(),
            //    Email = email,
            //    Password = password
            //};
            return user;
        }
    }
}
