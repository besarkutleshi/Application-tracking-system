using ATS.Application.DTO_s.Administration.Modules;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Application.Features.Administration.Module.Queries
{
    public class GetModulesHandler : IRequestHandler<GetModulesQuery, List<ModuleDTO>>
    {

        public Task<List<ModuleDTO>> Handle(GetModulesQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
