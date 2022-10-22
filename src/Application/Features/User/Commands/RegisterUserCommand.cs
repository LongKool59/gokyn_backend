using Application.Features.Commands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.User.Commands
{
    public class RegisterUserCommand : IRequest<ApplicationUser>
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        //public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, ApplicationUser>
        //{
        //    private readonly IApplicationDbContext _context;
        //    private readonly UserManager<ApplicationUser> _userManager;
        //    private readonly RoleManager<IdentityRole> _roleManager;
        //    private readonly JWT _jwt;
        //    public RegisterUserCommandHandler(IApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IOptions<JWT> jwt)
        //    {
        //        _context = context;
        //    }
        //    public async Task<ApplicationUser> Handle(RegisterUserCommand command, CancellationToken cancellationToken)
        //    {
        //        ApplicationUser user = new ApplicationUser
        //        {
        //            UserName = command.Username,
        //            Email = command.Email,
        //            FirstName = command.FirstName,
        //            LastName = command.LastName
        //        };

        //        var userWithSameEmail = await _userManager.FindByEmailAsync(model.Email);
        //    }
        //}
    }
}
