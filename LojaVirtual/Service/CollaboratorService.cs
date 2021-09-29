using LojaVirtual.InputModel;
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

        public int Insert(CollaboratorInputModel collaborator)
        {
            var model = new Collaborator
            {
                Email = collaborator.Email,
                Name = collaborator.Name,
                Password = collaborator.Password,
                Type = collaborator.Type
            };

            return _collaboratorRepository.Insert(model).Id;
            
        }       

        public void Update(int id, CollaboratorInputModel collaborator)
        {
            var model = new Collaborator
            {
                Email = collaborator.Email,
                Name = collaborator.Name,
                Password = collaborator.Password,
                Type = collaborator.Type
            };

            _collaboratorRepository.Update(id, model);
        }

        public void Delete(int id)
        {
            _collaboratorRepository.Delete(id);
        }
    }
}
