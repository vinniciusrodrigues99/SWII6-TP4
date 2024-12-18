using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using vrumvrum.Context;
using vrumvrum.DTOs.EquipeDTO;
using vrumvrum.Interface;
using vrumvrum.Models;

namespace vrumvrum.Repository;

public class EquipeRepository : IEquipeRepository
{
    private readonly IConfiguration _config;
    private readonly string connectionString;
    private readonly VrumDbContext _vrumDbContext;
    public EquipeRepository(IConfiguration config, VrumDbContext vrumDbContext)
    {
        _config = config;
        connectionString = _config.GetConnectionString("VrumDbConnection");
        _vrumDbContext = vrumDbContext;
    }
    public async Task<int> DeleteEquipe(int id_equipe)
    {
        using(var con = new SqlConnection(connectionString))
        {
            string sql = @$"DELETE FROM Equipes
                                WHERE id_equipe = {id_equipe}";
            return await con.ExecuteAsync(sql, id_equipe);
        }
    }

    public async Task<ReadEquipeDTO> GetEquipePorId(int id_equipe)
    {
        using(var con = new SqlConnection(connectionString))
        {
            string sql = $"SELECT * FROM Equipes WHERE id_equipe = {id_equipe}";
            var equipe = await con.QuerySingleOrDefaultAsync<ReadEquipeDTO>(sql);
            return equipe!;
        }
    }

    public async Task<IEnumerable<ReadEquipeDTO>> GetEquipes()
    {
        using(var con = new SqlConnection(connectionString))
        {
            string sql = $"SELECT * FROM Equipes";
            return await con.QueryAsync<ReadEquipeDTO>(sql);
        }
    }

    public async Task<CreateEquipeDTO> VerificaNomeEquipe (string nome)
    {
        using(var con = new SqlConnection(connectionString))
        {
            string sql = $"SELECT * FROM Equipes WHERE nome = '{nome}'";
            var equipe = await con.QuerySingleOrDefaultAsync<CreateEquipeDTO>(sql);
            return equipe!;
        }
    }
    public async Task<CreateEquipeDTO> PostEquipe(CreateEquipeDTO equipeDTO)
    {
        using(var con = new SqlConnection(connectionString))
        {
            string sql = @$"INSERT INTO Equipes
                        (nome, nacionalidade, CampeonatoId) 
                        VALUES (
                        '{equipeDTO.nome}',
                        '{equipeDTO.nacionalidade}', {equipeDTO.CampeonatoId} )";
            return await con.QueryFirstOrDefaultAsync<CreateEquipeDTO>(sql, equipeDTO);
        }
    }

    public async Task<int> PutEquipe(int id_equipe, UpdateEquipeDTO equipeDTO)
    {
        using(var con = new SqlConnection(connectionString))
        {
            string sql = @$"UPDATE Equipes
                        SET nome = '{equipeDTO.nome}', 
                        nacionalidade = '{equipeDTO.nacionalidade}',
                        CampeonatoId = {equipeDTO.CampeonatoId}
                        WHERE id_equipe = {id_equipe}";
            return await con.ExecuteAsync(sql, equipeDTO);
        }
    }
}