using ApiCarros.DataContext;
using ApiCarros.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCarros.Service
{
    public class CarroService : ICarro
    {
        private readonly ApplicationDbContext _context;

        public CarroService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<CarroModel>>> CreateCarro(CarroModel carro)
        {
            ServiceResponse<List<CarroModel>> serviceResponse = new ServiceResponse<List<CarroModel>>();

            try
            {
                if(carro == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Informe os dados";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                _context.Add(carro);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Carros.ToList();
            }
            catch (Exception ex) 
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<CarroModel>>> DeleteCarro(int id)
        {
            ServiceResponse<List<CarroModel>> serviceResponse = new ServiceResponse<List<CarroModel>>();

            try
            {
                CarroModel carro = _context.Carros.FirstOrDefault(x => x.id == id);

                if (carro == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Nenhum carro encontrado!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                _context.Carros.Remove(carro);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Carros.ToList();
            }
            catch(Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso= false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<CarroModel>> GetCarroById(int id)
        {
            ServiceResponse<CarroModel> serviceResponse = new ServiceResponse<CarroModel>();

            try
            {
                CarroModel carro = _context.Carros.FirstOrDefault(x => x.id == id);

                if(carro == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Usuário Não Encontrado";
                    serviceResponse.Sucesso = false;
                }

                serviceResponse.Dados = carro;
            }
            catch(Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<CarroModel>>> GetCarros()
        {
            ServiceResponse<List<CarroModel>> serviceResponse = new ServiceResponse<List<CarroModel>>();

            try
            {
                serviceResponse.Dados = _context.Carros.ToList();

                if(serviceResponse.Dados.Count == 0) 
                {
                    serviceResponse.Mensagem = "Nenhum dado encontrado";
                }
            }
            catch (Exception ex) 
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<CarroModel>>> UpdateCarro(CarroModel carroEditado)
        {
            ServiceResponse<List<CarroModel>> serviceResponse = new ServiceResponse<List<CarroModel>>();

            try
            {
                CarroModel carro = _context.Carros.AsNoTracking().FirstOrDefault(x => x.id == carroEditado.id);

                if (carro == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Usuário Não Encontrado!";
                    serviceResponse.Sucesso = false;

                }

                _context.Carros.Update(carro);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Carros.ToList();
            }
            catch(Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }
    }
}
