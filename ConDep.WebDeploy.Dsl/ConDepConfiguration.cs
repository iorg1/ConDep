﻿using System.ComponentModel;
using System.Linq;

namespace ConDep.Dsl.FluentWebDeploy
{
	public abstract class ConDepConfiguration
	{
		protected ConDepConfiguration()
		{
			SetDefaultValues();
		}

		private void SetDefaultValues()
		{
			foreach (var property in GetType().GetProperties())
			{
				if (property.IsDefined(typeof(DefaultValueAttribute), false))
				{
					var attrib = property.GetCustomAttributes(typeof(DefaultValueAttribute), false).FirstOrDefault() as DefaultValueAttribute;
					property.SetValue(this, attrib.Value, null);
				}
			}
		}
		 
	}
}