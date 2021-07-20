using System;
namespace PruebaTecnica.Core.Interfaces
{
    public interface IJwtService
    {
        string Generate(int id);
    }
}
