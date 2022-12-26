using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using UsuariosAPI.Data.Dtos;
using UsuariosAPI.Data.Requests;
using UsuariosAPI.Models;


namespace UsuariosAPI.Services
{
    public class CadastroService
    {
        private IMapper _mapper;
        private UserManager<CustomIdentityUser> _userManager;
        private EmailService _emailService;
        private RoleManager<IdentityRole<int>> _roleManage;

        public CadastroService(IMapper mapper, UserManager<CustomIdentityUser> userManager, EmailService emailService = null, RoleManager<IdentityRole<int>> roleManage = null)
        {
            _mapper = mapper;
            _userManager = userManager;
            _emailService = emailService;
            _roleManage = roleManage;
        }

        public Result CadastraUsuario(CreateUsuarioDto createDto)
        {
            Usuario usuario = _mapper.Map<Usuario>(createDto);
            CustomIdentityUser usuarioIdentity = _mapper.Map<CustomIdentityUser>(usuario);
            Task<IdentityResult> resultadoIdentity = _userManager
                .CreateAsync(usuarioIdentity,createDto.Password);
            _userManager.AddToRoleAsync(usuarioIdentity, "regular");
            
            
            if (resultadoIdentity.Result.Succeeded)
            {
                var code = _userManager.GenerateEmailConfirmationTokenAsync(usuarioIdentity).Result; 
                var encodedCode = HttpUtility.UrlEncode(code);
                _emailService.EnviarEmail(new[] {usuarioIdentity.Email},"Link de ativação",usuarioIdentity.Id, encodedCode);
                return Result.Ok().WithSuccess(code);
            }
            else
            {
                return Result.Fail("Falha ao cadastrar usuario");
            }
        }

        public Result AtivaContaUsuario(AtivaContaRequest request)
        {
            var identityUser = _userManager.Users.FirstOrDefault(u => u.Id == request.UsuarioId);
            var identityResult = _userManager.ConfirmEmailAsync(identityUser, request.CodigoDeAtivacao).Result;

            if (identityResult.Succeeded)
            {
                return Result.Ok();
            }
            return Result.Fail("Falha ao ativar conta de usuário");
        }
    }
}
