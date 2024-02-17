using Application.Abstractions;
using Application.Abstractions.Repositories;
using Application.Dtos;
using Application.Mappers;
using Domain.Common.Errors;
using Domain.Common.Result;
using Domain.ValueObjects;
using Domain.ValueObjects.Ids;
using MediatR;

namespace Application.Features.User.UpdateUser;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Result> {
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork) {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateUserCommand request, CancellationToken cancellationToken) {
        var user = _userRepository.FindById(request.UserId);
        if (user is null)
            return Result.Failure(UserErrors.NotFound);
        user.Update(
            request.Firstname,
            request.Lastname,
            !string.IsNullOrEmpty(request.Email) ? Email.Create(request.Email) : null,
            PersonalIdNumber.Create(request.IdentityNumber),
            !string.IsNullOrEmpty(request.DocumentNumber) ? DocumentNumber.Create(request.DocumentNumber) : null,
            string.IsNullOrWhiteSpace(request.Phone) ? null : Phone.Create(request.Phone),
            request.SecondName,
            request.IsStudent,
            request.DateOfBirth,
            request.PlaceOfBirth,
            request.Sex,
            request.Citizenship,
            request.Nip
        );
        if (request.Locations is not null)
            UpdateLocations(user, request.Locations);
        if (request.BankAccount is not null && user.BankAccount is not null)
            user.BankAccount.Update(request.BankAccount.Name, request.BankAccount.Number);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }

    private void UpdateLocations(Domain.Entities.User user, List<LocationDto> locations) {
        if (!user.Locations.Any()) {
            foreach (var locationDto in locations)
                user.AddLocation(locationDto.MapToEntity());
            return;
        }

        foreach (var locationDto in locations) {
            var userLocation = user
                .Locations
                .FirstOrDefault(userLocation => userLocation.Id == LocationId.Create(locationDto.Id));
            userLocation?.Update(
                locationDto.Street,
                locationDto.HouseNo,
                locationDto.ApartmentNo,
                locationDto.PostalCode,
                locationDto.City,
                locationDto.Country,
                locationDto.Province,
                locationDto.Commune,
                locationDto.District,
                locationDto.IsPrivate,
                locationDto.IsCompany
            );
        }
    }
}