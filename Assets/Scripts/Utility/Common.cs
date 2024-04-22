using UnityEngine.Assertions;

namespace Utility
{
	public sealed class Common
	{
		public static Common Instance => DIContainer.Get<Common>();
		private readonly CommonSO _data;

		public Common(CommonSO data)
		{
			Assert.IsNotNull(data);
			_data = data;
		}

		public static Constants Constants => Instance._data.Constants;
		public static Appearance Appearance => Instance._data.Appearance;
	}
}