﻿using System.Collections.Generic;
using System.Text;

namespace EstelApi.Application.ApplicationCqrs.Queries.FindByIdSpec
{
    using EstelApi.Core.Seedwork.Specifications.Specifications;

    /// <summary>
    /// The find entities by id.
    /// </summary>
    /// <typeparam name="TEnity">
    /// </typeparam>
    /// <typeparam name="TType">
    /// </typeparam>
    public abstract class FindEntitiesById<TEnity,TType> : Specification<TEnity>
        where TEnity : class
    {
        protected TType Id;

        public FindEntitiesById<TEnity, TType> SetId(TType id)
        {
            this.Id = id;
            return this;
        }
    }
}