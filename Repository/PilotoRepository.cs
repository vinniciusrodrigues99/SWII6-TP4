using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using vrumvrum.Context;
using vrumvrum.DTOs.PilotoDTO;
using vrumvrum.Interface;
using vrumvrum.Models;

namespace vrumvrum.Repository;

public class PilotoRepository : IPilotoRepository
{
    private readonly IConfiguration _config;
    private readonly string connectionString;
    private readonly VrumDbContext _vrumDbContext;
    public PilotoRepository(IConfiguration config, VrumDbContext vrumDbContext)
    {
        _config = config;
        connectionString = _config.GetConnectionString("VrumDbConnection");
        _vrumDbContext = vrumDbContext;
    }
    public async Task<int> DeletePiloto(int id_piloto)
    {
        using(var con = new SqlConnection(connectionString))
        {
            string sql = @$"DELETE FROM Pilotos
                                WHERE id_piloto = {id_piloto}";
            return await con.ExecuteAsync(sql, id_piloto);
        }
    }

    public async Task<ReadPilotoDTO> GetPilotoPorId(int id_piloto)
    {
        using(var con = new SqlConnection(connectionString))
        {
            string sql = $"SELECT * FROM Pilotos WHERE id_piloto = {id_piloto}";
            var piloto = await con.QuerySingleOrDefaultAsync<ReadPilotoDTO>(sql);
            return piloto!;
        }
    }

    public async Task<IEnumerable<ReadPilotoDTO>> GetPilotos()
    {
        using(var con = new SqlConnection(connectionString))
        {
            string sql = $"SELECT * FROM Pilotos";
            return await con.QueryAsync<ReadPilotoDTO>(sql);
        }
    }

    public async Task<CreatePilotoDTO> VerificaNomePiloto (string nome)
    {
        using(var con = new SqlConnection(connectionString))
        {
            string sql = $"SELECT * FROM Pilotos WHERE nome = '{nome}'";
            var piloto = await con.QuerySingleOrDefaultAsync<CreatePilotoDTO>(sql);
            return piloto!;
        }
    }
    public async Task<CreatePilotoDTO> PostPiloto(CreatePilotoDTO pilotoDTO)
    {
        using(var con = new SqlConnection(connectionString))
        {
            string sql = @$"INSERT INTO Pilotos
                        (nome, nacionalidade, EquipeId) 
                        VALUES (
                        '{pilotoDTO.nome}',
                        '{pilotoDTO.nacionalidade}',
                        '{pilotoDTO.EquipeId}')";
            return await con.QueryFirstOrDefaultAsync<CreatePilotoDTO>(sql, pilotoDTO);
        }
    }

    public async Task<int> PutPiloto(int id_piloto, UpdatePilotoDTO pilotoDTO)
    {
        using(var con = new SqlConnection(connectionString))
        {
            string sql = @$"UPDATE Pilotos
                        SET nome = '{pilotoDTO.nome}', 
                        nacionalidade = '{pilotoDTO.nacionalidade}',
                        EquipeId = '{pilotoDTO.EquipeId}'  
                        WHERE id_piloto = {id_piloto}";
            return await con.ExecuteAsync(sql, pilotoDTO);
        }
    }
}