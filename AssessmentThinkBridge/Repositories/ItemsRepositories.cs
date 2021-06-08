using AssessmentThinkBridge.Models;
using AssessmentThinkBridge.Repositories.Interfaces;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AssessmentThinkBridge.Repositories
{
    public class ItemsRepositories : IItemsRepositories
    {
        private readonly IConfiguration _config;

        /// <summary>
        /// Initializes a new instance of the <see cref="DashboardRepository"/> class.
        /// </summary>
        /// <param name="config">The configuration.</param>
        public ItemsRepositories(IConfiguration config)
        {
            _config = config;
        }

        #region Database Connection

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            }
        }

        public int DeleteItem(int ID)
        {
            using (IDbConnection dbConnection = Connection)
            {
                return dbConnection.ExecuteScalar<int>("DeleteItems", param: new { ID = ID }, commandType: CommandType.StoredProcedure);
            }
        }
        #endregion
        public List<ItemModel> GetAllItems()
        {
            using (IDbConnection dbConnection = Connection)
            {
                return dbConnection.Query<ItemModel>("getALLItems", commandType: CommandType.StoredProcedure, commandTimeout: 60).ToList();
            }
        }

        public ItemModel GetItems(int ID)
        {
            using (IDbConnection dbConnection = Connection)
            {
                return dbConnection.Query<ItemModel>("getItemsByID", param: new { ID = ID }, commandType: CommandType.StoredProcedure, commandTimeout: 60).FirstOrDefault();
            }
        }

        public int Save(ItemModel record)
        {
            using (IDbConnection dbConnection = Connection)
            {

                DynamicParameters parameter = new DynamicParameters();

                parameter.Add("@ItemID", value: record.ItemID, dbType: DbType.Int32, direction: ParameterDirection.Input);
                parameter.Add("@ItemName", value: record.ItemName, dbType: DbType.String, direction: ParameterDirection.Input);
                parameter.Add("@ItemDescriotion", value: record.ItemDescriotion, dbType: DbType.String, direction: ParameterDirection.Input);
                parameter.Add("@ItemQuentity", value: record.ItemQuentity, dbType: DbType.Int32, direction: ParameterDirection.Input);
                parameter.Add("@ItemPrice", value: record.ItemPrice, dbType: DbType.Int32, direction: ParameterDirection.Input);
                parameter.Add("@ItemDiscountPercentage", value: record.ItemDiscountPercentage, dbType: DbType.Int32, direction: ParameterDirection.Input);
                parameter.Add("@ItemImageUrl", value: record.ItemImageUrl, dbType: DbType.String, direction: ParameterDirection.Input);
                parameter.Add("@IsActive", value: record.IsActive, dbType: DbType.Boolean, direction: ParameterDirection.Input);
                parameter.Add("@CreatedBy", value: record.CreatedBy, dbType: DbType.Int32, direction: ParameterDirection.Input);
                parameter.Add("@CreatedDate", value: record.CreatedDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
                parameter.Add("@UpdateBy", value: record.UpdateBy, dbType: DbType.Int32, direction: ParameterDirection.Input);
                parameter.Add("@UpdatedDate", value: record.UpdatedDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);

                return dbConnection.ExecuteScalar<int>("SaveItem", parameter, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
