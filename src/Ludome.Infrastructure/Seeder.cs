using Ludome.Domain.Games;

namespace Ludome.Infrastructure
{
    public static class Seeder
    {
        public static async Task SeedAsync(LudomeDbContext context)
        {
            await context.Database.EnsureCreatedAsync();

            if (context.Games.Any())
                return;


            var games = GetGames();

            await context.Games.AddRangeAsync(GetGames());
            await context.SaveChangesAsync();
        }

        public static List<Game> GetGames()
        {
            var categoriaAcao = new Category("Ação");
            var categoriaAventura = new Category("Aventura");
            var categoriaRpg = new Category("RPG");
            var categoriaTiro = new Category("Tiro");
            var categoriaPlataforma = new Category("Plataforma");
            var categoriaPuzzle = new Category("Quebra-cabeça");

            var devCrystal = new Developer("Crystal Dynamics");
            var devFromSoft = new Developer("FromSoftware");
            var devNaughty = new Developer("Naughty Dog");
            var devCapcom = new Developer("Capcom");
            var devGearbox = new Developer("Gearbox Software");
            var devNintendo = new Developer("Nintendo EPD");
            var devKonami = new Developer("Konami");
            var devTeamIco = new Developer("Team Ico");

            var pubSquare = new Publisher("Square Enix");
            var pubBandai = new Publisher("Bandai Namco");
            var pubSony = new Publisher("Sony Computer Entertainment");
            var pubCapcom = new Publisher("Capcom");
            var pub2k = new Publisher("2K Games");
            var pubNintendo = new Publisher("Nintendo");
            var pubKonami = new Publisher("Konami");

            var games = new List<Game>();

            var game1 = new Game(
                "Tomb Raider (2013)",
                "https://upload.wikimedia.org/wikipedia/en/f/f1/TombRaider2013.jpg",
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus sit amet nisi non neque porta sagittis...",
                2013
            );
            game1.Developers.Add(devCrystal);
            game1.Publishers.Add(pubSquare);
            game1.Categories.Add(categoriaAcao);
            game1.Categories.Add(categoriaAventura);
            games.Add(game1);

            var game2 = new Game(
                "Dark Souls 3",
                "https://upload.wikimedia.org/wikipedia/en/b/bb/Dark_souls_3_cover_art.jpg",
                "Dark Souls III continua a ultrapassar os limites com o capítulo mais recente e ambicioso da série.",
                2016
            );
            game2.Developers.Add(devFromSoft);
            game2.Publishers.Add(pubBandai);
            game2.Categories.Add(categoriaAcao);
            game2.Categories.Add(categoriaRpg);
            games.Add(game2);

            var game3 = new Game(
                "The Last Of Us",
                "https://upload.wikimedia.org/wikipedia/en/4/46/Video_Game_Cover_-_The_Last_of_Us.jpg",
                "Em uma civilização devastada, Joel é contratado para contrabandear Ellie para fora de uma zona de quarentena.",
                2013
            );
            game3.Developers.Add(devNaughty);
            game3.Publishers.Add(pubSony);
            game3.Categories.Add(categoriaAcao);
            game3.Categories.Add(categoriaAventura);
            games.Add(game3);

            var game4 = new Game(
                "Monster Hunter Wilds",
                "https://upload.wikimedia.org/wikipedia/en/5/52/Monster_Hunter_Wilds_cover.png",
                "A próxima geração de caça a monstros está aqui. Explore novos ecossistemas e cace novas bestas.",
                2025
            );
            game4.Developers.Add(devCapcom);
            game4.Publishers.Add(pubCapcom);
            game4.Categories.Add(categoriaAcao);
            game4.Categories.Add(categoriaRpg);
            games.Add(game4);

            var game5 = new Game(
                "Borderlands 2",
                "https://upload.wikimedia.org/wikipedia/en/5/51/Borderlands_2_cover_art.png",
                "Uma nova era de atirar e saquear. Jogue como um dos quatro novos caçadores de cofres.",
                2012
            );
            game5.Developers.Add(devGearbox);
            game5.Publishers.Add(pub2k);
            game5.Categories.Add(categoriaTiro);
            game5.Categories.Add(categoriaRpg);
            games.Add(game5);

            var game6 = new Game(
                "Super Mario Odyssey",
                "https://upload.wikimedia.org/wikipedia/en/8/8d/Super_Mario_Odyssey.jpg",
                "Junte-se a Mario em uma enorme aventura 3D ao redor do mundo para resgatar a Princesa Peach.",
                2017
            );
            game6.Developers.Add(devNintendo);
            game6.Publishers.Add(pubNintendo);
            game6.Categories.Add(categoriaPlataforma);
            game6.Categories.Add(categoriaAventura);
            games.Add(game6);

            var game7 = new Game(
                "Rise of the Tomb Raider",
                "https://upload.wikimedia.org/wikipedia/en/2/29/Rise_of_the_Tomb_Raider.jpg",
                "Lara Croft corre para salvar o mundo de uma organização aterrorizante em sua primeira expedição.",
                2015
            );
            game7.Developers.Add(devCrystal);
            game7.Publishers.Add(pubSquare);
            game7.Categories.Add(categoriaAcao);
            game7.Categories.Add(categoriaAventura);
            games.Add(game7);

            var game8 = new Game(
                "The Legend of Zelda: Tears of the Kingdom",
                "https://upload.wikimedia.org/wikipedia/en/f/fb/The_Legend_of_Zelda_Tears_of_the_Kingdom_cover.jpg",
                "Uma aventura épica pela terra e pelos céus de Hyrule aguarda em Tears of the Kingdom.",
                2023
            );
            game8.Developers.Add(devNintendo);
            game8.Publishers.Add(pubNintendo);
            game8.Categories.Add(categoriaAventura);
            game8.Categories.Add(categoriaRpg);
            games.Add(game8);

            var game9 = new Game(
                "Castlevania: Symphony of the Night",
                "https://upload.wikimedia.org/wikipedia/en/c/cf/Castlevania_SOTN_PAL.jpg",
                "O legado do mal retorna. Controle Alucard e explore o castelo do Drácula neste clássico.",
                1997
            );
            game9.Developers.Add(devKonami);
            game9.Publishers.Add(pubKonami);
            game9.Categories.Add(categoriaPlataforma);
            game9.Categories.Add(categoriaAcao);
            games.Add(game9);

            var game10 = new Game(
                "Shadow of the Colossus",
                "https://upload.wikimedia.org/wikipedia/en/f/f8/Shadow_of_the_Colossus_%282005%29_cover.jpg",
                "Derrote Colossos majestosos para obter o poder místico de reviver um ente querido.",
                2005
            );
            game10.Developers.Add(devTeamIco);
            game10.Publishers.Add(pubSony);
            game10.Categories.Add(categoriaAventura);
            game10.Categories.Add(categoriaPuzzle);
            games.Add(game10);

            return games;
        }
    }
}
