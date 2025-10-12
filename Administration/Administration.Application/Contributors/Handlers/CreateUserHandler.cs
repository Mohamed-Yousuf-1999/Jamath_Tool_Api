using Administration.Application.Contributors.Commands.CreateContributor;
using Administration.Application.Contributors.DTOs;
using Administration.Domain.Entities;
using Administration.Domain.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Administration.Application.Contributors.Handlers
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, UserResponseDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public CreateUserHandler(IUserRepository userRepository, IMapper mapper, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<UserResponseDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var newUserId = Guid.NewGuid();
            string photoPath = string.Empty;

            var user = _mapper.Map<User>(request.Request);

            if(request.Request.Photo != null)
            {
                photoPath = await SavePhotoAsync(request.Request.Photo, newUserId);
                user.PhotoPath = photoPath;
            }
            if (user.FatherId != null && user.FatherId != Guid.Empty)
            {
                var fatherDetail = await _userRepository.GetFatherDetail(user.FatherId, cancellationToken);
                user.FatherName = fatherDetail?.Name;
            }

            user.Id = newUserId;
            var currentDate = DateTime.Now;
            user.CreateDate = currentDate;
            user.ModifiedDate = currentDate;
           
            await _userRepository.CreateAsync(user);
            await _userRepository.SaveChangesAsync();

            var result = _mapper.Map<UserResponseDto>(user);
            return result;
        }

        public async Task<string?> SavePhotoAsync(IFormFile? file, Guid id)
        {
            if (file == null || file.Length == 0) return null;

            var photoPath = _configuration.GetSection("FileStorage:PhotoPath").Value;

            if (!Directory.Exists(photoPath))
                Directory.CreateDirectory(photoPath);

            var fileName = id.ToString();
            var filePath = Path.Combine(photoPath, fileName);

            using var stream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(stream);

            return filePath; 
        }
    }
}
