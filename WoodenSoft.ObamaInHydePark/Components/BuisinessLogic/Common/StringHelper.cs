using System;

namespace WoodenSoft.ObamaInHydePark.Components.BuisinessLogic.Common
{
	public class StringHelper
	{
		public StringHelper ()
		{
		}
        public static string FormatCurrency(decimal  d)
        {
            return "$" + d.ToString().Substring(0, d.ToString().LastIndexOf(".")) +
                   d.ToString().Substring(d.ToString().LastIndexOf(".") + 1, 2);
        }

	    public static string RemovePossibleXSS (string file)
		{
			return file.Replace ("<", "&lt;").Replace (">", "&gt;");
		}
		public static string MakeFileSafe (string fileName)
		{
			return fileName.Replace ("<", "").Replace (">", "").Replace ("{", "").Replace ("}", "").Replace ("\\", "").Replace ("/", "").Replace (
				"^",
				""
			)
				.Replace (
				"#",
				""
			)
				.Replace (
				"`",
				""
			)
				.Replace (
				"$",
				""
			)
				.Replace (
				"*",
				""
			)
				.Replace (
				"[",
				""
			)
				.Replace (
				"]",
				""
			)
				.Replace (
				",",
				""
			)
				.Replace (
				":",
				""
			)
				.Replace (
				"\"",
				""
			)
				.Replace (
				"'",
				""
						);
		}
		public static bool IsValidCarFax (string carFaxFile)
		{
			carFaxFile = carFaxFile.ToLower ();
			return carFaxFile.EndsWith (".docx") || carFaxFile.EndsWith (".pdf") || carFaxFile.EndsWith (".doc");
		}
	
		public static bool IsValidMovie (string file)
		{
			file = file.ToLower ();
			return file.EndsWith (".mov") || file.EndsWith (".mp4") || file.EndsWith (".wmv") || file.EndsWith (".fla");
		}
		public static bool IsValidImage (string file)
		{
			file = file.ToLower ();
			return file.EndsWith (".jpg") || file.EndsWith (".gif") || file.EndsWith (".png") || file.EndsWith (".tiff") || file.EndsWith (".bmp");
		}
		public static bool IsValidTelephone (string phone)
		{
			var count = 0;
			foreach (var ch in phone.ToCharArray()) {
				if (Char.IsDigit (ch))
					count++;
			}
			return count > 8;
		}
		public static bool IsValidEmail (string email)
		{
			if (email.Length < 5)
				return false;
			var ats = 0;
			var dots = 0;
			char? lastCh = null;
			var atindex = -1;
			var lastdotindex = -1;
			var count = 0;
			foreach (var ch in email.ToCharArray()) {
				if (ch == '@') {
					ats++;
					if (ats > 1)
						return false;
					atindex = count; 
				}
				if (ch == '.') {
					dots++;
					lastdotindex = count;
					if (lastCh == '@')
						return false;
				}
				lastCh = ch;
				count++;
			}
			if (lastdotindex <= atindex)
				return false;
			return true;
		}
	}
}

