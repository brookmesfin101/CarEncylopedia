using CarEncylopedia.Service.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;

namespace CarEncylopedia.Service.Infrastructure.HelperClasses
{
    public static class ListExtensions
    {
        public static IQueryable<CarDTO> SortBy(this IQueryable collection, string sortBy, bool reverse = false)
        {
            return collection.OrderBy(sortBy + (reverse ? " descending" : "")).Cast<CarDTO>();
        }
    }
}
