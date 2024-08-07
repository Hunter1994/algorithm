﻿using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Globalization;

namespace WebApplication1
{
    public class CultureQueryStringValueProviderFactory : IValueProviderFactory
    {
        public Task CreateValueProviderAsync(ValueProviderFactoryContext context)
        {
            _ = context ?? throw new ArgumentNullException(nameof(context));

            var query = context.ActionContext.HttpContext.Request.Query;
            if (query?.Count > 0)
            {
                context.ValueProviders.Add(new QueryStringValueProvider(BindingSource.Query, query, CultureInfo.CurrentCulture));
            }
            return Task.CompletedTask;
        }
    }
}
