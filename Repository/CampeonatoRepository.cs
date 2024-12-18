using Dapper;
using Microsoft.Data.SqlClient;
using vrumvrum.Context;
using vrumvrum.DTOs.CampeonatoDTO;
using vrumvrum.Interface;
using vrumvrum.Models;

namespace vrumvrum.Repository;

public class CampeonatoRepository : ICampeonatoRepository
{
    private readonly IConfiguration _config;
    private readonly string connectionString;
    private readonly VrumDbContext _vrumDbContext;
    public CampeonatoRepository(IConfiguration config, VrumDbContext vrumDbContext)
    {
        _config = config;
        connectionString = _config.GetConnectionString("VrumDbConnection");
        _vrumDbContext = vrumDbContext;
    }

    public async Task<IEnumerable<ReadCampeonatoDTO>> GetCampeonatos()
    {
        using(var con = new SqlConnection(connectionString))
        {
            string sql = "SELECT * FROM Campeonatos";
            return await con.QueryAsync<ReadCampeonatoDTO>(sql);
        }
    }
    public async Task<ReadCampeonatoDTO> GetCampeonatosPorId(int id_campeonato)
    {
        using(var con = new SqlConnection(connectionString))
        {
            string sql = $"SELECT * FROM Campeonatos WHERE id_campeonato = {id_campeonato}";
            var campeonato = await con.QuerySingleOrDefaultAsync<ReadCampeonatoDTO>(sql);
            return campeonato!;
        }
    }

    public async Task<IEnumerable<ReadCampeonatoDTO>> GetCampeonatosPorIdCorrida(int id_campeonato)
    {
        using(var con = new SqlConnection(connectionString))
        {
            string sql = $@"SELECT * FROM Campeonatos
                            INNER JOIN Corridas
                            ON id_campeonato = Corridas.CampeonatoId
                            WHERE Corridas.CampeonatoId = {id_campeonato} ";
            var campeonato = await con.QueryAsync<ReadCampeonatoDTO>(sql);
            return campeonato!;
        }
    }
    public async Task<CreateCampeonatoDTO> VerificaNomeCampeonato(string nome_campeonato)
    {
        using(var con = new SqlConnection(connectionString))
        {
            string sql = $"SELECT * FROM Campeonatos WHERE nome = '{nome_campeonato}'";
            var campeonato = await con.QuerySingleOrDefaultAsync<CreateCampeonatoDTO>(sql);
            return campeonato!;
        }
    }

    public async Task<CreateCampeonatoDTO> PostCampeonato (CreateCampeonatoDTO campeonatoDTO)
    {
        using(var con = new SqlConnection(connectionString))
        {
            string sql = @$"INSERT INTO Campeonatos
                        (nome,
                        ano, categoria) 
                        VALUES (
                            '{campeonatoDTO.nome}',
                        {campeonatoDTO.ano},
                        '{campeonatoDTO.categoria}' )";
            return await con.QueryFirstOrDefaultAsync<CreateCampeonatoDTO>(sql, campeonatoDTO);
        }
    }

    public async Task<int> PutCampeonato (int id_campeonato, UpdateCampeonatoDTO campeonatoDTO)
    {
        using(var con = new SqlConnection(connectionString))
        {
            string sql = @$"UPDATE Campeonatos
                        SET nome = '{campeonatoDTO.nome}',
                            ano = {campeonatoDTO.ano},
                            categoria ='{campeonatoDTO.categoria}' WHERE id_campeonato = {id_campeonato}";
            return await con.ExecuteAsync(sql, campeonatoDTO);
        }
    }

    public async Task<int> DeleteCampeonato(int id_campeonato)
    {
        using(var con = new SqlConnection(connectionString))
        {
            string sql = @$"DELETE FROM Campeonatos
                                WHERE id_campeonato = {id_campeonato}";
            return await con.ExecuteAsync(sql, id_campeonato);
        }
    }
}