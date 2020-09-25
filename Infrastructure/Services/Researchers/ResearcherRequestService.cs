using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities.AdminModels;
using Core.Interfaces;
using Core.Interfaces.Researchers;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.Researchers {
    public class ResearcherRequestService : IResearcherRequestService {
        private readonly IResearcherAdminUnitOfWork _unitOfWork;
        public ResearcherRequestService (IResearcherAdminUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;

        }
        
        public async Task<IReadOnlyList<RequestForms>> GetRequestsForUserAsync (string userId) {
           var spec = new RequestWithIncludesSpecification (userId);
            return await _unitOfWork.Repository<RequestForms>().ListAsync(spec);
        }

        
    }
}