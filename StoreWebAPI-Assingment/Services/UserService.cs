using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StoreWebAPI_Assingment.Models.Data;
using StoreWebAPI_Assingment.Models.User;

namespace StoreWebAPI_Assingment.Services
{
    public interface IUserService
    {
        //CRUD
        public Task<UserModel> CreateUserAsync(UserRequest request);
        public Task<IEnumerable<UserModel>> GetUsersAsync();
        public Task<UserModel> GetUserAsync(Guid id);
        public Task<UserModel> UpdateUserAsync(Guid id, UserRequest request);
        public Task<bool> DeleteUserAsync(Guid id);
    }

    public class UserService : IUserService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public UserService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UserModel> CreateUserAsync(UserRequest request)
        {
            if (!await _context.Users.AnyAsync(x => x.EmailAddress == request.EmailAddress))
            {
                var userEntity = _mapper.Map<UserEntity>(request);

                _context.Users.Add(userEntity);
                await _context.SaveChangesAsync();

                return _mapper.Map<UserModel>(userEntity);
            }

            return null!;
        }

        public async Task<IEnumerable<UserModel>> GetUsersAsync()
        {
            return _mapper.Map<IEnumerable<UserModel>>(await _context.Users.ToListAsync());
        }

        public async Task<UserModel> GetUserAsync(Guid id)
        {
            return _mapper.Map<UserModel>(await _context.Users.FirstOrDefaultAsync(x => x.Id == id));
        }

        public async Task<UserModel> UpdateUserAsync(Guid id, UserRequest request)
        {
            var userEntity = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (userEntity != null)
            {
                if (userEntity.FirstName != request.FirstName && !string.IsNullOrEmpty(request.FirstName))
                    userEntity.FirstName = request.FirstName;

                if (userEntity.LastName != request.LastName && !string.IsNullOrEmpty(request.LastName))
                    userEntity.LastName = request.LastName;

                if (userEntity.EmailAddress != request.EmailAddress && !string.IsNullOrEmpty(request.EmailAddress))
                    userEntity.EmailAddress = request.EmailAddress;

                if (userEntity.Password != request.Password && !string.IsNullOrEmpty(request.Password))
                    userEntity.Password = request.Password;

                if (userEntity.PhoneNumber != request.PhoneNumber && !string.IsNullOrEmpty(request.PhoneNumber))
                    userEntity.PhoneNumber = request.PhoneNumber;

                if (userEntity.Country != request.Country && !string.IsNullOrEmpty(request.Country))
                    userEntity.Country = request.Country;

                if (userEntity.City != request.City && !string.IsNullOrEmpty(request.City))
                    userEntity.City = request.City;

                if (userEntity.StreetAddress != request.StreetAddress && !string.IsNullOrEmpty(request.StreetAddress))
                    userEntity.StreetAddress = request.StreetAddress;

                if (userEntity.ZipCode != request.ZipCode && !string.IsNullOrEmpty(request.ZipCode))
                    userEntity.ZipCode = request.ZipCode;

                _context.Entry(userEntity).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return _mapper.Map<UserModel>(userEntity);
            }

            return null!;
        }

        public async Task<bool> DeleteUserAsync(Guid id)
        {
            var userEntity = await _context.Users.FindAsync(id);
            if (userEntity != null)
            {
                _context.Users.Remove(userEntity);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
