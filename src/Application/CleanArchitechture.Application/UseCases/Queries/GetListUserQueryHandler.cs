using AutoMapper;
using CleanArchitechture.Application.Abstraction;
using CleanArchitechture.Application.Dtos.User;
using CleanArchitechture.Domain;

namespace CleanArchitechture.Application.UseCases.Queries
{
    internal class GetListUserQueryHandler : IQueryHandler<GetListUserQuery, IEnumerable<ListUserDto>>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetListUserQueryHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ListUserDto>> Handle(GetListUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork._userRepository.GetAll(x => request.Name == null || x.Name == request.Name);
            return _mapper.Map<IEnumerable<ListUserDto>>(user);
        }
    }
}
