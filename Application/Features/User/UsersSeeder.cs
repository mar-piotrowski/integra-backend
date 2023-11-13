using Application.Abstractions;
using Application.Abstractions.Repositories;
using Domain.Entities;
using Domain.Enums;

namespace Application.Features.User;

public class UsersSeeder {
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;
    
    public UsersSeeder(IUnitOfWork unitOfWork, IUserRepository userRepository) {
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
        // Seed();
    }

    // public void Seed() /*{*/
        // if (_dbContext.Users.FirstOrDefault(u => u.Email == "admin@integra.com") is not null)
        //     return;
        // _dbContext.Users.Add(DefaultSuperUser);
        // _dbContext.SaveChanges();
    // }

    // private static Domain.Entities.User DefaultSuperUser => new Domain.Entities.User() {
    //     Firstname = "Admin",
    //              Lastname = "Admin",
    //              Email = "admin@integra.com",
    //              IsStudent = false,
    //              Credential = new Credential() {
    //                  Password = "admin123",
    //                  Permission = Permission.Administrator
    //              }
    // };
}