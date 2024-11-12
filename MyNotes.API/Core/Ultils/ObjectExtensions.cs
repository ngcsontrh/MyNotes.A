namespace MyNotes.API.Core.Ultils
{
	public static class ObjectExtensions
	{
		public static T? As<T>(this object? source) where T : class
		{
			if (source is null)
			{
				return default;
			}

			var result = Activator.CreateInstance<T>();
			if (result is null)
			{
				return default;
			}

			var targetProperties = typeof(T).GetProperties();
			foreach (var targetProperty in targetProperties)
			{
				var sourceProperty = source.GetType().GetProperty(targetProperty.Name);
				if (sourceProperty is not null && sourceProperty.CanRead)
				{
					var value = sourceProperty.GetValue(source);
					if (targetProperty.CanWrite)
					{
						targetProperty.SetValue(result, value);
					}
				}
			}
			return result;
		}

		public static void Update(this object targetObject, object sourceObject, Dictionary<string, string>? propertyFields = null)
		{
			if (targetObject is null || sourceObject is null)
			{
				throw new ArgumentNullException(targetObject is null 
					? nameof(targetObject) 
					: nameof(sourceObject), "Source or Target cannot be null.");
			}

			Type targetType = targetObject.GetType();
			Type sourceType = sourceObject.GetType();

			if (propertyFields is null)
			{
				foreach (var targetProperty in targetType.GetProperties())
				{
					var sourceProperty = sourceType.GetProperty(targetProperty.Name);
					if (sourceProperty is not null 
						&& targetProperty.PropertyType == sourceProperty.PropertyType)
					{
						try
						{
							var value = sourceProperty.GetValue(sourceObject);
							targetProperty.SetValue(targetObject, value ?? null);
						}
						catch (Exception ex)
						{
							throw new InvalidOperationException($"Failed to set property '{targetProperty.Name}' from source object.", ex);
						}
					}
				}
			}
			else
			{
				foreach (var (targetPropertyName, sourcePropertyName) in propertyFields)
				{
					var targetProperty = targetType.GetProperty(targetPropertyName);
					if (targetProperty is not null)
					{
						var sourceProperty = sourceType.GetProperty(sourcePropertyName);
						if (sourceProperty is not null 
							&& targetProperty.PropertyType == sourceProperty.PropertyType)
						{
							try
							{
								var value = sourceProperty.GetValue(sourceObject);
								targetProperty.SetValue(targetObject, value);
							}
							catch (Exception ex)
							{
								throw new InvalidOperationException($"Failed to set property '{targetPropertyName}' from source property '{sourcePropertyName}'.", ex);
							}
						}
						else
						{
							throw new InvalidOperationException($"Property type mismatch for target '{targetPropertyName}' and source '{sourcePropertyName}'.");
						}
					}
				}
			}
		}

		public static void UpdateIgnoreNull(this object targetObject, object sourceObject, Dictionary<string, string>? propertyFields = null)
		{
			if (targetObject is null)
			{
				throw new ArgumentNullException(nameof(targetObject), "Target object cannot be null.");
			}

			if (sourceObject is null)
			{
				throw new ArgumentNullException(nameof(sourceObject), "Source object cannot be null.");
			}

			Type targetType = targetObject.GetType();
			Type sourceType = sourceObject.GetType();

			if (propertyFields is null)
			{
				foreach (var targetProperty in targetType.GetProperties())
				{
					var sourceProperty = sourceType.GetProperty(targetProperty.Name);
					if (sourceProperty is not null && targetProperty.PropertyType == sourceProperty.PropertyType)
					{
						try
						{
							var value = sourceProperty.GetValue(sourceObject);
							if (value is not null)
							{
								targetProperty.SetValue(targetObject, value);
							}
						}
						catch (Exception ex)
						{
							throw new InvalidOperationException(ex.Message, ex);
						}
					}
				}
			}
			else
			{
				foreach (var (targetPropertyName, sourcePropertyName) in propertyFields)
				{
					var targetProperty = targetType.GetProperty(targetPropertyName);
					if (targetProperty is not null)
					{
						var sourceProperty = sourceType.GetProperty(sourcePropertyName);
						if (sourceProperty is not null && targetProperty.PropertyType == sourceProperty.PropertyType)
						{
							try
							{
								var value = sourceProperty.GetValue(sourceObject);
								if (value is not null)
								{
									targetProperty.SetValue(targetObject, value);
								}
							}
							catch (Exception ex)
							{
								throw new InvalidOperationException(ex.Message, ex);
							}
						}
						else
						{
							throw new InvalidOperationException($"Property type mismatch between target '{targetPropertyName}' and source '{sourcePropertyName}'.");
						}
					}
					else
					{
						throw new InvalidOperationException($"Target property '{targetPropertyName}' not found in the target object.");
					}
				}
			}
		}
	}
}
