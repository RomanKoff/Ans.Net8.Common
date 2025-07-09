﻿namespace Ans.Net8.Common
{

	public class ConsoleMenuItem(
		ConsoleKey key,
		string title,
		Action action)
	{
		public ConsoleKey Key { get; } = key;
		public string Title { get; } = title;
		public Action Action { get; } = action;
	}



	public class ConsoleMenu(
		string title)
	{

		/* properties */


		public string Title { get; set; } = title;
		public bool UseExit { get; set; } = false;


		/* readonly properties */


		public List<ConsoleMenuItem> Items { get; } = [];


		/* methods */


		public void Add(
			ConsoleMenuItem item)
		{
			Items.Add(item);
		}


		public void Release()
		{
			bool pressEscape = false;
			do
			{
				Console.WriteLine();
				if (!string.IsNullOrEmpty(Title))
					Console.WriteLine($"{Title}:");
				foreach (var item1 in Items)
					Console.WriteLine($"[{(char)item1.Key}] — {item1.Title}");
				Console.WriteLine(Resources.Common.Text_PressEscToExit);
				Console.WriteLine();
				do
				{
					UseExit = false;
					var key1 = SuppConsole.ReadKey();
					foreach (var item1 in Items)
						if (item1.Key == key1.Key)
						{
							UseExit = true;
							item1.Action();
						}
					pressEscape = key1.Key == ConsoleKey.Escape;
				} while (!UseExit && !pressEscape);
			} while (!pressEscape);
		}

	}

}
