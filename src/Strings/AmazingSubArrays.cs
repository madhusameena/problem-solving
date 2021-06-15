using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpProblemSolving.Strings
{
	// https://www.interviewbit.com/problems/amazing-subarrays/
	public static class AmazingSubArrays
	{
		public static void Samples()
		{
			var str =
				"PdrSgjAwGHYJgNyflrpvEHEDNoSXPqjDSuljloHalPFeIlKNeABRQYAAvMpwXAPYYBPczPdcvBDoScEdHoWmcBgdWuhzBUWbocTbhtOGoJVmYgFduYcYvjOhDjpMBcMAZfcdTUXyEUbRZTtHmFtOYfgrmwHGhRqWuFnFWmpeBupucAEFnHIHZJjlqASoQvWSZtNbONDWnbbbfWnZQaSFRBYrbAwrOgLWgtgpEwgnOKgjqCpNJnmLZqKsegaGjuepWwUlbaetbrwRtYeMPpdxfMoeaoMyGzfgebkdROnNNYMDLbLJWxjXROmuEYcTMpMgVRGylveAlseWCzDXgXSENCuyLYKnhSBpGBERBtYSQThTemTedKpQzvOWePchoQehgBNtkUptIPjbzrIjlBroHnLUSTsdxyxlLeaCFZTOvSFvyexQUjJbFoEWERJsnEAXrUpqbxoEAyXqdoagSYRGjKxKsejvPTlZDgBStqOsrDaVTxOVIVoWhplOkoyKAyepStPDYmoOtrhCJSbwdABmnUTFsBHAYIzEUZjYBDLMDGkjeAgPyCdsZMOQJwGphlDFuqbKhozJaCHccQaYxyehSRsfvzIPbmjpFboKlEaRtaWmGLJJDqeMRsIwHGqUabwFNrdYRMWrkYjqazGWeQArzDSLmxkeruTGwXGDWPrRMDImabvRSHkvPTCfpBNRAqvWNmLaWLJlDmHlSSjUqoCWQLgedTkAHJTqATLuKJIwqJZQftSrauYhWIQjsGUVspVEMRjeOyDVdtYEcHgIlSCSgIYvDdaGeUmjuuclDGdctrIXtlgjkMwsJVuuOAANZnjWVULLDvVKogHfqOmjdFIzhoqjATAvPKFwjGAEhwtDxDVgOWLnNVWrKXceHljeZYYkbbJbXWkMYgqlLwJKdxUtRndMGWAbMpXYTjOmMjPRlcqIxjmsIVuoMgKTXPlUcSsTIUdmbaavODfvkazywhZUaGaBOvaIqOHrLRCOVHEV"; // 8243
			
			Console.WriteLine(solve(str));
			str =
				"ypGdTNcssTbPICawdXKavKRYPAYIfcHMOBHKcJAUcYLNPxRVRxgaUNZdpZWgIuTomaYtFXfWgRbtJNPRuvahDDtxKogcLosjRnwfdWAjqbmcxGgRHfQtfveIcWPbbeQWIwevzAuMgFkvIBrZHabodcqAqQvknCrcUaGIIFpoMOjEYqnEqyyhLvEnLzUtEvwcYFDIqjeDxGXwfHpJWboYhopohDqQNqcQSShvRZXqcICVAdpSfeMayyRQIDSFxZIedbBSQArsbVUvnXOLhwAzRESNNRtCKvnYKgXewCBkVHEtqOLpVYhsQKdqgYpSzOysPJEhAeNpylYITECqrbQqIVIEOLXNweTHEMyGrEPVbahhRzleJjRbGKILbWzUBJrbYrQqvuPmbMMynXPXZDXtmMZvSUuTqeUlQHlrxRkoCpUjyIFpWmacfxJkNHeSveWlOyKfnQLEPjgFaUbCqRfBmzlLHQeKzqNxMIyPTCpVYmzfaJzEKpnXovYvMIGEUuZUpDMYLtTjfVmkmwSJqjZcMWGHZMYJqPKttRwaczxRcqqUhCqAyvILDwfnndVIdwRGQOXnzDfSOcdkQmbrNgabyKhVOkbOertwcsOpLQcaJBVfpqrUkplEjjbAmemfrhGwJbtMLkysHqxnYfkcVDUHkoyAoBnTcsCkfLZSaqVkSwuHHntawOEgfdQfxxsWquUALrLBpNMxLEzgCXaBGaZQWCaGWhtTNMVeyzLeUTZNhSdgVFLVdcDcMPGoNShbefEZKUtOtwLyjmeXXSkJYGOotIlXFMDeJXkCoHpkQrHdLVHGkQZXrJaUEddwqJarmUONtvqqWSlgBNQoBeWgghKxYgrKEGmCYQoeJSNZfDgmOwJCFtsNBjbULVTGeWNHUfTtVzmXCDtAaFVWUgkyGccHmKVIewPIQGEVObUbdEwlEmYMMGaIFhnsUwUDBqIowpUJnrxkNepIyUrmPsUIEWmhIgzmhgpyHWsvftfdePCU";// 5080
			Console.WriteLine(solve(str));
		}
		public static int solve(string A)
		{
			// var subStrings = AllSubstring(A);
			// foreach (var subString in subStrings)
			// {
			// 	Console.WriteLine(subString);
			// }

			return Count(A);
		}

		public static int Count(string input)
		{
			int count = 0;
			for (int i = 0; i < input.Length; i++)
			{
				if (input[i].ToString().ToLower() == "a" ||
				    input[i].ToString().ToLower() == "e" ||
				    input[i].ToString().ToLower() == "i" ||
				    input[i].ToString().ToLower() == "o" ||
				    input[i].ToString().ToLower() == "u")
				{
					count += (input.Length - i);
				}
			}
			return count % 10003;
		}

		public static List<string> AllSubstring(string text)
		{
			var query =
				from i in Enumerable.Range(0, text.Length)
				from j in Enumerable.Range(0, text.Length - i + 1)
				where j >= 1 
				      && 
					(text[i].ToString().ToLower() == "a" ||
					text[i].ToString().ToLower() == "e" ||
					text[i].ToString().ToLower() == "i" ||
					text[i].ToString().ToLower() == "o" ||
					text[i].ToString().ToLower() == "u")
				select text.Substring(i, j);
			return query.ToList();
		}
	}
}