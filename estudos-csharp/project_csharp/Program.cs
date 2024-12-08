using project_csharp.Dtos;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<GameDto> games = [
    new (
        1,
        "Street Fighter II",
        "Fighting",
        19.99M,
        new DateOnly(1992, 7, 15)
    ),
     new (
        2,
        "Xeno",
        "Fighting, shooter",
        39.99M,
        new DateOnly(1990, 7, 15)
    )
];

var select = from game in games 
             where game.Id == 1 
             select game;

// Get /games

app.MapGet("games", () => games);

// Get /games/id

app.MapGet("games/{id}", (int id) => games.Find(game => game.Id == id));

app.Run();