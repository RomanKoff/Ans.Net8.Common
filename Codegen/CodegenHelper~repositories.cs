﻿using Ans.Net8.Common.Codegen.Items;
using System.Formats.Asn1;
using System.Text;

namespace Ans.Net8.Common.Codegen
{

	public partial class CodegenHelper
	{

		public void MakeRepositories()
		{
			var path1 = Path.Combine(DalPath, "Repositories");
			SuppIO.CreateDirectoryIfNotExists(path1);
			foreach (var item1 in AllTables)
			{
				var filename1 = Path.Combine(path1, $"{item1.NamePluralize}Repository.cs");
				SuppIO.FileWrite(filename1, _getRepository(item1));
			}
		}


		/* privates */


		/* ==================================================================== */
		private string _getRepository(
			 TableItem table)
		{
			var sb1 = new StringBuilder();
			sb1.Append(_getCSharpAttention());
			sb1.Append(@$"
using Ans.Net8.Common.Crud;
using Guap.Media.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace {DalNamespace}.Repositories
{{

	public partial class {table.NamePluralize}Repository
		: _Crud{(table.HasMaster ? $"Slave" : "Master")}Repository_Proto<{table.EntityName}>,
		ICrud{(table.HasMaster ? $"Slave" : "Master")}Repository<{table.EntityName}>
	{{

		public {table.NamePluralize}Repository(
			DbContext db)
			: base(db)
		{{
		}}

{_getGetNew(table)}

	}}

}}
");
			return sb1.ToString();
		}
		/* ==================================================================== */



		/* -------------------------------------------------------------------- */
		private static string _getGetNew(
			TableItem table)
		{
			var sb1 = new StringBuilder();
			if (table.HasMaster)
				sb1.Append(@$"
		public override {table.EntityName} GetNew(
			int ptr)
		{{
			return new {table.EntityName}{_getCSharpDefaults(table)};			
		}}");
			else
				sb1.Append(@$"
		public override {table.EntityName} GetNew()
		{{
			return new {table.EntityName}{_getCSharpDefaults(table)};
		}}");
			return sb1.ToString();
		}
		/* -------------------------------------------------------------------- */


		/* -------------------------------------------------------------------- */
		private static string _getCSharpDefaults(
			TableItem table)
		{
			var sb1 = new StringBuilder();
			var items = table.DefaultCSharpFields;
			if (items?.Count() > 0)
			{
				sb1.Append(@"
			{");
				foreach (var item1 in items)
				{
					sb1.Append(@$"
				{item1.Name} = {item1.DefaultCSharp},");
				}
				sb1.Append(@"
			}");
			}
			else
			{
				sb1.Append("()");
			}
			return sb1.ToString();
		}
		/* -------------------------------------------------------------------- */

	}

}
