using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistence.Paging
{
    public static class IQueryablePaginateSyncExtentions
    {
        //will change the name
        public static IPaginate<T> ToPaginateSync<T>(this IQueryable<T> source, int index, int size, int from = 0)
        {
            if (from > index) throw new ArgumentException($"From: {from} > Index: {index}, must From <= Index");



            var count =  source.Count();
            var items =source.Skip((index - from) * size)
                .Take(size).ToList();



            var list = new Paginate<T>
            {
                Index = index,
                Size = size,
                From = from,
                Count = count,
                Items = items,
                Pages = (int)Math.Ceiling(count / (double)size)
            };



            return list;
        }
    }
}
