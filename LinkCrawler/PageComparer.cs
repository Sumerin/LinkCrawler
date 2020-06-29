using System;
using System.Collections.Generic;
namespace LinkCrawler
{
    public class PageComparer : IEqualityComparer<Page>
    {
        public bool Equals(Page x, Page y)
        {
            if (x is null && y is null)
            {
                return true;
            }
            if (x is null || y is null)
            {
                return false;
            }

            if (Object.ReferenceEquals(x, y))
            {
                return true;
            }

            return x.Url.Equals(y.Url);
        }

        public int GetHashCode(Page obj)
        {
            return obj.Url.GetHashCode();
        }
    }
}