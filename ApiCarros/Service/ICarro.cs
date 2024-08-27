using ApiCarros.Models;

namespace ApiCarros.Service
{
    public interface ICarro
    {
        Task<ServiceResponse<List<CarroModel>>> GetCarros();

        Task<ServiceResponse<List<CarroModel>>> CreateCarro(CarroModel carro);

        Task<ServiceResponse<CarroModel>> GetCarroById(int id);

        Task<ServiceResponse<List<CarroModel>>> UpdateCarro(CarroModel carro);

        Task<ServiceResponse<List<CarroModel>>> DeleteCarro(int id);
    }
}
