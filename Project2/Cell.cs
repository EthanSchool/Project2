using System;
using CsvHelper.Configuration;

// ReSharper disable UnassignedField.Global

namespace Project2 {
	// ReSharper disable once ClassNeverInstantiated.Global
	public class Cell {
		public int Attendance;
		public string City;
		public string CoachLoser;
		public string CoachWinner;
		public DateTime Date;
		public string Loser;
		public int LosingPts;
		public string MVP;
		public string QBLoser;
		public string QBWinner;
		public int SB;
		public string Stadium;
		public string State;
		public string Winner;
		public int WinningPts;
	}

	public sealed class ThingMap : ClassMap<Cell> {
		public ThingMap() {
			Map(d => d.Date).Name("Date");
			Map(d => d.SB).Name("SB").ConvertUsing(row => Extentions.RomanToInteger(row.GetField("SB").Trim()));
			Map(d => d.Attendance).Name("Attendance");
			Map(d => d.QBWinner).Name("QB  Winner");
			Map(d => d.QBWinner).Name("QB  Winner");
			Map(d => d.CoachWinner).Name("Coach Winner");
			Map(d => d.Winner).Name("Winner");
			Map(d => d.WinningPts).Name("Winning Pts");
			Map(d => d.QBLoser).Name("QB Loser");
			Map(d => d.CoachLoser).Name("Coach Loser");
			Map(d => d.Loser).Name("Loser");
			Map(d => d.LosingPts).Name("Losing Pts");
			Map(d => d.Winner).Name("Winner");
			Map(d => d.MVP).Name("MVP");
			Map(d => d.Stadium).Name("Stadium");
			Map(d => d.City).Name("City");
			Map(d => d.State).Name("State");
		}
	}
}