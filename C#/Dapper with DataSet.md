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
                   DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@xxx", xxx);
     
            var data = db_dapper.ExecuteReader("xxx", parameter, commandType: CommandType.StoredProcedure);
            DataSet ds = ConvertDataReaderToDataSet(data);
            return ds;
            
            
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
