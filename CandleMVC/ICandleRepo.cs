using System;
using CandleMVC.Models;

namespace CandleMVC
{
	public interface ICandleRepo
	{
		public IEnumerable<Candle> GetAllCandles();
		public Candle GetCandle(int id);
		public void UpdateCandle(Candle candle);
		public void InsertCandle(Candle candleToInsert);
		public IEnumerable<Fragrance> GetFragrances();
		public Candle AssignFragrance();
		public void DeleteCandle(Candle candle);
	}
}

