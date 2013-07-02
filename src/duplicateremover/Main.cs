using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace DuplicateRemover
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			string filename = String.Empty;
			Encoding encoding = System.Text.Encoding.UTF8;

			if (args.Length != 1)
			{
				Console.WriteLine("first argument must be the path to the file from which to read");
				System.Environment.Exit(1);
			}

			filename = args[0];

			var alreadySeen = new Dictionary<char, bool>();

			using (var fs = File.OpenRead(filename))
			{
				byte[] buffer;
				int i;
				char cur;
				string s;
				int charsRead;

				while (true)
				{
					buffer = new byte[5000];
					charsRead = fs.Read(buffer, 0, buffer.Length);

					if (charsRead == 0)
					{
						break;
					}

					s = encoding.GetString(buffer);

					for (i = 0; i!=s.Length; i++)
					{
						cur = s[i];

						if (alreadySeen.ContainsKey(cur))
						{
							continue;
						}

						alreadySeen.Add(cur, true);
						Console.Write(cur);
					}
				}
			}
			Console.WriteLine();
		}
	}
}
