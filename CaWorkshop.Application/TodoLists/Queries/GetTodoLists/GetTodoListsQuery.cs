using AutoMapper;
using AutoMapper.QueryableExtensions;
using CaWorkshop.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace CaWorkshop.Application.TodoLists.Queries.GetTodoLists
{
    public class GetTodoListsQuery : IRequest<TodosVm>
    {
    }

    public class GetTodoListsQueryHandler
        : IRequestHandler<GetTodoListsQuery, TodosVm>
    {
        private readonly IApplicationDbContext _context;
        private IMapper _mapper;

        public GetTodoListsQueryHandler(
            IApplicationDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TodosVm> Handle(
            GetTodoListsQuery request,
            CancellationToken cancellationToken)
        {
            var vm = new TodosVm();

            vm.Lists = await _context.TodoLists
                .ProjectTo<TodoListDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return vm;
        }
    }
}