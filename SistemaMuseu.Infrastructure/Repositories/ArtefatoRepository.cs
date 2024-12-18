﻿using Microsoft.EntityFrameworkCore;
using SistemaMuseu.Domain.Entities;
using SistemaMuseu.Domain.Interfaces;
using SistemaMuseu.Infrastructure.Context;

public class ArtefatoRepository : IArtefatoRepository
{
    private readonly MuseuContext _context;

    // Construtor que recebe o DbContext
    public ArtefatoRepository(MuseuContext context)
    {
        _context = context;
    }

    // Adicionar um novo artefato
    public async Task<Artefato> Adicionar(Artefato artefato)
    {
        _context.Artefato.Add(artefato); // Adiciona o artefato à tabela
        await _context.SaveChangesAsync(); // Salva as alterações no banco
        return artefato; // Retorna o artefato adicionado
    }

    // Editar um artefato existente
    public async Task<Artefato> Editar(Artefato artefato)
    {
        // Verifica se a entidade Artefato já está sendo rastreada
        var existingEntity = _context.Artefato.Local.FirstOrDefault(e => e.Id == artefato.Id);

        if (existingEntity == null)
        {
            // Se a entidade não estiver rastreada, atualiza o artefato
            _context.Artefato.Update(artefato);
        }
        else
        {
            // Se a entidade já estiver sendo rastreada, apenas atualiza os valores
            _context.Entry(existingEntity).CurrentValues.SetValues(artefato);
        }

        // Salva as alterações no banco de dados
        await _context.SaveChangesAsync();
        return artefato; // Retorna o artefato editado
    }

    // Deletar um artefato pelo ID
    public async Task<Artefato> Deletar(int id)
    {
        var artefato = await _context.Artefato.FindAsync(id); // Encontra o artefato pelo ID
        if (artefato == null)
        {
            return null; // Retorna null caso o artefato não seja encontrado
        }
        _context.Artefato.Remove(artefato); // Remove o artefato da tabela
        await _context.SaveChangesAsync(); // Salva as alterações no banco
        return artefato; // Retorna o artefato deletado
    }

    // Obter um artefato pelo ID
    public async Task<Artefato> Obter(int id)
    {
        return await _context.Artefato.FindAsync(id); // Encontra e retorna o artefato pelo ID
    }

    // Obter todos os artefatos
    public async Task<IEnumerable<Artefato>> ObterTodos()
    {
        return await _context.Artefato.ToListAsync(); // Retorna todos os artefatos da tabela
    }

}

