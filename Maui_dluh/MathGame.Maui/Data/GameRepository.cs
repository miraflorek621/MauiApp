using MathsGame.Models;
using SQLite;
using System;
using System.Diagnostics;

namespace MathGame.Maui.Data
{
    public class GameRepository
    {
        string _dbPath;
        private SQLiteConnection conn;

        public GameRepository(string dbPath)
        {
            _dbPath = dbPath;
        }

        public void CreateTable()
        {
            try
            {
                conn = new SQLiteConnection(_dbPath);
                conn.CreateTable<Game>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        internal void Add(Game game)
        {
            conn = new SQLiteConnection(_dbPath);
            conn.Insert(game);
        }



        internal void Edit(Game game)
        {
            conn = new SQLiteConnection(_dbPath);
            conn.Update(game);

        }

        public List<Game> GetAllGames()
        {
            try
            {
                CreateTable();
                return conn.Table<Game>().ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return new List<Game>();
        }

        public List<Game> GetOneGame(int id)
        {
            return conn.Table<Game>().Where(game => game.Id == id).ToList();
        }





        internal void Delete(int id)
        {
            conn = new SQLiteConnection(_dbPath);
            conn.Delete(new Game { Id = id });
        }
    }
}