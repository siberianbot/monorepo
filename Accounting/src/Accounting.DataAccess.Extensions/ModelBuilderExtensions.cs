using System;
using System.Linq;
using Accounting.Common.Extensions;
using Accounting.DataAccess.Extensions.Internal;
using Accounting.DataAccess.Extensions.Lookup;
using Microsoft.EntityFrameworkCore;

namespace Accounting.DataAccess.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static ModelBuilder CodeLookupEntity<TEnum>(this ModelBuilder modelBuilder)
            where TEnum : struct, Enum
        {
            Type enumType = typeof(TEnum);
            TEnum[] values = Enum.GetValues<TEnum>();

            modelBuilder
                .Entity<CodeLookupModel>()
                .ToTable(enumType.Name)
                .HasData(values.Select(value => new CodeLookupModel
                {
                    Id = Convert.ToInt64(value),
                    Code = value.GetAttribute<TEnum, CodeAttribute>()?.Value ?? Enum.GetName(value)
                }));

            return modelBuilder;
        }
    }
}