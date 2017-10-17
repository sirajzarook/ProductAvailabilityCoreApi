using System;
using System.Collections.Generic;
using System.Text;

namespace ProductAvailabilityApi.Test
{
	public class TestCSV
	{

		public static string GetTestCSV1()
		{
			return @"0889059664247,NordsDropShip,2017/10/01,2017/12/01
0889059664248,NordsDropShip,2017/10/01,2017/12/01
0889059664249,NordsDropShip,2017/10/01,2017/12/01";
		}

		public static string GetTestCSV2_Wrong()
		{
			return @"0889059664111NordsDropShip,2017/10/01,2017/12/01
088905966222NordsDropShip,2017/10/01,2017/12/01
0889059664333,NordsDropShip,2017/10/01,2017/12/01";

		}

		public static string GetTestCSV_WrongDate()
		{
			return @"0889059664247,NordsDropShip,2017/10/32,2017/12/01
0889059664248,NordsDropShip,2017/10/01,2017/12/01
0889059664249,NordsDropShip,2017/10/01,2017/12/01";
		}
	}
}
