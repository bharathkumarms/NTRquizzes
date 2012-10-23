﻿using System;

namespace NTRsearch.DAL
{
    public class DALContext : IDALContext
    {
        private DB dbContext;
        private IQueryRepository queries;

        public DALContext()
        {
            dbContext = new DB();
        }

        public IQueryRepository Queries
        {
            get { return queries ?? (queries = new QueryRepository(dbContext)); }
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            if (queries != null)
                queries.Dispose();
            if (dbContext != null)
                dbContext.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}