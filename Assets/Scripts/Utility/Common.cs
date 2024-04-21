using UnityEngine;
using System.Collections;
using UnityEngine.Assertions;

namespace Utility
{
	public sealed class Common
	{
		public static Common Instance => DIContainer.Get<Common>();

		public static CommonSO Data => Instance._data;
		private readonly CommonSO _data;

		public Common(CommonSO data)
		{
			Assert.IsNotNull(data);
			_data = data;
		}
	}
}