namespace MyNotes.API.Core.Ultils
{
	public static class ObjectExtensions
	{
		public static void UpdateIgnoreNull(this object targetObject, object sourceObject, Dictionary<string, string>? propertyFields = null)
		{
			if (propertyFields == null)
			{
				foreach (var item in targetObject.GetType().GetProperties())
				{
					var info2 = sourceObject.GetType().GetProperty(item.Name);
					if (info2 != null && item.PropertyType == info2.PropertyType)
					{
						var value = info2.GetValue(sourceObject);
						if (value != null)
						{
							item.SetValue(targetObject, value);
						}
					}
				}
			}
			else
			{
				Type targetType = targetObject.GetType();
				Type sourceType = sourceObject.GetType();
				foreach (var item in propertyFields)
				{
					var targetProperty = targetType.GetProperty(item.Key);
					if (targetProperty != null)
					{
						var sourceProperty = sourceType.GetProperty(item.Value);
						if (sourceProperty != null && targetProperty.PropertyType == sourceProperty.PropertyType)
						{
							try
							{
								var value = sourceProperty.GetValue(sourceObject);
								if (value != null)
								{
									targetProperty.SetValue(targetObject, value);
								}
							}
							catch (Exception)
							{

								throw;
							}
						}
					}
				}
			}
		}
	}
}
