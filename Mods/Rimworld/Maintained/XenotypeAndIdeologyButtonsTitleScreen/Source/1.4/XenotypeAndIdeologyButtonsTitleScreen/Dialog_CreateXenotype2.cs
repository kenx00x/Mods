using System;
using RimWorld;
namespace XenotypeAndIdeologyButtonsTitleScreen
{
	public class Dialog_CreateXenotype2 : Dialog_CreateXenotype
	{
		public Dialog_CreateXenotype2(int index, Action callback) : base(index, callback)
		{
		}

		protected override string AcceptButtonLabel => "Save";
	}
}