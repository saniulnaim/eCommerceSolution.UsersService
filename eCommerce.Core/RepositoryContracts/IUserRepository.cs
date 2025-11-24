using eCommerce.Core.Entities;

namespace eCommerce.Core.RepositoryContracts;

public interface IUserRepository
{
  /// <summary>
  /// Method to add a new user to the repository.
  /// </summary>
  /// <param name="user"></param>
  /// <returns></returns>
  Task<ApplicationUser?> AddUser(ApplicationUser user);

  /// <summary>
  /// Method to retrieve a user by email and password.
  /// </summary>
  /// <param name="email"></param>
  /// <param name="password"></param>
  /// <returns></returns>
  Task<ApplicationUser?> GetUserBYEmailAndPassword(string?email, string? password);
}

