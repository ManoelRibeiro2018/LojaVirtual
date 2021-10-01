using LojaVirtual.Interface;
using LojaVirtual.Models;
using LojaVirtual.Repositories;
using LojaVirtual.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Service
{
    public class ClientService: IUserService
    {
        private readonly IAuthService _authService;
        private readonly IClienteRepository _clienteRepository;

        public ClientService(IAuthService authService, IClienteRepository clienteRepository)
        {
            _authService = authService;
            _clienteRepository = clienteRepository;
        }
        public LoginViewModel Login(string email, string password)
        {
            var passwordHash = _authService.ComputeSha256Hash(password);
            var user = _clienteRepository.Login(email, passwordHash);

            if (user == null)
            {
                return null;
            }

            var token = _authService.GenerateJwtToken(user.Email, user.Role);

            return new LoginViewModel(user.Email, token);
        }

        public int Insert(User cliente)
        {
            var passwordHash = _authService.ComputeSha256Hash(cliente.Senha);
            cliente.Senha = passwordHash;
            return _clienteRepository.Insert(cliente).Id;
        }

        public void Update(int id, User cliente)
        {
            _clienteRepository.Update(id, cliente);
        }

        public void Delete(int id)
        {
            _clienteRepository.Delete(id);
        }
    }
}
