﻿using SQLite;

//Notes: I should rename this to DeckModel

namespace flash_card_app.Models
{
	[Table("Deck")]
	public class DeckModel
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }
		[MaxLength(100)]
		public string Name { get; set; }
	}
}
