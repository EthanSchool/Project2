using System.Diagnostics;
using System.Globalization;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Project2.Models;

namespace Project2.Controllers {
	public class HomeController : Controller {
		public IActionResult Index() {
			Cell[] records = Program.Records;

			return View(new CustomViewModel {
				SBWinners = new TableData {
					Labels = new[] {"Name", "Year", "Winning quarterback", "Winning coach", "MVP", "Point delta"},
					Values = records.Select(x => new[] {x.Winner, x.Date.Year.ToString(), x.QBWinner, x.CoachWinner, x.MVP, x.WinningPts.ToString()}).ToArray()
				},
				Top5Attended = new TableData {
					Labels = new[] {"Year", "Winning team", "Losing team", "City", "State", "Statium"},
					Values = records.OrderBy(o => o.Attendance)
						.Take(5)
						.Select(x => new[] {x.Date.Year.ToString(), x.Winner, x.Loser, x.City, x.State, x.Stadium})
						.ToArray()
				},
				StatesHeldMost = new TableData {
					Labels = new[] {"City", "State", "Statium"},
					Values = records.NonDistinct(i => i.State)
						.Select(x => new[] {x.City, x.State, x.Stadium})
						.ToArray()
				},
				MostMVPS = new TableData {
					Labels = new[] {"MVP", "Winning team", "Losing team"},
					Values = records.NonDistinct(i => i.MVP, 2)
						.Select(x => new[] {x.MVP, x.Winner, x.Loser})
						.ToArray()
				},
				Others = new CustomViewModel.Other {
					AverageAttendance = records.Average(r => r.Attendance).ToString("N0", CultureInfo.InvariantCulture),
					CoachLostMost = string.Join(", ", records.Select(i => i.CoachLoser).MaxMultiple()),
					CoachWonMost = string.Join(", ", records.Select(i => i.CoachWinner).MaxMultiple()),
					SBWithGreatestPointDelta = Extentions.ToRoman(records.OrderBy(o => o.WinningPts - o.LosingPts).Reverse().First().SB),
					TeamLostMost = string.Join(", ", records.Select(i => i.Loser).MaxMultiple()),
					TeamWonMost = string.Join(", ", records.Select(i => i.Winner).MaxMultiple())
				}
			});
		}

		public IActionResult Error() {
			return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
		}
	}
}