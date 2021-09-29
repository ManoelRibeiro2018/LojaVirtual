using LojaVirtual.InputModel;
using LojaVirtual.ViewModel;

namespace LojaVirtual.Interface
{
    public interface ICollaboratorService
    {
        LoginViewModel Login(string email, string password);
        int Insert(CollaboratorInputModel collaborator);
        void Update(int id, CollaboratorInputModel collaborator);
        void Delete(int id);
    }
}
