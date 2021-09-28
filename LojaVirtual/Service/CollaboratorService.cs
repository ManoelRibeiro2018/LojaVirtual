using LojaVirtual.Interface;
using LojaVirtual.Models;
using LojaVirtual.Repository.Interface;
using LojaVirtual.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Service
{
    public class CollaboratorService : ICollaboratorService
    {
        private readonly IAuthService _authService;
        private readonly ICollaboratorRepository  _collaboratorRepository;

        public CollaboratorService(IAuthService authService, ICollaboratorRepository  collaboratorRepository)
        {
            _authService = authService;
            _collaboratorRepository = collaboratorRepository;
        }
        public LoginViewModel Login(string email, string password)
        {
            var passwordHash = _authService.ComputeSha256Hash(password);
            var collaborator = _collaboratorRepository.Login(email, passwordHash);
            var token = _authService.GenerateJwtToken(email, collaborator.Type);
            return new LoginViewModel(collaborator.Email, token);

        }

        public int Insert(Collaborator collaborator)
        {
            throw new NotImplementedException();
        }       

        public void Update(int id, Collaborator collaborator)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
