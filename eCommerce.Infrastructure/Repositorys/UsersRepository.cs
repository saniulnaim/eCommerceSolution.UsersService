using Dapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Infrastructure.DbContext;

namespace eCommerce.Infrastructure.Repositorys;

internal class UsersRepository : IUserRepository
{
  private readonly DapperDbContext _dbContext;

  public UsersRepository(DapperDbContext dbContext)
  {
    _dbContext = dbContext;
  }

  public async Task<ApplicationUser?> AddUser(ApplicationUser user)
  {
    // Generate a new GUID for the user
    user.UserId = Guid.NewGuid();

    //Sql Query to insert user into th_e "User" table
    string query = @"INSERT INTO ""Users"" (""UserID"", ""PersonName"", ""Email"", ""Gender"", ""Password"")
                     VALUES (@UserID, @PersonName, @Email, @Gender, @Password);";

    int rowCountAffected = await _dbContext.DbConnection.ExecuteAsync(query, user);
    if (rowCountAffected > 0) 
    {
      return user;
    }
    else 
    {
      return null;
    }
  }

  public async Task<ApplicationUser?> GetUserBYEmailAndPassword(string? email, string? password)
  {
    //SQl query to select a user by Email and Password
    string query = "SELECT * FROM public.\"Users\" WHERE \"Email\"=@Email AND \"Password\"=@Password";

    var parameters = new { Email = email, Password = password };

    ApplicationUser? user = await _dbContext.DbConnection.QueryFirstOrDefaultAsync<ApplicationUser>(query, parameters);

    return user;
  }
}

