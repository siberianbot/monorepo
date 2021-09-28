using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Migrations;
using TeamWorks.DomainModel;
using TeamWorks.DomainModel.DataAnnotations;

namespace TeamWorks.DataAccess.Implementation.Extensions
{
    internal static class MigrationBuilderExtensions
    {
        #region Status

        public static MigrationBuilder AddStatus<TStatus>(this MigrationBuilder migrationBuilder, TStatus status)
            where TStatus : struct, Enum
        {
            Debug.Assert(Enum.IsDefined(status), "Enum.IsDefined(status)");

            long id = Convert.ToInt64(status);
            string code = status.GetType().GetMember(status.ToString()).FirstOrDefault()?.GetCustomAttribute<CodeAttribute>()?.Code ?? status.ToString();

            migrationBuilder.InsertData(nameof(Status), new[] {nameof(Status.Id), nameof(Status.Code)}, new object[] {id, code});

            return migrationBuilder;
        }

        public static MigrationBuilder RemoveStatus<TStatus>(this MigrationBuilder migrationBuilder, TStatus status)
            where TStatus : struct, Enum
        {
            Debug.Assert(Enum.IsDefined(status), "Enum.IsDefined(status)");

            long id = Convert.ToInt64(status);

            migrationBuilder.DeleteData(nameof(Status), nameof(Status.Id), id);
            
            return migrationBuilder;
        }
        
        #endregion
    }
}