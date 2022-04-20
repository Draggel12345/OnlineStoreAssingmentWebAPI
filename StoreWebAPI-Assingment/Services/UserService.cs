using AutoMapper;
using StoreWebAPI_Assingment.Models.Data;

namespace StoreWebAPI_Assingment.Services
{
    public interface IUserService
    {

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
    }
}
