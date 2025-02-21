﻿using System;

namespace LinqToDB.Mapping
{
	/// <summary>
	/// Marks property or field as a member of primary key for current mapping type.
	/// </summary>
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
	public class PrimaryKeyAttribute : MappingAttribute
	{
		/// <summary>
		/// Creates attribute instance.
		/// </summary>
		public PrimaryKeyAttribute()
		{
			Order = -1;
		}

		/// <summary>
		/// Creates attribute instance.
		/// </summary>
		/// <param name="order">Column order in composite primary key.</param>
		public PrimaryKeyAttribute(int order)
		{
			Order = order;
		}

		/// <summary>
		/// Creates attribute instance.
		/// </summary>
		/// <param name="configuration">Mapping schema configuration name. See <see cref="Configuration"/>.</param>
		/// <param name="order">Column order in composite primary key.</param>
		public PrimaryKeyAttribute(string? configuration, int order)
		{
			Configuration = configuration;
			Order         = order;
		}

		/// <summary>
		/// Gets or sets order of current column in composite primary key.
		/// Order is used for query generation to define in which order primary key columns must be mentioned in query
		/// from columns with smallest order value to greatest.
		/// Default value: <c>-1</c>.
		/// </summary>
		public int     Order         { get; set; }

		public override string GetObjectID()
		{
			return $".{Configuration}.{Order}.";
		}
	}
}
