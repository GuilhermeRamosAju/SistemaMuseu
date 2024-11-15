using AutoMapper;
using SistemaMuseu.Application.DTOs;
using SistemaMuseu.Application.Interfaces;
using SistemaMuseu.Domain.Entities;
using SistemaMuseu.Domain.Interfaces;

namespace SistemaMuseu.Application.Services;

public class FornecedorService : IFornecedorService
{
    private readonly IFornecedorRepository _repository;
    private readonly IMapper _mapper;

    public FornecedorService(IFornecedorRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<FornecedorDTO> AdicionarAsync(FornecedorDTO fornecedorDTO)
    {
        var fornecedor = _mapper.Map<Fornecedor>(fornecedorDTO);
        var fornecedorAdicionado = await _repository.Adicionar(fornecedor);
        return _mapper.Map<FornecedorDTO>(fornecedorAdicionado);
    }

    public async Task<FornecedorDTO> DeletarAsync(int id)
    {
        var fornecedorExcluido = await _repository.Deletar(id);
        return _mapper.Map<FornecedorDTO>(fornecedorExcluido);
    }

    public async Task<FornecedorDTO> EditarAsync(FornecedorDTO fornecedorDTO)
    {
        var fornecedor = _mapper.Map<Fornecedor>(fornecedorDTO);
        var fornecedorEditado = await _repository.Editar(fornecedor);
        return _mapper.Map<FornecedorDTO>(fornecedorEditado);
    }

    public async Task<FornecedorDTO> ObterPorIdAsync(int id)
    {
        var fornecedor = await _repository.Obter(id);
        return _mapper.Map<FornecedorDTO>(fornecedor);
    }

    public async Task<IEnumerable<FornecedorDTO>> ObterTodosAsync()
    {
        var fornecedores = await _repository.ObterTodos();
        return _mapper.Map<IEnumerable<FornecedorDTO>>(fornecedores);
    }
}
