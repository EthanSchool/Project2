namespace Project2.Models {
	public class CustomViewModel {
		public TableData MostMVPS;
		public Other Others;
		public TableData SBWinners;
		public TableData StatesHeldMost;
		public TableData Top5Attended;

		public class Other {
			public string AverageAttendance;
			public string CoachLostMost;
			public string CoachWonMost;
			public string SBWithGreatestPointDelta;
			public string TeamLostMost;
			public string TeamWonMost;
		}
	}

	public class TableData {
		public string[] Labels;
		public string[][] Values;
	}

	public struct Card {
		public string Title;
		public string Info;
		public string Icon;
		public string IconColor;

		public Card(string title, string info, string icon, string iconColor = "black") {
			Title = title;
			Info = info;
			Icon = icon;
			IconColor = iconColor;
		}
	}
}