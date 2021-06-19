using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using CSharpProblemSolving.Adventofcode_Dec_20;
using CSharpProblemSolving.CodeJam_2020;
using CSharpProblemSolving.LinkedList;
using CSharpProblemSolving.QueueOperations;
using CSharpProblemSolving.StackOperations;
using CSharpProblemSolving.Strings;

namespace CSharpProblemSolving
{
	class Program
	{
		static int rev(int a)
		{
			int b = a % 10;
			int sum = 0;
			while (b != 0)
			{
				sum += b;
				a /= 10;
				b = a % 10;
				if (b != 0)
				{
					sum *= 10;
				}
			}

			return sum;
		}
		static int rev1(int a)
		{
			int sum = 0;
			while (a > 0)
			{
				sum = sum * 10 + a % 10;
				a /= 10;
			}

			return sum;
		}
		static void Main(string[] args)
		{
			RedundantBraces.Samples();
		}

		

		public static bool IsLetterOrSeparator(char c) =>
			c is (>= 'a' and <= 'z') or (>= 'A' and <= 'Z') or '.' or ',';
		static int GetNum(int row, int col)
		{
			int num = 0;
			int total = row * col;
			for (int i = 1; i <= total; i++)
			{
				
			}
			return num;
		}

		struct Quaternion
		{
			public double w, x, y, z;
		};
		static Quaternion ToQuaternion(double yaw, double pitch, double roll) // yaw (Z), pitch (Y), roll (X)
		{
			// Abbreviations for the various angular functions
			double cy = Math.Cos(yaw * 0.5);
			double sy = Math.Sin(yaw * 0.5);
			double cp = Math.Cos(pitch * 0.5);
			double sp = Math.Sin(pitch * 0.5);
			double cr = Math.Cos(roll * 0.5);
			double sr = Math.Sin(roll * 0.5);

			Quaternion q;
			q.w = cr * cp * cy + sr * sp * sy;
			q.x = sr * cp * cy - cr * sp * sy;
			q.y = cr * sp * cy + sr * cp * sy;
			q.z = cr * cp * sy - sr * sp * cy;

			return q;
		}

	}
}
