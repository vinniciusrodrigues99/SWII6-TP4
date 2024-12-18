using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using vrumvrum.Context;
using vrumvrum.DTOs.CorridaDTO;
using vrumvrum.Interface;
using vrumvrum.Models;

namespace vrumvrum.Repository;

public class CorridaRepository : ICorridaRepository
{
    private readonly IConfiguration _config;
    private readonly string connectionString;
    private readonly VrumDbContext _vrumDbContext;
    public CorridaRepository(IConfiguration config, VrumDbContext vrumDbContext)
    {
        _config = config;
        connectionString = _config.GetConnectionString("VrumDbConnection");
        _vrumDbContext = vrumDbContext;
    }

    public async Task<int> DeleteCorrida(int id_corrida)
    {
        using(var con = new SqlConnection(connectionString))
        {
            string sql = @$"DELETE FROM Corridas
                                WHERE id_corrida = {id_corrida}";
            return await con.ExecuteAsync(sql, id_corrida);
        }
    }

    public async Task<ReadCorridaDTO> GetCorridaPorId(int id_corrida)
    {
        using(var con = new SqlConnection(connectionString))
        {
            string sql = $"SELECT * FROM Corridas WHERE id_corrida = {id_corrida}";
            var corrida = await con.QuerySingleOrDefaultAsync<ReadCorridaDTO>(sql);
            return corrida!;
        }
    }

    public async Task<IEnumerable<ReadCorridaDTO>> GetCorridas()
    {
        using(var con = new SqlConnection(connectionString))
        {
            string sql = "SELECT * FROM Corridas";
            return await con.QueryAsync<ReadCorridaDTO>(sql);
        }
    }
    
    public async Task<CreateCorridaDTO> VerificaNomeCorrida(string nome_corrida)
    {
        using(var con = new SqlConnection(connectionString))
        {
            string sql = $"SELECT * FROM Corridas WHERE nome_corrida = '{nome_corrida}'";
            var campeonato = await con.QuerySingleOrDefaultAsync<CreateCorridaDTO>(sql);
            return campeonato!;
        }
    }

    public async Task<CreateCorridaDTO> PostCorrida(CreateCorridaDTO corridaDTO)
    {
        using(var con = new SqlConnection(connectionString))
        {
            string sql = @$"INSERT INTO Corridas
                        (nome_corrida,
                        voltas, tamanho_circuito, pais, CampeonatoId) 
                        VALUES ('{corridaDTO.nome_corrida}',
                        {corridaDTO.voltas}, {corridaDTO.tamanho_circuito},
                        '{corridaDTO.pais}', {corridaDTO.CampeonatoId})";
            return await con.QueryFirstOrDefaultAsync<CreateCorridaDTO>(sql, corridaDTO);
        }
    }

    public async Task<int> PutCorrida(int id_corrida, UpdateCorridaDTO corridaDTO)
    {
        using(var con = new SqlConnection(connectionString))
        {
            string sql = @$"UPDATE Corridas
                        SET nome_corrida = '{corridaDTO.nome_corrida}',
                        voltas = {corridaDTO.voltas}, 
                        tamanho_circuito = {corridaDTO.tamanho_circuito}, 
                        pais = '{corridaDTO.pais}',
                        CampeonatoId = {corridaDTO.CampeonatoId}
                        WHERE id_corrida = {id_corrida}";
            return await con.ExecuteAsync(sql, corridaDTO);
        }
    }
}