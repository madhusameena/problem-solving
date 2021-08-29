using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CSharpProblemSolving
{
	public static class Arc
	{
		// private static Metadata[] Data;
		private static Metadata[] Data;

		private static string ServiceUrl =
			"https://raw.githubusercontent.com/arcjsonapi/ApiSampleData/master/api/users";
		

		public static void Samples()
		{
			// Init();
			InitFromRestAsync().GetAwaiter().GetResult();
			var strList = new List<string>() { "username", "EQUALS", "vinayk" };
			var test = apiResponseParser(strList, 3);
			foreach (var i1 in test)
			{
				Console.WriteLine(i1);
			}
			
			strList = new List<string>() { "address.city", "EQUALS", "Kolkata" };
			test = apiResponseParser(strList, 3);
			foreach (var i1 in test)
			{
				Console.WriteLine(i1);
			}
			
			strList = new List<string>() { "address.city", "IN", "Mumbai,Kolkata" };
			test = apiResponseParser(strList, 3);
			foreach (var i1 in test)
			{
				Console.Write($"{i1}\t");
			}

			Console.WriteLine();
			strList = new List<string>() { "username", "IN", "Mumbai,Kolkata" };
			test = apiResponseParser(strList, 3);
			foreach (var i1 in test)
			{
				Console.Write($"{i1}\t");
			}

			Console.WriteLine();
		}

		public static async Task InitFromRestAsync()
		{
			using HttpClient client = new HttpClient();
			Data = await client.GetFromJsonAsync<Metadata[]>(ServiceUrl);
		}

		public static void Init()
		{
			// var str = File.ReadAllText(
			// 	@"E:\OneDrive\OneDrive - Hexagon\Ma\Projects\CSharp\problem-solving\src\BinaryTree\ip.txt");
			// Data = JsonConvert.DeserializeDataect<Metadata[]>(str);
			Data = new Metadata[10];
			Data[0] = new Metadata()
			{
				id = 1,
				name = "Vinay Kumar",
				username = "vinayk",
				email = "vinayk@abcu.com",
				address = new Address()
				{
					street = "random1",
					suite = "APR",
					city = "Mumbai",
					zipcode = "192008-13874",
					geo = new Geo()
					{
						lat = -17.3159,
						lng = 91.1496,
					}
				},
				website = "seuinfra.org",
				company = new Company()
				{
					name = "sec infra",
					basename = "seu infra tech"
				}
			};
			Data[1] = new Metadata()
			{
				id = 2,
				name = "Anandita Basu",
				username = "PrernaB",
				email = "Anandita.b@abc1f.cpm",
				address = new Address()
				{
					street = "Hawroh Bridge",
					suite = "ATY",
					city = "Kolkata",
					zipcode = "700001",
					geo = new Geo()
					{
						lat = -67.3159,
						lng = 91.8006,
					}
				},
				website = "techInfar.org",
				company = new Company()
				{
					name = "tech infar world",
					basename = "seu infra tech"
				}
			};
			Data[2] = new Metadata()
			{
				id = 3,
				name = "Charvi Malhotra",
				username = "CharviM",
				email = "Charvim@mail.net",
				address = new Address()
				{
					street = "whitehouse Extension",
					suite = "A782",
					city = "Bengaluru",
					zipcode = "560001",
					geo = new Geo()
					{
						lat = -68.6102,
						lng = -47.0653,
					}
				},
				website = "Infesystem.info",
				company = new Company()
				{
					name = "infeystems",
					basename = "Information E stsyem"
				}
			};
			
			Data[1] = new Metadata()
			{
				id = 2,
				name = "Anandita Basu",
				username = "PrernaB",
				email = "Anandita.b@abc1f.cpm",
				address = new Address()
				{
					street = "Hawroh Bridge",
					suite = "ATY",
					city = "Kolkata",
					zipcode = "700001",
					geo = new Geo()
					{
						lat = -67.3159,
						lng = 91.8006,
					}
				},
				website = "techInfar.org",
				company = new Company()
				{
					name = "tech infar world",
					basename = "seu infra tech"
				}
			};
			Data[3] = new Metadata()
			{
				id = 4,
				name = "Patricia Wilson",
				username = "WilsonP",
				email = "Wilsonp@mymail.org",
				address = new Address()
				{
					street = "Kalangut",
					suite = "Apt 6",
					city = "Panjim",
					zipcode = "403110",
					geo = new Geo()
					{
						lat = 29.4572,
						lng = -164.2990,
					}
				},
				website = "giant.Tech.biz",
				company = new Company()
				{
					name = "robert-techgiant",
					basename = "transition cutting-edge web services provider"
				}
			};
			Data[4] = new Metadata()
			{
				id = 5,
				name = "Chetan Chauhan ",
				username = "ChauhanChetan",
				email = "chetanc@mailme.in",
				address = new Address()
				{
					street = "Willow Walks",
					suite = "1351",
					city = "Hyderabad",
					zipcode = "500001",
					geo = new Geo()
					{
						lat = -31.8129,
						lng = 62.5342,
					}
				},
				website = "sanganak.info",
				company = new Company()
				{
					name = "Sanganak",
					basename = "end-to-end solution provider"
				}
			};
			Data[5] = new Metadata()
			{
				id = 6,
				name = "Pragya Mathur",
				username = "mathurpragya",
				email = "pragya.mathur@mail.in",
				address = new Address()
				{
					street = "Rosewind Crossing",
					suite = "A-50",
					city = "Delhi",
					zipcode = "100001",
					geo = new Geo()
					{
						lat = -71.4197,
						lng = 71.7478,
					}
				},
				website = "hola.in",
				company = new Company()
				{
					name = "Hola Technocrafts",
					basename = "e-enable innovative applications"
				}
			};
			Data[6] = new Metadata()
			{
				id = 7,
				name = "Krish Ahuja",
				username = "ahujakrish",
				email = "ahujakrish@mails.in",
				address = new Address()
				{
					street = "Havmore Extension",
					suite = "A3221",
					city = "Bengalura",
					zipcode = "560058",
					geo = new Geo()
					{
						lat = 24.8918,
						lng = 21.8984
					}
				},
				website = "tellybelly.in",
				company = new Company()
				{
					name = "Telly Belly",
					basename = "generate application support solutions"
				}
			};
			Data[7] = new Metadata()
			{
				id = 8,
				name = "Nilofar Anam",
				username = "anamnilofar",
				email = "nilofaranam.d@maily.me",
				address = new Address()
				{
					street = "fountains lane",
					suite = "B902",
					city = "pune",
					zipcode = "400001",
					geo = new Geo()
					{
						lat = -14.3990,
						lng = -120.7677
					}
				},
				website = "techoba.com",
				company = new Company()
				{
					name = "Tech Happy Group",
					basename = "e-support to middle retailers"
				}
			};
			Data[8] = new Metadata()
			{
				id = 9,
				name = "Garima Gupta",
				username = "Garimag",
				email = "gupta.garima22@myemails.io",
				address = new Address()
				{
					street = "Little Park",
					suite = "B68",
					city = "Surat",
					zipcode = "764920",
					geo = new Geo()
					{
						lat = 24.6463,
						lng = -168.8889
					}
				},
				website = "contech.com",
				company = new Company()
				{
					name = "Configs Techs",
					basename = "real-time technologies support"
				}
			};
			Data[9] = new Metadata()
			{
				id = 10,
				name = "Dharma Dhar",
				username = "Dharmadhar55",
				email = "dharmadhar55@olexa.in",
				address = new Address()
				{
					street = "Anam Street",
					suite = "198/23",
					city = "Surat",
					zipcode = "314280",
					geo = new Geo()
					{
						lat = -38.2386,
						lng = 57.2232
					}
				},
				website = "ampitech.net",
				company = new Company()
				{
					name = "Ampitech Solutions Ltd",
					basename = "target end-to-end startup support"
				}
			};
		}

		public static List<int> apiResponseParser(List<string> inputList, int size)
		{
			var invalidList = new List<int>() { -1 };
			if (inputList.Count != 3)
			{
				return invalidList;
			}

			string prop = inputList[0], oper = inputList[1], value = inputList[2];
			return Findit(prop, oper, value);
		}

		private static List<int> Findit(string prop, string oper, string value)
		{
			List<int> response = new List<int>() { -1 };
			bool isIn = oper == "IN";
			string start, end;
			if (isIn)
			{
				var str = value.Split(new []{','});
				start = str[0];
				end = str[1];
			}
			else
			{
				start = end = value;
			}
			if (prop == "id")
			{
				response = Data.Where(s => s.id >= int.Parse(start) && s.id <= int.Parse(end)).Select(s => s.id).ToList();
				// if (isIn)
				// {
				// 	response = Data.Where(s => s.id >= int.Parse(start) && s.id <= int.Parse(end)).Select(s => s.id).ToList();
				// }
				// else
				// {
				// 	response = Data.Where(s => s.id == int.Parse(start)).Select(s => s.id).ToList();
				// }
			}
			else if (prop == "name")
			{
				response = Data.Where(s => string.Compare(s.name, start, StringComparison.CurrentCulture) == 0||
				                           string.Compare(s.name, end, StringComparison.CurrentCulture) == 0).
					Select(s => s.id).ToList();
				// if (isIn)
				// {
				// 	response = Data.Where(s => string.Compare(s.name, start, StringComparison.CurrentCulture) == 0||
				// 	                          string.Compare(s.name, end, StringComparison.CurrentCulture) == 0).
				// 		Select(s => s.id).ToList();
				// }
				// else
				// {
				// 	response = Data.Where(s => string.Compare(s.name, start, StringComparison.CurrentCulture) == 0).Select(s => s.id).ToList();
				// }
			}
			else if (prop == "username")
			{
				if (isIn)
				{
					response = Data.Where(s => string.Compare(s.username, start, StringComparison.CurrentCulture) == 0||
					                          string.Compare(s.username, end, StringComparison.CurrentCulture) == 0).
						Select(s => s.id).ToList();
				}
				else
				{
					response = Data.Where(s => string.Compare(s.username, start, StringComparison.CurrentCulture) == 0).Select(s => s.id).ToList();
				}
			}
			else if (prop == "email")
			{
				if (isIn)
				{
					response = Data.Where(s => string.Compare(s.email, start, StringComparison.CurrentCulture) == 0||
					                          string.Compare(s.email, end, StringComparison.CurrentCulture) == 0).
						Select(s => s.id).ToList();
				}
				else
				{
					response = Data.Where(s => string.Compare(s.email, start, StringComparison.CurrentCulture) == 0).Select(s => s.id).ToList();
				}
			}
			else if (prop == "address.street")
			{
				if (isIn)
				{
					response = Data.Where(s => string.Compare(s.address.street, start, StringComparison.CurrentCulture) == 0||
					                          string.Compare(s.address.street, end, StringComparison.CurrentCulture) == 0).
						Select(s => s.id).ToList();
				}
				else
				{
					response = Data.Where(s => string.Compare(s.address.street, start, StringComparison.CurrentCulture) == 0).Select(s => s.id).ToList();
				}
			}
			else if (prop == "address.suite")
			{
				if (isIn)
				{
					response = Data.Where(s => string.Compare(s.address.suite, start, StringComparison.CurrentCulture) == 0||
					                          string.Compare(s.address.suite, end, StringComparison.CurrentCulture) == 0).
						Select(s => s.id).ToList();
				}
				else
				{
					response = Data.Where(s => string.Compare(s.address.suite, start, StringComparison.CurrentCulture) == 0).Select(s => s.id).ToList();
				}
			}
			else if (prop == "address.city")
			{
				if (isIn)
				{
					response = Data.Where(s => string.Compare(s.address.city, start, StringComparison.CurrentCulture) == 0||
					                          string.Compare(s.address.city, end, StringComparison.CurrentCulture) == 0).
						Select(s => s.id).ToList();
				}
				else
				{
					response = Data.Where(s => string.Compare(s.address.city, start, StringComparison.CurrentCulture) == 0).Select(s => s.id).ToList();
				}
			}
			else if (prop == "address.zipcode")
			{
				if (isIn)
				{
					response = Data.Where(s => string.Compare(s.address.zipcode, start, StringComparison.CurrentCulture) == 0||
					                          string.Compare(s.address.zipcode, end, StringComparison.CurrentCulture) == 0).
						Select(s => s.id).ToList();
				}
				else
				{
					response = Data.Where(s => string.Compare(s.address.zipcode, start, StringComparison.CurrentCulture) == 0).Select(s => s.id).ToList();
				}
			}
			else if (prop == "address.geo.lat")
			{
				if (isIn)
				{
					response = Data.Where(s => s.address.geo.lat >= double.Parse(start) && s.address.geo.lat <= double.Parse(end)).Select(s => s.id).ToList();
				}
				else
				{
					response = Data.Where(s => s.address.geo.lat == double.Parse(start)).Select(s => s.id).ToList();
				}
				
			}
			else if (prop == "address.geo.lng")
			{
				if (isIn)
				{
					response = Data.Where(s => s.address.geo.lng >= double.Parse(start) && s.address.geo.lng <= double.Parse(end)).Select(s => s.id).ToList();
				}
				else
				{
					response = Data.Where(s => s.address.geo.lng == double.Parse(start)).Select(s => s.id).ToList();
				}
			}
			else if (prop == "website")
			{
				if (isIn)
				{
					response = Data.Where(s => string.Compare(s.website, start, StringComparison.CurrentCulture) == 0||
					                          string.Compare(s.website, end, StringComparison.CurrentCulture) == 0).
						Select(s => s.id).ToList();
				}
				else
				{
					response = Data.Where(s => string.Compare(s.website, start, StringComparison.CurrentCulture) == 0).Select(s => s.id).ToList();
				}
			}
			else if (prop == "company.name")
			{
				if (isIn)
				{
					response = Data.Where(s => string.Compare(s.company.name, start, StringComparison.CurrentCulture) == 0||
					                          string.Compare(s.company.name, end, StringComparison.CurrentCulture) == 0).
						Select(s => s.id).ToList();
				}
				else
				{
					response = Data.Where(s => string.Compare(s.company.name, start, StringComparison.CurrentCulture) == 0).Select(s => s.id).ToList();
				}
			}
			else if (prop == "company.basename")
			{
				if (isIn)
				{
					response = Data.Where(s => string.Compare(s.company.basename, start, StringComparison.CurrentCulture) == 0||
					                          string.Compare(s.company.basename, end, StringComparison.CurrentCulture) == 0).
						Select(s => s.id).ToList();
				}
				else
				{
					response = Data.Where(s => string.Compare(s.company.basename, start, StringComparison.CurrentCulture) == 0).Select(s => s.id).ToList();
				}
			}

			if (response.Count == 0)
			{
				return new List<int>() { -1 };
			}
			return response;
		}

	}

	public class RootDataect
	{
		public Metadata[] Data { get; set; }
	}

	public class Metadata
	{
		public int id { get; set; }
		public string name { get; set; }
		public string username { get; set; }
		public string email { get; set; }
		public Address address { get; set; }
		public string website { get; set; }
		public Company company { get; set; }
	}

	public class Address
	{
		public string street { get; set; }
		public string suite { get; set; }
		public string city { get; set; }
		public string zipcode { get; set; }
		public ZipCode zipcodeNew { get; set; }
		public Geo geo { get; set; }
	}

	public class ZipCode
	{
		public long start;
		public long end;
	}

	public class Geo
	{
		public double lat { get; set; }
		public double lng { get; set; }
	}

	public class Company
	{
		public string name { get; set; }
		public string basename { get; set; }
	}
}