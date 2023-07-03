using System;
using System.Data;
using CandleMVC.Models;
using Dapper;

namespace CandleMVC
{
	public class CandleRepo : ICandleRepo
	{
		private readonly IDbConnection _conn;

		public CandleRepo(IDbConnection conn)
		{
			_conn = conn;
		}

        public IEnumerable<Candle> GetAllCandles()
        {
			return _conn.Query<Candle>("SELECT * FROM candles;");
        }

        public Candle GetCandle(int id)
        {
            return _conn.QuerySingle<Candle>("SELECT * FROM candles WHERE CandleID = @id", new { @id = id });
        }

        public IEnumerable<Fragrance> GetFragrances()
        {
            return _conn.Query<Fragrance>("SELECT * FROM fragrances;");
        }

        public Candle AssignFragrance()
        {
            var fragranceList = GetFragrances();
            var candle = new Candle();
            candle.FragrancesList = fragranceList;
            return candle;
        }

        public void InsertCandle(Candle candleToInsert)
        {
            _conn.Execute("INSERT INTO candles (Name, Fragrances, Notes, Container, Wick, Description, Price, Image, CandleID) VALUES (@name, @fragrances, @notes, @container, @wick, @description, @price, @image, @id);",
                new { @name = candleToInsert.Name, @fragrances = candleToInsert.Fragrances, @notes = candleToInsert.Notes, @container = candleToInsert.Container, @wick = candleToInsert.Wick, @description = candleToInsert.Description, @price = candleToInsert.Price, @image = candleToInsert.Image, @id = candleToInsert.CandleID });
        }

        public void UpdateCandle(Candle candle)
        {
            _conn.Execute("UPDATE candles SET Name = @name, Fragrances = @fragrances, Notes = @notes, Container = @container, Wick = @wick, Description = @description, Price = @price, Image = @image WHERE CandleID = @id",
                new { @name = candle.Name, @fragrances = candle.Fragrances, @notes = candle.Notes, @container = candle.Container, @wick = candle.Wick, @description = candle.Description, @price = candle.Price, @image = candle.Image, @id = candle.CandleID });
        }

        public void DeleteCandle(Candle candle)
        {
            _conn.Execute("DELETE FROM candles WHERE CandleID = @id;", new { @id = candle.CandleID });
        }
    }
}

