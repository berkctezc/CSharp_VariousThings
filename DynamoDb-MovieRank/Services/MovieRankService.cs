﻿namespace DynamoDb_MovieRank.Services;

public class MovieRankService : IMovieRankService
{
    private readonly IMapper _map;
    private readonly IMovieRankRepository _movieRankRepository;

    public MovieRankService(IMovieRankRepository movieRankRepository, IMapper map)
    {
        _movieRankRepository = movieRankRepository;
        _map = map;
    }

    public async Task<IEnumerable<MovieResponse>> GetAllItemsFromDatabase()
    {
        var response = await _movieRankRepository.GetAllItems();

        return _map.ToMovieContract(response);
    }

    public async Task<MovieResponse> GetMovie(int userId, string movieName)
    {
        var response = await _movieRankRepository.GetMovie(userId, movieName);

        return _map.ToMovieContract(response);
    }

    public async Task<IEnumerable<MovieResponse>> GetUsersRankedMoviesByMovieTitle(int userId, string movieName)
    {
        var response = await _movieRankRepository.GetUsersRankedMoviesByMovieTitle(userId, movieName);

        return _map.ToMovieContract(response);
    }

    public async Task AddMovie(int userId, MovieRankRequest movieRankRequest)
    {
        await _movieRankRepository.AddMovie(userId, movieRankRequest);
    }

    public async Task UpdateMovie(int userId, MovieUpdateRequest request)
    {
        await _movieRankRepository.UpdateMovie(userId, request);
    }

    public async Task<MovieRankResponse> GetMovieRank(string movieName)
    {
        var response = await _movieRankRepository.GetMovieRank(movieName);

        var overallMovieRanking = Math.Round(response.Items.Select(item => Convert.ToInt32(item["Ranking"].N)).Average());

        return new MovieRankResponse
        {
            MovieName = movieName,
            OverallRanking = overallMovieRanking
        };
    }
}