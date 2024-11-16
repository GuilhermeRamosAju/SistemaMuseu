using AutoMapper;
using SistemaMuseu.Application.DTOs;
using SistemaMuseu.Application.Interfaces;
using SistemaMuseu.Domain.Entities;
using SistemaMuseu.Domain.Interfaces;

namespace SistemaMuseu.Application.Services;

public class CompraService : ICompraService
{
    private readonly ICompraRepository _repository;
    private readonly IMapper _mapper;

    public CompraService(ICompraRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<CompraDTO> AdicionarAsync(Compra compra)
    {
        var compraAdicionada = await _repository.Adicionar(compra);
        return _mapper.Map<CompraDTO>(compraAdicionada);
    }

    public async Task<CompraDTO> DeletarAsync(int id)
    {
        var compraExcluida = await _repository.Deletar(id);
        return _mapper.Map<CompraDTO>(compraExcluida);
    }

    public async Task<CompraDTO> EditarAsync(Compra compraDTO)
    {
        var compra = _mapper.Map<Compra>(compraDTO);
        var compraEditada = await _repository.Editar(compra);
        return _mapper.Map<CompraDTO>(compraEditada);
    }

    public async Task<Compra> ObterPorIdAsync(int id)
    {
        var compra = await _repository.Obter(id);
        return compra;
    }

    public async Task<IEnumerable<Compra>> ObterTodosAsync()
    {
        var compras = await _repository.ObterTodos();
        return compras;
    }
}
