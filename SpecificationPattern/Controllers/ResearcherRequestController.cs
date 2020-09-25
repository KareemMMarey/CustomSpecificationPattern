using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using System.Text;
namespace API.Controllers {

    [Authorize]
     
    public class ResearcherRequestController : BaseApiController {
        private readonly IResearcherRequestService _requestService;
        private readonly UserManager<ResearcherAppUser> _userManager;
        private readonly IMapper _mapper;
        public ResearcherRequestController (IResearcherRequestService requestService,
                                            IMapper mapper,
                                            UserManager<ResearcherAppUser> userManager) {
            _mapper = mapper;
            _requestService = requestService;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<RequestDTO>>> GetRequestsForUser () {
            
            var email = HttpContext.User.RetrieveEmailFromPrincipal();
            if(string.IsNullOrEmpty(email))
              return BadRequest(new ApiResponse(401, "Do not have permission"));

              // Find user by mail 
              var user = await _userManager.FindByEmailAsync (email);
                if (user == null) {
                    return Unauthorized (new ApiResponse (401));
                }
            var request = await _requestService.GetRequestsForUserAsync(user.Id);
           
            return Ok(request);
            
        }
        
    } 
}