﻿using SQLite;

namespace flash_card_app.Models
{
	[Table("CardDeck")]
	public class CardDeckModel
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }
		[MaxLength(100)]
		public string Name { get; set; }
	}
}
