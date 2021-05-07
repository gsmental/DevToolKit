## Pattern 1          
          
          DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@UserId", UserId);
            var data = db_dapper.QueryMultiple("usp_EvalBilliingEvaluatorBill", parameter, commandType: CommandType.StoredProcedure);
            var FirstSet = data.Read();
            var SecondSet = data.Read();

            MyDesiJugaad desiJugaad = new MyDesiJugaad();
            desiJugaad.Obj1 = FirstSet;
            desiJugaad.Obj2 = SecondSet;
            return desiJugaad;
            
  public class MyDesiJugaad
        {
            public dynamic Obj1 { get; set; }
            public dynamic Obj2 { get; set; }
        }



## Pattern-2
             
            
               public DataSet mymethod(string param1)
        {
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@param1", param1);
            var data = db_dapper.ExecuteReader("spname", parameter, commandType: CommandType.StoredProcedure);
            DataSet ds = ConvertDataReaderToDataSet(data);
            return ds;
        }
            
            
            public static DataSet ConvertDataReaderToDataSet(IDataReader data)
        {
            DataSet ds = new DataSet();
            int i = 0;
            while (!data.IsClosed)
            {
                ds.Tables.Add("Table" + (i + 1));
                ds.EnforceConstraints = false;
                ds.Tables[i].Load(data);
                i++;
            }
            return ds;
        }
