using serverEngine.Net.Handlers;
using serverEngine.Data;
using System.Linq;

namespace serverEngine.Players
{
    class PlayerLoader
    {
        public Player LoadPlayer(string name, string password, ref LoginHandler.LoginReturnList returnValue)
        {
            var result = Database.Instance.Query(@"
SELECT TOP 1 [RecordGUID]
      ,[Name]
      ,[Password]
      ,[Position_x]
      ,[Position_y]
      ,[Postition_z]
      ,[Rotation_x]
      ,[Rotation_y]
      ,[Rotation_z]
  FROM [FlyingGame].[dbo].[Player]
WHERE 
    Name = @name",
    name.ToSqlParameter("@name")).First();


            if ((string)result["password"] != password)
            {

                return null;
            }

            return null;
        }
    }
}
