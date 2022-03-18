﻿namespace Base.Contracts.BLL
{
    public interface IBaseBLL
    {
        Task<int> SaveChangesAsync();
        
        TService GetService<TService>(Func<TService> serviceCreationMethod)
            where TService : class;
    }
}
